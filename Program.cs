using System;
using System.Diagnostics;
using System.Threading;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        WriteLine("PC Control App");
        WriteLine("Select an option:");
        WriteLine("1. Shutdown PC");
        WriteLine("2. Restart PC");
        WriteLine("3. Put PC to Sleep");
        WriteLine("4. Cancel");

        string choice = ReadLine();
        switch (choice)
        {
            case "1":
                Shutdown();
                break;
            case "2":
                Restart();
                break;
            case "3":
                Sleep();
                break;
            case "4":
                WriteLine("Operation canceled.");
                break;
            default:
                WriteLine("Invalid choice. Exiting.");
                break;
        }
    }
    static void Shutdown()
    {
        WriteLine("This PC will shutdown in 10 seconds...");
        Process.Start("shutdown", "/s /t 10");
        Countdown();
    }
    static void Restart()
    {
        WriteLine("This PC will restart in 10 seconds...");
        Process.Start("shutdown", "/r /t 10");
        Countdown();
    }
    static void Sleep()
    {
        WriteLine("Putting PC to sleep...");
        Process.Start("rundll32.exe", "powrprof.dll,SetSuspendState 0,1,0");
    }
    static void Countdown()
    {
        int countdown = 10;
        for (int i = countdown; i > 0; i--)
        {
            Write($"\rTime remaining: {i} seconds");
            Thread.Sleep(1000);
        }
        WriteLine();
    }
}