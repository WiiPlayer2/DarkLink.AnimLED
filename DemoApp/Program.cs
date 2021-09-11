using System;
using System.IO.Ports;
using System.Threading.Tasks;
using PresenceLEDLib;
using PresenceLEDLib.Commands;
using PresenceLEDLib.Types;

namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serialPort = new SerialPort("COM6", 115200)
            {
                DtrEnable = true,
                RtsEnable = true,
                ReadTimeout = 2000,
            };
            serialPort.Open();

            var device = new Device(serialPort.BaseStream);
            await device.Call(new Update
            {
                ColorFormat = ColorFormat._1BPP,
                Frames = 4,
                Delay = 100,
                Loop = true,
            });
            await device.SendPacket(new byte[]
            {
                0x00, 0xFF, 0x00, // Color #0
                0xFF, 0x00, 0x00, // Color #1
                0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, // Frame #0
                0x00, 0x00, 0x01, 0x01, 0x01, 0x01, 0x00, 0x00, // Frame #1
                0x00, 0x00, 0x01, 0x01, 0x01, 0x01, 0x00, 0x00, // Frame #2
                0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, // Frame #3
            });
        }
    }
}
