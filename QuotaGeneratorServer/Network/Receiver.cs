using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuotaGeneratorServer.Network
{
    // Receiver - класс для чтения текстового сообщения через сокет
    internal class Receiver : IDisposable
    {
        private Socket socket;
        private byte[] buffer;

        public Receiver(Socket socket, int bufferSize)
        {
            this.socket = socket;
            buffer = new byte[bufferSize];
        }

        public void Dispose()
        {
            socket?.Close();
        }

        public string Receive()
        {
            // TODO: упростить код - сделать под клиента
            int bytesRead = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                socket.Receive(buffer, i, 1, SocketFlags.None);
                if (buffer[i] == '\r')
                {
                    break;
                } else
                {
                    bytesRead++;
                }
            }
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            return message.Substring(1);
        }
    }
}
