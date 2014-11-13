using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace IronPython.SignalRServer
{
    [HubName("IronPythonHub")]
    public class IronPythonHub:Hub
    {

        static IronPythonEngine ipyEngine;

        public IronPythonHub()
        {

        }
        public string ExecuteScript(string script)
        {

            if (ipyEngine == null)
            {
                ipyEngine = new IronPythonEngine();
            }
            ipyEngine.Execute(script);
            return ipyEngine.ConsoleOutPut;



            
            //var engine = Python.CreateEngine();
            //var scope = engine.CreateScope();
            //var scope = IronPythonEngine.GetScope();

            
            //var source = engine.CreateScriptSourceFromString(script, SourceCodeKind.AutoDetect);
            //engine.Runtime.IO.SetOutput(ms, Encoding.ASCII);
            //var compiled = source.Compile();
            //var result = compiled.Execute(scope);
            ////return result;
            //return Encoding.ASCII.GetString(ms.ToArray());

        }
    }
}
