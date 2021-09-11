using System;
using System.Runtime.InteropServices;

namespace PresenceLEDLib.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ColorR8G8B8
    {
        public byte Red;

        public byte Green;

        public byte Blue;

        public ColorR8G8B8(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
