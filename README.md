Simple mod to allow easy use of custom colours in the console by other BepInEx mods

Manual Installation:

 1. Install BepInEx
 2. Copy the BCE.dll to your BepInEx/plugins directory




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
...

![IL](/IL.png)
![TranspileOutput]/Transpile.png)
