using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PresenceLEDLib
{
    public class Device
    {
        private readonly Stream stream;

        private readonly byte[] header = new byte[] {0xFE, 0xED, 0xC0, 0xFF, 0xEE};

        private static readonly Encoding utf8 = new UTF8Encoding(false);

        public Device(Stream stream)
        {
            this.stream = stream;
        }

        public async Task<(Status Status, string Message)> SendPacket(byte[] packet, CancellationToken cancellationToken = default)
        {
            var packetLengthBytes = BitConverter.GetBytes((ushort) (header.Length + packet.Length));
            await stream.WriteAsync(packetLengthBytes, 0, packetLengthBytes.Length, cancellationToken);
            await stream.WriteAsync(header, 0, header.Length, cancellationToken);
            await stream.WriteAsync(packet, 0, packet.Length, cancellationToken);

            var responseBuffer = new byte[64];
            var read = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length, cancellationToken);
            if (read == 0)
                throw new IOException("No response received.");

            var status = (Status) responseBuffer[0];
            var msgLength = 0;
            for (var i = 1; i < responseBuffer.Length; i++)
            {
                if (responseBuffer[i] == '\n')
                {
                    msgLength = i - 1;
                    break;
                }
            }

            var msg = utf8.GetString(responseBuffer, 1, msgLength);
            if (status == Status.Error)
                throw new Exception($"Error: {msg}");

            return (status, msg);
        }
    }
}
