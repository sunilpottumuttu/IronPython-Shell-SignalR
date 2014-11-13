using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace IronPython.SignalRServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "IronPython Shell - (Server)";
            using (WebApp.Start<Startup>("http://localhost:1968"))
            {
                Console.WriteLine("Server running!");
                Console.ReadLine();
            }
        }
    }
}
