using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceLEDLib.Types
{
    public enum ColorFormat : byte
    {
        R8G8B8 = 0x00,
        _1BPP,
        _2BPP,
        _4BPP,
    }
}
