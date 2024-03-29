Simple library to allow easy use of custom colours in the console by other BepInEx mods

Developer Usage:

```cs
using BCE;

 console.Write("SomeText ", ConsoleColor.Red);

 console.Write("SomeOtherText\n", ConsoleColor.DarkCyan);

 console.WriteLine("A Whole Line of Text", ConsoleColor.DarkGray);
```
Available Colors are found here, or via your IDE Autocomplete
https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor?view=net-5.0


Transpiler IL Output Extensions for CodeMatcher and IEnumerable<CodeInstruction>:
```cs
using BCE;
  ...
[HarmonyTranspiler]   
[HarmonyPatch(typeof(LocalLaserOneShot),  nameof(LocalLaserOneShot.TickSkillLogic))]
public static IEnumerable<CodeInstruction> TickSkillLogic_Transpiler_Transpiler(IEnumerable<CodeInstruction> instructions)
 {
 try {
      instructions.Log("TickSkillLogic_Transpiler"); // <- outputs the entire method in IL
      var matcher = new CodeMatcher(instructions).MatchForward(true, new CodeMatch(i => (i.opcode == Ldc_R4)));
      if (!matcher.IsInvalid)
      {
          matcher.
          matcher.Repeat(matcher =>
          {
              matcher.LogILPre(); // <- logs the current instruction (and the default 5 instructions before and after)
              var mi = AccessTools.Method(typeof(PatchOnDFRelayComponent), nameof(Utils.GetRadiusFromAstroId)).MakeGenericMethod(matcher.Operand?.GetType() ?? typeof(float));
              matcher.Advance(1);
              matcher.InsertAndAdvance(new CodeInstruction(Ldarg_0));
              matcher.InsertAndAdvance(Utils.LoadField(typeof(LocalLaserOneShot), nameof(LocalLaserOneShot.astroId)));
              matcher.InsertAndAdvance(new CodeInstruction(Call, mi));
              matcher.LogILPost(4); // <- logs the last 4 instructions (and the default 5 instructions before and after)
          });
          instructions = matcher.InstructionEnumeration();
          return instructions;
      }
      return instructions;
            }
            catch
            {
                Bootstrap.Logger.LogInfo("PatchOnLocalLaserOneShot.Aim_Transpiler failed");
                return instructions;
            }
        }
```
I have an error in that code, the last InsertAndAdvance should be Insert. So the highlit part of the IL is off by one, but I can't be bothered taking the picture again :)

![IL](https://github.com/innominata/BepInEx-Console-Extensions/blob/main/IL.png?raw=true)
![TranspileOutput](https://github.com/innominata/BepInEx-Console-Extensions/blob/main/Transpile.png?raw=true)
