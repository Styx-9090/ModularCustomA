using HarmonyLib;
using ModularSkillScripts;

namespace MTCustomScripts.Patches;

internal class RecoverSwitchPanic
{
    [HarmonyPatch(typeof(BattleUnitModel), nameof(BattleUnitModel.OnRecoverBreak))]
    [HarmonyPostfix, HarmonyPriority(Priority.VeryHigh)]
    public static void BattleUnitModel_OnRecoverBreak_Postfix(BATTLE_EVENT_TIMING timing, BattleUnitModel __instance)
    {
        int actevent = MainClass.timingDict["OnRecoverBreak"];
        int actevent_other = MainClass.timingDict["OnOtherRecoverBreak"];

        StyxUtils.GenericModularPatches(__instance, actevent, actevent_other, timing);
    }

    //--------------------------------------------------------------------------------------------------------------------//
    //--------------------------------------------------------------------------------------------------------------------//
    //--------------------------------------------------------------------------------------------------------------------//

    [HarmonyPatch(typeof(BattleUnitModel), nameof(BattleUnitModel.OnTakePiledUpVibrationToSpecial_Try))]
    [HarmonyPostfix, HarmonyPriority(Priority.VeryHigh)]
    public static void BattleUnitModel_OnTakePiledVibrationTry_Postfix(BattleUnitModel giverOrNull, BUFF_UNIQUE_KEYWORD originalKeyword, BUFF_UNIQUE_KEYWORD newKeyword, bool isSucceed, bool isTryToPileUp, BATTLE_EVENT_TIMING timing, BattleUnitModel __instance)
    {
        int actevent = MainClass.timingDict["OnTakePiledVibration"];
        int actevent_other = MainClass.timingDict["OnOtherTakePiledVibration"];

        StyxUtils.GenericModularPatches(__instance, actevent, actevent_other, timing, null, null, null, giverOrNull);
    }

    [HarmonyPatch(typeof(BattleUnitModel), nameof(BattleUnitModel.OnTakeSwitchingVibrationToSpecial_Try))]
    [HarmonyPostfix, HarmonyPriority(Priority.VeryHigh)]
    public static void BattleUnitModel_OnTakeSwitchingVibrationTry_Postfix(BattleUnitModel giverOrNull, BUFF_UNIQUE_KEYWORD originalKeyword, BUFF_UNIQUE_KEYWORD newKeyword, bool isSucceed, BATTLE_EVENT_TIMING timing, BattleUnitModel __instance)
    {
        int actevent = MainClass.timingDict["OnTakeSwitchingVibration"];
        int actevent_other = MainClass.timingDict["OnOtherTakeSwitchingVibration"];

        StyxUtils.GenericModularPatches(__instance, actevent, actevent_other, timing, null, null, null, giverOrNull);
    }

    //--------------------------------------------------------------------------------------------------------------------//
    //--------------------------------------------------------------------------------------------------------------------//
    //--------------------------------------------------------------------------------------------------------------------//

    [HarmonyPatch(typeof(BattleUnitModel), nameof(BattleUnitModel.OnPanicOrLowMorale))]
    [HarmonyPostfix, HarmonyPriority(Priority.VeryHigh)]
    public static void BattleUnitModel_OnPanicOrLowMorale_Postfix(PANIC_LEVEL level, BATTLE_EVENT_TIMING timing, BattleUnitModel __instance)
    {
        if (level == PANIC_LEVEL.None) return;

        int actevent = (level == PANIC_LEVEL.Panic) ? MainClass.timingDict["OnPanic"] : MainClass.timingDict["OnLowMorale"];
        int actevent_other = (level == PANIC_LEVEL.Panic) ? MainClass.timingDict["OnOtherPanic"] : MainClass.timingDict["OnOtherLowMorale"];

        StyxUtils.GenericModularPatches(__instance, actevent, actevent_other, timing);
    }
}

