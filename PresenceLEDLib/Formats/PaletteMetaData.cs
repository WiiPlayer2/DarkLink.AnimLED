using System;
using System.Collections.Generic;
using System.Linq;
using PresenceLEDLib.Types;

namespace PresenceLEDLib.Formats
{
    public class PaletteMetaData : MetaData
    {
        public IReadOnlyList<ColorR8G8B8> Colors { get; }

        public PaletteMetaData(ColorR8G8B8[] colors)
        {
            Colors = colors;
        }

        public override byte[] Serialize() => Colors.SelectMany(c => new[] {c.Red, c.Green, c.Blue}).ToArray();
    }
}
