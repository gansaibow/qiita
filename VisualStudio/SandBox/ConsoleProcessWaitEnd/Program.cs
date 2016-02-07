using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleProcessWaitEnd
{
    class Program
    {
        private const int MAX_SECCONDS = 10 * 1000;

        static void Main(string[] args)
        {
            ProcessStartInfo psiNotepad = new ProcessStartInfo();
            psiNotepad.FileName = @"notepad";
            Process psNotepad = System.Diagnostics.Process.Start(psiNotepad);

            if(!psNotepad.WaitForExit(MAX_SECCONDS))
            {
                psNotepad.Kill();
            }
            
        }
    }
}
