using System;
using DarkLink.AnimLED.Types;

namespace DarkLink.AnimLED.Formats
{
    public class R8G8B8ImageData : ImageData<EmptyMetaData, R8G8B8FrameData, ColorR8G8B8>
    {
        public R8G8B8ImageData(int width, int height, int frameCount) : base(width, height, EmptyMetaData.Instance, frameCount, () => new R8G8B8FrameData(width, height)) { }

        public override ColorFormat Format => ColorFormat.R8G8B8;
    }
}
