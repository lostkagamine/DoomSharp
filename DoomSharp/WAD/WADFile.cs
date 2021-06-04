using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSharp.WAD
{
    public class WADFile
    {
        public static string Type;

        public WADHeader Header;
    }

    public class IWADFile : WADFile
    {
        public IWADFile()
        {
            Type = @"IWAD";
        }
    }

    public class PWADFile : WADFile
    {
        public PWADFile()
        {
            Type = @"PWAD";
        }
    }
}
