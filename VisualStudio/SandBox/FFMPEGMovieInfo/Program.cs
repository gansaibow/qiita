using System;
using System.Diagnostics;
using System.IO;

namespace FFMPEGMovieInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string ffmpegExePath = args[0];
            string filePath = args[1];

            if (!File.Exists(ffmpegExePath))
            {
                Console.WriteLine("ファイルが存在しません。");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("ファイルが存在しません。");
                return;
            }

            string command = ffmpegExePath;
            Process p = new Process();

            // 実行するファイル
            p.StartInfo.FileName = command;
            // 実行する引数 
            p.StartInfo.Arguments = @"-select_streams v -show_streams " + filePath;

            // コンソールを開かない
            p.StartInfo.CreateNoWindow = true;

            // シェル機能を使用しない
            p.StartInfo.UseShellExecute = false;

            // 標準出力をリダイレクト
            p.StartInfo.RedirectStandardOutput = true;

            // アプリの実行開始
            p.Start();

            // 標準出力の読み取り
            string output = p.StandardOutput.ReadToEnd();

            // 改行コードの修正
            output = output.Replace("\r\r\n", "\n");

            // ［出力］ウィンドウに出力
            Console.Write(output); 
            Console.ReadKey();
        }
    }
}
