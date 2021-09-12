using System;

namespace PresenceLEDLib.Formats
{
    public class PaletteFrameData : FrameData<byte>
    {
        public int BitDepth { get; }

        private readonly int valueRange;

        public PaletteFrameData(int width, int height, int bitDepth) : base(width, height)
        {
            BitDepth = bitDepth;
            valueRange = (int)Math.Pow(2, bitDepth);
        }

        public override byte this[int x, int y]
        {
            get => base[x, y];
            set => base[x, y] = value < valueRange ? value : throw new InvalidOperationException();
        }

        public override byte[] Serialize()
        {
            var result = new byte[(Width * Height * BitDepth) / 8];
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var bitOffset = (y * Width * BitDepth) + (x * BitDepth);
                    var byteOffset = bitOffset / 8;
                    var bitIndex = bitOffset % 8;
                    result[byteOffset] |= (byte)(this[x, y] << bitIndex);
                }
            }

            return result;
        }
    }
}
