using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PresenceLEDLib.Types;

namespace PresenceLEDLib.Commands
{
    public class Update : Command
    {

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct Struct
        {
            public ColorFormat ColorFormat;

            public byte Frames;

            public byte Loop;

            public ulong Delay;
        }

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
    }
}
