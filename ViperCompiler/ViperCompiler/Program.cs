using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Compile
            string exe = args[1];
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters pars = new CompilerParameters();
            pars.GenerateExecutable = true;
            pars.OutputAssembly = exe;
            pars.GenerateInMemory = false;
            pars.TreatWarningsAsErrors = false;

            CompilerResults result = provider.CompileAssemblyFromFile(pars, args[0]);

            if (result.Errors.Count > 0)
            {
                foreach (CompilerError err in result.Errors)
                {
                    Console.WriteLine(err.ErrorText.ToString());
                    Console.ReadLine();
                }
            }
        }
    }
}
