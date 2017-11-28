using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string protocol = string.Empty;
        string server = string.Empty;
        string resource = string.Empty;

        int indexOfProtocol = input.IndexOf("://");
        protocol = input.Substring(0, indexOfProtocol);
        input = input.Substring(indexOfProtocol + 3);

        int indexOfServer = input.IndexOf("/");
        server = input.Substring(0, indexOfServer);
        resource = input.Substring(indexOfServer);
        
        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);
    }
}
