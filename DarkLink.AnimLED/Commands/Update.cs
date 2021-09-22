using System;
using System.Runtime.InteropServices;
using DarkLink.AnimLED.Types;

namespace DarkLink.AnimLED.Commands
{
    public class Update : Command
    {
        public override CommandType Type => CommandType.Update;

        public ColorFormat ColorFormat { get; set; }

        public byte Frames { get; set; }

        public bool Loop { get; set; }

        public ulong Delay { get; set; }

        public override byte[] Serialize() => new Struct
        {
            ColorFormat = ColorFormat,
            Frames = Frames,
            Loop = Loop ? (byte) 1 : (byte) 0,
            Delay = Delay,
        }.ToBytes();

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct Struct
        {
            public ColorFormat ColorFormat;

            public byte Frames;

            public byte Loop;

            public ulong Delay;
        }
    }
}
