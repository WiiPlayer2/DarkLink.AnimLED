using System.Runtime.InteropServices;

namespace PresenceLEDLib.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AnimationFrame
    {
        public byte ImageIndex;

        public byte DelayFactor;
    }
}
