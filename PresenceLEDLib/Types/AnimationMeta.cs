using System;
using System.Runtime.InteropServices;

namespace PresenceLEDLib.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AnimationMeta
    {
        public ColorFormat ColorFormat;

        public byte ImageCount;

        public byte FrameCount;

        public byte LoopStartIndex;

        public ulong BaseDelay;
    }
}
