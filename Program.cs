using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Nintenlord.Forms.Utility;
using Nintenlord.Collections.Lists;
using Nintenlord.GBA_Graphics_Editor.Forms;
using Nintenlord.ROMHacking.GBA;
using Nintenlord.ROMHacking.GBA.Compressions;
using Nintenlord.ROMHacking.GBA.Graphics;

namespace Nintenlord.GBA_Graphics_Editor
{
    static class Program
    {
        static private GBAROM ROM;
        static private DataBuffer rawGraphics, rawPalette, rawTSA;

        static private List<GraphicsData> datas;

        static private Color[] PALfilePalette;
        static private Color[] grayScalePalette;

        static private MainForm GUI;
        static private ImageForm imageForm;
        static private PaletteForm paletteForm;
        static private ColourForm colorForm;
        static private TileForm tileForm;

        static private int width;
        static int height;

        const int MaxCompGraphicsSize = 0x100000;
        const int MaxCompPaletteSize = 0x200;
        const int MaxCompTSASize = 0x4000;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BeginningStuff();
            if (args.Length > 0)
                LoadROM(args[0]);
            Application.Run(GUI);             
        }

        /// <summary>
        /// 
        /// </summary>
        private static void BeginningStuff()
        {
            datas = new List<GraphicsData>(2048);

            rawGraphics = new DataBuffer(0x8000);
            rawPalette = new DataBuffer(0x100);
            rawTSA = new DataBuffer(0x200);

            imageForm = new ImageForm();
            paletteForm = new PaletteForm();
            colorForm = new ColourForm(rawPalette);
            tileForm = new TileForm(rawTSA);

            imageForm.ImageIndexUD.ValueChanged += new EventHandler(ImageIndexUD_ValueChanged);
            imageForm.OffsetUD.ValueChanged += new EventHandler(OffsetUD_ValueChanged);
            paletteForm.ROMPALoffsetUD.ValueChanged += new EventHandler(ROMPALoffsetUD_ValueChanged);
            paletteForm.compROMPalette.CheckedChanged += new EventHandler(compROMPalette_CheckedChanged);

            GUI = new MainForm(new ToolForm[]{imageForm, paletteForm, colorForm, tileForm});
            ROM = new GBAROM();

            grayScalePalette = new Color[0x100];
            for (int x = 0; x < 0x10; x++)
            {
                for (int y = 0; y < 0x10; y++)
                {
                    int value = x * 0x10 + y;
                    grayScalePalette[x + y * 0x10] = Color.FromArgb(value, value, value);
                }
            }
        }

        static void compROMPalette_CheckedChanged(object sender, EventArgs e)
        {
            if (imageForm.CompressedGraphics)
            {
                UpdateStoredOffsets();
            }
        }
        
        static void ROMPALoffsetUD_ValueChanged(object sender, EventArgs e)
        {
            if (imageForm.CompressedGraphics)
            {
                UpdateStoredOffsets();
            }
        }

        static void OffsetUD_ValueChanged(object sender, EventArgs e)
        {
            if (imageForm.CompressedGraphics)
            {
                if (ROM.CanBeLZ77Decompressed(imageForm.Offset, MaxCompGraphicsSize, 0x1))
                {
                    int offset = imageForm.Offset;
                    int index = datas.IndexOf(x => x.Offset == offset);
                    if (index >= 0)
                    {
                        imageForm.ImageIndex = index;
                        UpdateDisplayedOffsets();
                    }
                    else
                    {
                        GraphicsData data = new GraphicsData();

                        data.Offset = imageForm.Offset;
                        data.PaletteOffset = 0;
                        data.Compressed = true;
                        data.PaletteCompressed = false;
                        datas.Add(data);

                        UpdateRanges();
                    }
                }
            }
        }

        static void ImageIndexUD_ValueChanged(object sender, EventArgs e)
        {
            WriteDatas(rawGraphics.Edited, rawPalette.Edited, rawTSA.Edited);

            UpdateDisplayedOffsets();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void LoadROM(string path)
        {
            if (ROM.Opened)
            {
                WriteDatas(rawGraphics.Edited, rawPalette.Edited, rawTSA.Edited);
            }
            if (ROM.Edited && MessageBox.Show("Changes haven't been saved.\nContinue and discard the changes?", 
                "Continue?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            ROM.OpenROM(path);
            GUI.Text = Path.GetFileName(path);
            string nlzFile = Path.ChangeExtension(path, ".nlz");
            if (File.Exists(nlzFile))
                LoadNLZFile(nlzFile);
            else
                Scan(0x20);

            UpdateRanges();
            if (datas.Count > 0)
                imageForm.ImageIndex = 0;
            UpdateDisplayedOffsets();

            GUI.Refresh();
        }


        public static void Update()
        {
            imageForm.CanUseCompGraphics = ROM.CanBeLZ77Decompressed(imageForm.Offset, MaxCompGraphicsSize, 0x1);
            paletteForm.CanUseCompPalette = ROM.CanBeLZ77Decompressed(paletteForm.PaletteOffset, MaxCompPaletteSize, 0x2);
            tileForm.CanUseCompressedTSA = ROM.CanBeLZ77Decompressed(tileForm.TSAOffset, MaxCompTSASize, 0x2);

            colorForm.AllowColorEditing = !paletteForm.CompressedPalette;
            tileForm.AllowTSAEditing = !tileForm.CompressedTSA;

            ReloadRawDatas(!rawGraphics.Edited, !rawPalette.Edited, !rawTSA.Edited);
        }

        /// <summary>
        /// To make data copying from/to GUI "atomic".
        /// </summary>
        static bool midUpdate = false;
        private static void UpdateDisplayedOffsets()
        {
            if (datas.Count > 0 && !midUpdate)
            {
                var data = datas[imageForm.ImageIndex];

                midUpdate = true;
                imageForm.Offset = data.Offset;
                imageForm.CompressedGraphics = data.Compressed;
                paletteForm.PaletteOffset = data.PaletteOffset;
                paletteForm.CompressedPalette = data.PaletteCompressed;
                midUpdate = false;
            }
        }

        private static void UpdateStoredOffsets()
        {
            if (datas.Count > 0 && !midUpdate)
            {
                var data = datas[imageForm.ImageIndex];

                midUpdate = true;
                data.Offset = imageForm.Offset;
                data.Compressed = imageForm.CompressedGraphics;
                data.PaletteOffset = paletteForm.PaletteOffset;
                data.PaletteCompressed = paletteForm.CompressedPalette;
                midUpdate = false;
            }
        }

        private static void UpdateRanges()
        {
            imageForm.MaxOffset = ROM.Length - 1;
            paletteForm.MaxPaletteOffset = ROM.Length - 2;
            tileForm.MaxTSAOffset = ROM.Length - 2;
            if (datas.Count != 0)
                imageForm.MaxImageIndex = datas.Count - 1;
            else
                imageForm.MaxImageIndex = 0;
        }
        
        public static void UpdateGraphics()
        {
            byte[] graphics = rawGraphics.ToArray();

            if (!tileForm.UseTSA || !tileForm.HeadTSA)
            {
                width = imageForm.ImageWidth * 8;
                height = imageForm.ImageHeigth * 8;
            }
            
            GraphicsMode mode = paletteForm.GraphicsMode;
            int bitsPerPixel = GBAGraphics.BitsPerPixel(mode);

            int length = Math.Min(bitsPerPixel * width * height / 8, graphics.Length);
            Color[] palette;
            switch (mode)
            {
                case GraphicsMode.Tile4bit:
                    palette = new Color[colorForm.Palette.Length - paletteForm.PaletteIndex * 16];
                    for (int i = 0; i < palette.Length; i++)
                        palette[i] = colorForm.Palette[i + 16 * paletteForm.PaletteIndex];
                    break;
                default:
                    palette = colorForm.Palette;
                    break;
            }

            if (tileForm.UseTSA && (mode == GraphicsMode.Tile4bit || mode == GraphicsMode.Tile8bit))
            {
                byte[] rawTSAData = new byte[width * height / 32];
                if (tileForm.HeadTSA)
                {
                    byte[] rawTSAData2 = rawTSA.ToArray();
                    for(int i = 0; i < height / 8; i ++)
                    {
                        for(int j = 0; j < width / 8; j++)
                        {
                            rawTSAData[2 * (i * width / 8 + j)] = rawTSAData2[2 + 2 * ((height / 8 - i - 1) * width / 8 + j)];
                            rawTSAData[2 * (i * width / 8 + j) + 1] = rawTSAData2[2 + 2 * ((height / 8 - i - 1) * width / 8 + j) + 1];
                        }
                    }
                }
                else
                {
                    rawTSAData = rawTSA.ToArray();
                }
                graphics = GBAGraphics.TSAmap(graphics, mode, rawTSAData, tileForm.AmountOfBytesToIngore, 
                    new Size(imageForm.ImageWidth, imageForm.ImageHeigth));
                mode = GraphicsMode.Tile8bit;
                length = graphics.Length;
            }

            if (paletteForm.GrayScale)
                palette = grayScalePalette;
            else if (paletteForm.PALfilePalette)
            {
                switch (mode)
                {
                    case GraphicsMode.Tile4bit:
                        palette = new Color[colorForm.Palette.Length - paletteForm.PaletteIndex * 16];
                        for (int i = 0; i < palette.Length; i++)
                            palette[i] = PALfilePalette[i + 16 * paletteForm.PaletteIndex];
                        break;
                    default:
                        palette = PALfilePalette;
                        break;
                }
            }

            int empty;
            Bitmap bitmap = GBAGraphics.ToBitmap(graphics, length, 0, palette, width, mode, out empty);
            imageForm.AmountEmptyGraphicsBlocks = empty;
            GUI.BitmapToDraw = bitmap;
        }


        private static void ReloadRawDatas(bool reloadGraphics, bool reloadPalette, bool reloadTSA)
        {
            if (reloadGraphics)
            {
                if (imageForm.CompressedGraphics)
                {
                    rawGraphics.ReadCompressedData(ROM, imageForm.Offset);
                }
                else
                {
                    int length = GBAGraphics.RawGraphicsLength(
                        new Size(imageForm.ImageWidth * 8, imageForm.ImageHeigth * 8), 
                        paletteForm.GraphicsMode);
                    rawGraphics.ReadData(ROM, imageForm.Offset, length);
                }
            }

            if (reloadPalette)
            {
                if (paletteForm.CompressedPalette)
                {
                    rawPalette.ReadCompressedData(ROM, paletteForm.PaletteOffset);
                }
                else
                {
                    rawPalette.ReadData(ROM, paletteForm.PaletteOffset, 0x200);
                }
            }

            if (reloadTSA)
            {
                if (tileForm.CompressedTSA)
                {
                    rawTSA.ReadCompressedData(ROM, tileForm.TSAOffset);
                }
                else if (tileForm.HeadTSA)
                {
                    width = ROM.GetData(tileForm.TSAOffset, 1)[0] + 1;
                    height = ROM.GetData(tileForm.TSAOffset + 1, 1)[0] + 1;
                    int length = width * height * 2;
                    imageForm.WidhtUD.Value = width;
                    imageForm.HeightUD.Value = height;
                    width *= 8;
                    height *= 8;
                    rawTSA.ReadData(ROM, tileForm.TSAOffset, length + 2);
                }
                else
                {
                    int length = tileForm.TSAHeigth * tileForm.TSAWidth * 2;
                    rawTSA.ReadData(ROM, tileForm.TSAOffset, length);
                }
            }
        }

        private static void WriteDatas(bool writeGraphics, bool writePalette, bool writeTSA)
        {
            if (writeGraphics)
            {
                rawGraphics.WriteData(ROM, imageForm.Offset, imageForm.CompressedGraphics);
            }

            if (writePalette)
            {
                rawPalette.WriteData(ROM, paletteForm.PaletteOffset, paletteForm.CompressedPalette);
            }

            if (writeTSA)
            {
                rawTSA.WriteData(ROM, tileForm.TSAOffset, tileForm.CompressedTSA);
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public static void SaveNLZFile()
        {
            if (ROM != null && ROM.ROMPath != null)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Path.ChangeExtension(ROM.ROMPath, ".nlz"), FileMode.Create)))
                {
                    for (int i = 0; i < datas.Count; i++)
                    {
                        var data = datas[i];
                        int graphicsOffset = data.Offset;
                        int paletteOffset = data.PaletteOffset;
                        if (data.Compressed)
                            graphicsOffset *= -1;
                        if (data.PaletteCompressed)
                            paletteOffset *= -1;
                        bw.Write(graphicsOffset);
                        bw.Write(paletteOffset);
                    }                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void LoadNLZFile(string path)
        {
            datas.Clear();
            using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
            {
                int capacity = (int)(br.BaseStream.Length / 8);
                for (int i = 0; i < capacity; i++) // br.BaseStream.Position > br.BaseStream.Length)
                {
                    int graphicsOffset = br.ReadInt32();
                    int paletteOffset = br.ReadInt32();
                    GraphicsData data = new GraphicsData();

                    data.Offset = Math.Abs(graphicsOffset);
                    data.PaletteOffset = Math.Abs(paletteOffset);
                    data.Compressed = graphicsOffset < 0;
                    data.PaletteCompressed = paletteOffset < 0;
                    datas.Add(data);
                }                
            }

            UpdateRanges();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void LoadPalFile(string path)
        {
            byte[] data;
            using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
            {
                br.BaseStream.Position = 0x18;
                data = br.ReadBytes((int)(br.BaseStream.Length - br.BaseStream.Position));
            }

            PALfilePalette = new Color[data.Length / 4];
            for (int i = 0; i < data.Length; i+=4)
            {
                PALfilePalette[i / 4] = Color.FromArgb(data[i], data[i + 1], data[i + 2]);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizeMultible"></param>
        public static void Scan(int sizeMultible)
        {
            datas.Clear();
            int[] results = ROM.ScanForLZ77CompressedData(0, ROM.Length, 0x8000, 4, sizeMultible);
            foreach (var item in results)
            {
                var data = new GraphicsData();
                data.Offset = item;
                data.Compressed = true;
                data.PaletteOffset = 0;
                data.PaletteCompressed = false;
                datas.Add(data);
            }

            UpdateRanges();
            if (datas.Count > 0)
                imageForm.ImageIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Exit()
        {
            WriteDatas(rawGraphics.Edited, rawPalette.Edited, rawTSA.Edited);
            return !ROM.Edited || MessageBox.Show("Exit without saving?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.None) == DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool WriteToROM()
        {
            FileAttributes attr = File.GetAttributes(ROM.ROMPath);
            if (attr != FileAttributes.ReadOnly)
            {
                WriteDatas(rawGraphics.Edited, rawPalette.Edited, rawTSA.Edited);
                ROM.SaveROM();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool WriteToROM(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            WriteDatas(rawGraphics.Edited, rawPalette.Edited, rawTSA.Edited);
            ROM.SaveROM(path);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void SaveBitmap(string path)
        {
            ImageFormat im;
            switch (Path.GetExtension(path).ToUpper())
            {
                case ".PNG":
                    im = ImageFormat.Png;
                    break;
                case ".BMP":
                    im = ImageFormat.Bmp;
                    break;
                case ".GIF":
                    im = ImageFormat.Gif;
                    break;
                default:
                    MessageBox.Show("Wrong image format.");
                    return;
            }
            GUI.BitmapToDraw.Save(path, im);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void InsertBitmap()
        {
            using (WriteToROM writeToROM = new WriteToROM("PNG files|*.png|Bitmap files|*.bmp|GIF files|*.gif",
                true, true, false, imageForm.Offset, paletteForm.PaletteOffset, 0))
            {
                if (writeToROM.ShowDialog() == DialogResult.Cancel)
                    return;

                WriteToROMDialogResult res = writeToROM.getResult();
                using (Bitmap bitmap = new Bitmap(res.file))
                {
                    Color[] palette = GetPalette(bitmap);
                    using (Palette_editor palEd = new Palette_editor(palette, 16, 16))
                    {
                        if (palEd.ShowDialog() == DialogResult.OK)
                        {
                            palette = palEd.getPalette();
                        }
                    }
                    if (paletteForm.CompressedPalette)
                    {
                        var oldPalette = colorForm.Palette;
                        if (palette.Length < oldPalette.Length)
                        {
                            for (int i = 0; i < palette.Length; i++)
                            {
                                oldPalette[i] = palette[i];
                            }
                            palette = oldPalette;
                        }
                    }

                    if (paletteForm.GraphicsMode == GraphicsMode.Tile4bit || 
                        paletteForm.GraphicsMode == GraphicsMode.Tile8bit)
                    {
                        if ((bitmap.Size.Width & 0x3) != 0 || (bitmap.Size.Height & 0x3) != 0)
                        {
                            MessageBox.Show("Size of the bitmap must be muliple of 8x8");
                            return;
                        }
                    }

                    bool insertedGraphics = InsertRawData(res.infos[0],
                        GBAGraphics.ToGBARaw(bitmap, palette, paletteForm.GraphicsMode),
                        rawGraphics,
                        imageForm.Offset,
                        imageForm.CompressedGraphics);

                    bool insertPalette = InsertRawData(res.infos[1],
                        GBAPalette.toRawGBAPalette(palette),
                        rawPalette,
                        paletteForm.PaletteOffset,
                        paletteForm.CompressedPalette);

                    UpdateRanges();
                    if (insertedGraphics)
                    {
                        if (imageForm.Offset != res.infos[0].offset)
                            imageForm.Offset = res.infos[0].offset;
                    }
                    if (insertPalette)
                    {
                        if (paletteForm.PaletteOffset != res.infos[1].offset)
                            paletteForm.PaletteOffset = res.infos[1].offset;
                    }

                    //TSA insertion goes here
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="data"></param>
        /// <param name="compressed"></param>
        /// <returns>True if something was inserted, false if not</returns>
        private static bool InsertRawData(WriteInfo info, byte[] data, DataBuffer originalData, int originalOffset, bool compressed)
        {
            if (info.import)
            {
                if (compressed)
                    data = LZ77.Compress(data);

                if (info.offset == originalOffset && info.abortIfBigger)
                {
                    int orgLength;
                    if (compressed)
                        orgLength = ROM.LZ77CompressedDataLength(originalOffset);
                    else
                        orgLength = originalData.Length;

                    if (orgLength < data.Length)
                    {
                        MessageBox.Show("New data larger than old. Aborting.");
                        return false;
                    }
                }

                ROM.InsertData(info.offset, data);

                if (originalOffset != info.offset && info.repoint)
                {
                    int[] offsets = ROM.ReplacePointers(originalOffset, info.offset);
                    string text;
                    if (offsets.Length > 0)
                    {
                        text = "Pointers changed at:";
                        for (int i = 0; i < offsets.Length; i++)
                            text += "\n" + Convert.ToString(offsets[i], 16);
                    }
                    else
                        text = "No pointers were found.";
                    MessageBox.Show(text);
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void DumpRawGraphics(string path)
        {
            DumpRawData(rawGraphics, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void DumpRawPalette(string path)
        {
            DumpRawData(rawPalette, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void DumpRawTSA(string path)
        {
            DumpRawData(rawTSA, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        private static void DumpRawData(DataBuffer data, string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            using (BinaryWriter bw = new BinaryWriter(File.Create(path, data.Length, FileOptions.SequentialScan)))
            {
                data.WriteData(bw);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void InsertRawGraphics()
        {
            using (WriteToROM writeToROM = new WriteToROM("GBA files|*.gba|Bibary files|*.bin|All files|*",
                true, false, false, imageForm.Offset, 0, 0))
            {
                if (writeToROM.ShowDialog() == DialogResult.Cancel)
                    return;

                WriteToROMDialogResult res = writeToROM.getResult();
                
                byte[] newdata = File.ReadAllBytes(res.file);

                if (InsertRawData(res.infos[0],
                    newdata,
                    rawGraphics,
                    imageForm.Offset,
                    imageForm.CompressedGraphics))
                {
                    if (imageForm.Offset != res.infos[0].offset)
                        imageForm.Offset = res.infos[0].offset;
                }

            }
            //InsertRawData(this.rawGraphics, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void InsertRawPalette()
        {
            using (WriteToROM writeToROM = new WriteToROM("GBA files|*.gba|Bibary files|*.bin|All files|*",
                false, true, false, 0, paletteForm.PaletteOffset, 0))
            {
                if (writeToROM.ShowDialog() == DialogResult.OK)
                    return;

                WriteToROMDialogResult res = writeToROM.getResult();

                byte[] newdata = File.ReadAllBytes(res.file);

                if (InsertRawData(res.infos[1],
                    newdata,
                    rawPalette,
                    paletteForm.PaletteOffset,
                    paletteForm.CompressedPalette))
                {
                    if (paletteForm.PaletteOffset != res.infos[1].offset)
                        paletteForm.PaletteOffset = res.infos[1].offset;
                }
                //do importing

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void InsertRawTSA()
        {
            using (WriteToROM writeToROM = new WriteToROM("GBA files|*.gba|Bibary files|*.bin|All files|*",
                false, false, true, 0, 0, tileForm.TSAOffset))
            {
                if (writeToROM.ShowDialog() == DialogResult.OK)
                    return;

                WriteToROMDialogResult res = writeToROM.getResult();
                
                byte[] newdata = File.ReadAllBytes(res.file);

                if (InsertRawData(res.infos[2],
                    newdata,
                    rawGraphics,
                    tileForm.TSAOffset,
                    tileForm.CompressedTSA))
                {
                    if (tileForm.TSAOffset != res.infos[2].offset)
                        tileForm.TSAOffset = res.infos[2].offset;
                }
                //do importing

            }
        }



        public static void ChangeTSAIndex(int x, int y)
        {
            if (tileForm.UseTSA && x < imageForm.ImageWidth && y < imageForm.ImageHeigth)
            {
                tileForm.TileIndex = x + y * imageForm.ImageWidth;
            }
        }

        public static GraphicsMode GetMode()
        {
            return paletteForm.GraphicsMode;
        }

        //helper methods

        private static Color[] GetPalette(Bitmap bitmap)
        {
            List<Color> palette = new List<Color>(0x100);

            if (bitmap.PixelFormat.HasFlag(PixelFormat.Indexed))
            {
                palette.AddRange(bitmap.Palette.Entries);
            }
            else
            {
                HashSet<Color> colors = new HashSet<Color>();
                foreach (var color in bitmap.GetPixelEnumerator())
                {
                    colors.Add(color);
                }
                palette.AddRange(colors);
            }
            return palette.ToArray();
        }

    }
}