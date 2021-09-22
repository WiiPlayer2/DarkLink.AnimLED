using System;

namespace DarkLink.AnimLED.Formats
{
    public class EmptyMetaData : MetaData
    {
        private EmptyMetaData() { }

        public static EmptyMetaData Instance { get; } = new();

        public override byte[] Serialize() => Array.Empty<byte>();
    }
}
