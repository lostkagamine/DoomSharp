using Luminal.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Luminal.Core;

namespace DoomSharp.WAD
{
    public static class WADLoader
    {
        public static WADFile LoadFile(string path)
        {
            Log.Debug($"-DS- WADLoader.LoadFile {path}");

            WADFile wad = null;

            var file = new FSFile(path);
            var strm = file.Stream;

            var ms = new MemoryStream();
            strm.CopyTo(ms);

            ms.Rewind();

            var typestring = ms.ReadString(4);

            wad = typestring switch
            {
                "IWAD" => new IWADFile(),
                "PWAD" => new PWADFile(),
                _ => throw new Exception($"-DS- Unknown wad file type {typestring}")
            };

            var dircount = ms.ReadU32();
            var diroff = ms.ReadU32();

            var header = new WADHeader()
            {
                Type = typestring,
                DirectoryCount = dircount,
                DirectoryOffset = diroff
            };

            Log.Debug($"-DS- {typestring} file - {dircount} lumps @ 0x{diroff.ToString("x").ToUpper()}");

            wad.Header = header;

            return wad;
        }
    }
}
