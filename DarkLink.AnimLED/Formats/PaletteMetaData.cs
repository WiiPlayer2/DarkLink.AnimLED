using System;
using System.Collections.Generic;
using System.Linq;
using DarkLink.AnimLED.Types;

namespace DarkLink.AnimLED.Formats
{
    public class PaletteMetaData : MetaData
    {
        public PaletteMetaData(ColorR8G8B8[] colors)
        {
            Colors = colors;
        }

        public IReadOnlyList<ColorR8G8B8> Colors { get; }

        public override byte[] Serialize() => Colors.SelectMany(c => new[] {c.Red, c.Green, c.Blue,}).ToArray();
    }
}
