using System;
using PresenceLEDLib.Types;

namespace PresenceLEDLib.Formats
{
    public class R8G8B8ImageData : ImageData<EmptyMetaData, R8G8B8FrameData, ColorR8G8B8>
    {
        public R8G8B8ImageData(int width, int height, int frameCount) : base(width, height, EmptyMetaData.Instance, frameCount) { }
        public override ColorFormat Format => ColorFormat.R8G8B8;

        protected override R8G8B8FrameData CreateFrame() => new(Width, Height);
    }
}
