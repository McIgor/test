var client = new System.Net.Sockets.TcpClient();

await client.ConnectAsync("whois.nic.co", 43);

string response;
using (System.Net.Sockets.NetworkStream stream = client.GetStream())
{
    byte[] data = System.Text.Encoding.ASCII.GetBytes($"site.co{System.Environment.NewLine}{System.Environment.NewLine}");

    stream.Write(data, 0, data.Length);
    
    var reader = new System.IO.StreamReader(stream, System.Text.Encoding.ASCII);

    response = reader.ReadToEnd();
}

System.Console.Out.Write($"Response:{response}");
