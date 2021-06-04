using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSharp.WAD
{
    public static class MemoryStreamExtensions
    {
        public static void Rewind(this MemoryStream ms)
        {
            ms.Seek(0, SeekOrigin.Begin);
        }

        public static byte[] ReadBytes(this MemoryStream ms, int howmany)
        {
            var data = new byte[howmany];

            var read = ms.Read(data, 0, howmany);

            Assert.That(read == howmany);

            return data;
        }

        public static string ReadString(this MemoryStream ms, int length)
        {
            var data = ms.ReadBytes(4);
            var str = Encoding.ASCII.GetString(data);
            return str;
        }

        public static uint ReadU32(this MemoryStream ms)
        {
            var data = ms.ReadBytes(4);
            var bc = BitConverter.ToUInt32(data);
            return bc;
        }
    }
}
