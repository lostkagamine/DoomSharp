using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSharp.WAD
{
    public struct WADHeader
    {
        public string Type;
        public uint DirectoryCount;
        public uint DirectoryOffset;
    }

    public struct WADLump
    {
        public uint Offset;
        public uint Size;
        public string Name;
    }
}
