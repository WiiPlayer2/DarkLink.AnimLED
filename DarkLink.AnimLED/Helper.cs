using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace DarkLink.AnimLED
{
    public static class Helper
    {
        public static byte[] ToBytes(this object obj)
        {
            var size = Marshal.SizeOf(obj);
            var arr = new byte[size];

            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        public static byte[] ToBytes<T>(this T[] arr)
            => arr.SelectMany(o => o.ToBytes()).ToArray();
    }
}
