using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new TcpClient();

            await client.ConnectAsync("whois.nic.co", 43);

            string response;
            using (NetworkStream stream = client.GetStream())
            {
                byte[] data = Encoding.ASCII.GetBytes($"site.co{Environment.NewLine}");

                stream.Write(data, 0, data.Length);
                
                var reader = new StreamReader(stream, Encoding.ASCII);

                response = reader.ReadToEnd();
            }

            Console.Out.Write(response);
        }
    }
}
