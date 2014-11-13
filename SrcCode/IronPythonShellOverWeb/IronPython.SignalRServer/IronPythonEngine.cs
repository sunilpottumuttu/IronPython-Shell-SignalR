using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace IronPython.SignalRServer
{
    public class IronPythonEngine
    {
        private ScriptEngine engine;
        private ScriptScope scope;

        public dynamic ScriptResult { get; private set; }
        public string ConsoleOutPut { get; private set; }

        public IronPythonEngine()
        {
            this.engine = Python.CreateEngine();
            scope = this.engine.CreateScope();
        }

        public void Execute(string script)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                var source = engine.CreateScriptSourceFromString(script, SourceCodeKind.InteractiveCode);
                engine.Runtime.IO.SetOutput(ms, Encoding.ASCII);
                var compiled = source.Compile();
                this.ScriptResult = compiled.Execute(scope);
                this.ConsoleOutPut = Encoding.ASCII.GetString(ms.ToArray());
            }
            catch(Exception ex)
            {
                MemoryStream ms = new MemoryStream();
                ms.Write(Encoding.ASCII.GetBytes(ex.Message), 0, ex.Message.Length);
                //engine.Runtime.IO.SetErrorOutput(ms, Encoding.ASCII);
                this.ScriptResult = string.Empty;
                this.ConsoleOutPut = Encoding.ASCII.GetString(ms.ToArray());
            }

        }

        
    }
}
