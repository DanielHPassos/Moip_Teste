using Moip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var logProcess = new LogProcess(System.IO.Path.GetFullPath("log.txt"));
            var result = logProcess.Process();
            logProcess.GetTopUrl(result,3);
            Console.WriteLine();
            logProcess.GetTopStatus(result);


            Console.ReadKey();
        }
    }
}
