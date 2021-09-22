using System;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using DarkLink.AnimLED;
using DarkLink.AnimLED.Commands;
using DarkLink.AnimLED.Formats;
using DarkLink.AnimLED.Types;

namespace DemoApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var serialPort = new SerialPort("COM6", 115200)
            {
                DtrEnable = true,
                RtsEnable = true,
                ReadTimeout = 2000,
            };

            var metaData = new PaletteMetaData(new ColorR8G8B8[]
            {
                new(0x00, 0xFF, 0x00),
                new(0xFF, 0x00, 0xFF),
            });
            var imageData = new PaletteImageData(8, 8, metaData, 2, 1);
            for (var x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    var index = (y * 9 + x) % 2;
                    imageData.Frames[0][x, y] = (byte)index;
                    imageData.Frames[1][x, y] = (byte) (1 - index);
                }
            }

            var meta = new AnimationMeta()
            {
                ColorFormat = ColorFormat._1BPP,
                ImageCount = 2,
                FrameCount = 2,
                LoopStartIndex = 0,
                BaseDelay = 250,
            };
            var frames = new AnimationFrame[2]
            {
                new()
                {
                    ImageIndex = 0,
                    DelayFactor = 1,
                },
                new()
                {
                    ImageIndex = 1,
                    DelayFactor = 1,
                },
            };
            var packet = meta.ToBytes().Concat(frames.ToBytes()).Concat(imageData.Serialize()).ToArray();

            serialPort.Open();
            var device = new Device(serialPort.BaseStream);
            await device.Call(CommandType.Update, packet);
        }
    }
}
