using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace IronPython.DotNetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IronPython Shell Over Web";
            Do().Wait();
        }
        static async Task Do()
        {
            const string url = "http://localhost:1968";
            var connection = new HubConnection(url);

            var echo = connection.CreateHubProxy("IronPythonHub");

            await connection.Start();

            //Print Version Informaton
            {
                var script = @"import sys;sys.version; ";
                var ipyVersionMessage = await echo.Invoke<string>("ExecuteScript", script);
                Console.Write(ipyVersionMessage);
                Console.WriteLine();
            }

            for (; ; )
            {
                Console.Write("ipyweb > ");
                var script = Console.ReadLine();
                if (script.Trim() == "") { continue; }
                var response = await echo.Invoke<string>("ExecuteScript", script);
                Console.Write(response);
                Console.WriteLine();
            }

        }
    }
}
