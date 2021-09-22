using System;
using DarkLink.AnimLED.Types;

namespace DarkLink.AnimLED.Formats
{
    public class R8G8B8FrameData : FrameData<ColorR8G8B8>
    {
        public R8G8B8FrameData(int width, int height) : base(width, height) { }

        public override byte[] Serialize()
        {
            var result = new byte[Width * Height * 3];
            for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
            {
                var offset = y * Width * 3 + x * 3;
                var color = this[x, y];
                result[offset + 0] = color.Red;
                result[offset + 1] = color.Green;
                result[offset + 2] = color.Blue;
            }

            return result;
        }
    }
}
