using System;
using BepInEx;

namespace BCE
{
    [BepInPlugin("space.customizing.console", "Console Extensions", "1.0.0.0")]
    public class console : BaseUnityPlugin 
    {
        public static void WriteLine(string text, ConsoleColor consoleColor)
        {
            ConsoleManager.SetConsoleColor(consoleColor);
            ConsoleManager.StandardOutStream.WriteLine(text);
        }
        public static void Write(string text, ConsoleColor consoleColor)
        {
            ConsoleManager.SetConsoleColor(consoleColor);
            ConsoleManager.StandardOutStream.Write(text);
        }
    }
}


