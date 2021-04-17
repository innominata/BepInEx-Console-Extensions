# BepInEx-Console-Extensions
Simple mod to allow custom colours in the console from other BepInEx mods

Usage:

```
using BCE;
 
 console.Write("SomeText ", ConsoleColor.Red);
 
 console.Write("SomeOtherText\n", ConsoleColor.DarkCyan);

 console.WriteLine("A Whole Line of Text", ConsoleColor.DarkGray);
```
Avail Colors are found here, or via your IDE Autocomplete
https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor?view=net-5.0
