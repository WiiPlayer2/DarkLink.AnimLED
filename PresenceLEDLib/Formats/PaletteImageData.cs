using System;
using PresenceLEDLib.Types;

namespace PresenceLEDLib.Formats
{
    public class PaletteImageData : ImageData<PaletteMetaData, PaletteFrameData, byte>
    {
        public PaletteImageData(int width, int height, PaletteMetaData metaData, int frameCount, int bitDepth)
            : base(width, height, metaData, frameCount, () => new PaletteFrameData(width, height, bitDepth))
        {
            if (metaData.Colors.Count != (int) Math.Pow(2, bitDepth))
                throw new ArgumentException();
            Format = bitDepth switch
            {
                1 => ColorFormat._1BPP,
                2 => ColorFormat._2BPP,
                3 => ColorFormat._4BPP,
                _ => throw new NotSupportedException(),
            };
        }

        public override ColorFormat Format { get; }
    }
}
