using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleThread
{
    class Program
    {
        private const int MAX_SECCONDS = 60;
        static private int timerCount = 0;
        static private bool isSuccess = false;

        static private Process psNotepad;

        static void Main(string[] args)
        {
            Thread thexe = new Thread(new ThreadStart(ThreadExe));

            thexe.Start();

            while (true)
            {
                if (isSuccess)
                {
                    Console.WriteLine("OK");
                    break;
                }

                if (timerCount < MAX_SECCONDS)
                {
                    Thread.Sleep(1000);
                    timerCount++;
                }
                else
                {
                    Console.WriteLine("NG");
                    psNotepad.Kill();
                    thexe.Abort();
                    break;
                }
            }
            Console.ReadKey();
        }

        private static void ThreadExe()
        {
            ProcessStartInfo psiNotepad = new ProcessStartInfo();
            psiNotepad.FileName = @"notepad";
            psNotepad = System.Diagnostics.Process.Start(psiNotepad);
            psNotepad.WaitForExit();
            isSuccess = true;
        }
    }
}
