// -----------------------------------------------------------------------
// <copyright file="DataBuffer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nintenlord.GBA_Graphics_Editor
{
    using System.Collections.Generic;
    using System.IO;
    using Nintenlord.ROMHacking.GBA;
    using Nintenlord.ROMHacking.GBA.Compressions;
    using System;

    /// <summary>
    /// Editable buffer of data
    /// </summary>
    public sealed class DataBuffer
    {
        bool hasBeenEdited;
        List<byte> data;

        public byte this[int index]
        {
            get
            {
                try
                {
                    return data[index];
                }
                catch (Exception)
                {
                    throw;
                }
            }
            set
            {
                try
                {
                    hasBeenEdited |= data[index] != value;
                    data[index] = value;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public int Length
        {
            get { return data.Count; }
        }
        public bool Edited { get { return hasBeenEdited; } }

        public DataBuffer(int capacity)
        {
            data = new List<byte>(capacity);
            hasBeenEdited = false;
        }

        public int GetLZ77CompLenght()
        {
            return LZ77.Compress(data.ToArray()).Length;
        }

        public void WriteData(GBAROM rom, int offset, bool compressed)
        {
            hasBeenEdited = false;
            if (compressed)
            {
                rom.InsertLZ77CompressedData(offset, data.ToArray());
            }
            else
            {
                rom.InsertData(offset, data.ToArray());
            }
        }

        public void ReadCompressedData(GBAROM rom, int offset)
        {
            hasBeenEdited = false;
            data.Clear();
            try
            {
                data.AddRange(rom.DecompressLZ77CompressedData(offset));
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentException("Data at offset " + offset.ToString("X8") + " can't be decompressed", e);
            }
        }

        public void ReadData(GBAROM rom, int offset, int lenght)
        {
            hasBeenEdited = false;
            data.Clear();
            try
            {
                data.AddRange(rom.GetData(offset, lenght));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public void Append(IEnumerable<byte> newData)
        {
            hasBeenEdited = true;
            data.AddRange(newData);
        }

        public void WriteData(BinaryWriter writer)
        {
            writer.Write(data.ToArray());
        }

        public byte[] ToArray()
        {
            return data.ToArray();
        }
    }
}
