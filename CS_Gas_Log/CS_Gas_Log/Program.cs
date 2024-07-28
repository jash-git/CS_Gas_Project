using CS_Gas_Log;
using System;
using System.Dynamic;


public class Program
{
    public static ChipComm ChipCommBuf = new ChipComm();
    public static void pause()
    {
        Console.Write("\nPress any key to continue...");
        Console.ReadKey(true);
        ChipCommBuf.Close();
    }

    public static void Main()
    {
        Console.Write("輸入IP:");
        string IP = Console.ReadLine();
        Console.Write("輸入埠:");
        int Port = Convert.ToInt32(Console.ReadLine());
        if (ChipCommBuf.Connect(IP, Port))
        {
            int len = 0;
            Console.WriteLine($"{ChipCommBuf.StrResult}");

            Console.WriteLine($"傳送命令: {ChipCommBuf.SendCommand(ChipComm.Function2Command("Log", "", ref len), len)}");
            Console.WriteLine($"回傳結果: {ChipCommBuf.StrResult}");

            Console.WriteLine($"傳送命令: {ChipCommBuf.SendCommand(ChipComm.Function2Command("SetTime", "", ref len), len)}");
            Console.WriteLine($"回傳結果: {ChipCommBuf.StrResult}");


        }
        else
        {
            Console.WriteLine($"{ChipCommBuf.StrResult}");
        }
        pause();
    }
}