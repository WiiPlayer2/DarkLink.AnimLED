using System;

namespace PresenceLEDLib.Formats
{
    public class EmptyMetaData : MetaData
    {
        private EmptyMetaData() { }

        public static EmptyMetaData Instance { get; } = new();

        public override byte[] Serialize() => Array.Empty<byte>();
    }
}
