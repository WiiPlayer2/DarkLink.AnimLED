using System;

namespace PresenceLEDLib.Formats
{
    public abstract class FrameData<TPixelData>
    {
        private readonly TPixelData[,] data;

        protected FrameData(int width, int height)
        {
            Width = width;
            Height = height;
            data = new TPixelData[width, height];
        }

        public int Width { get; }

        public int Height { get; }

        public virtual TPixelData this[int x, int y]
        {
            get => data[x, y];
            set => data[x, y] = value;
        }

        public abstract byte[] Serialize();
    }
}
