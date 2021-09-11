﻿using System;
using System.Collections.Generic;
using System.Linq;
using PresenceLEDLib.Types;

namespace PresenceLEDLib.Formats
{
    public abstract class ImageData<TMetaData, TFrameData, TPixelData>
        where TMetaData : MetaData
        where TFrameData : FrameData<TPixelData>
    {
        protected ImageData(int width, int height, TMetaData metaData, int frameCount)
        {
            Width = width;
            Height = height;
            MetaData = metaData;
            Frames = Enumerable.Repeat(0, frameCount).Select(_ => CreateFrame()).ToArray();
        }

        public int Width { get; }

        public int Height { get; }

        public TMetaData MetaData { get; }

        public IReadOnlyList<TFrameData> Frames { get; }

        public abstract ColorFormat Format { get; }

        protected abstract TFrameData CreateFrame();

        public byte[] Serialize() => MetaData.Serialize().Concat(Frames.SelectMany(o => o.Serialize())).ToArray();
    }
}
