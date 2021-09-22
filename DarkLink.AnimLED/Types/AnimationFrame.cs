using System;
using System.Runtime.InteropServices;

namespace DarkLink.AnimLED.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AnimationFrame
    {
        public byte ImageIndex;

        public byte DelayFactor;
    }
}
