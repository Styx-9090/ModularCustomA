using ModularSkillScripts;
using System;

namespace MTCustomScripts.Consequences;

public class ConsequenceAddSkillAbility : IModularConsequence
{
    public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
    {
       /*
        * var_1: target
        * var_2: skill-target
        * var_3: className
        * var_4: scriptName
        * var_5: turnLimit
        */

        BattleUnitModel target = modular.GetTargetModel(circles[0]);
        if (target == null) return;

        SkillModel skill = modular.GetSingleSkillModel(target, circles[1]);
        if (skill == null) return;

        string skillScriptName = circles[2];
        skillScriptName = $"SkillAbility_{skillScriptName}";
        try
        {
            SkillAbility newSkillAbility = (SkillAbility)Activator.CreateInstance(typeof(SkillAbility).Assembly.GetType(skillScriptName));
            skill._skillAbilityList.Add(newSkillAbility);
            newSkillAbility.Init(skill, circles[3], 0, skill.SkillAbilityList.Count, modular.GetNumFromParamString(circles[4]), null);
        }
        catch (Exception msg)
        {
            MTCustomScripts.Main.Logger.LogError($"Couldn't add skill script '{skillScriptName}': {msg}");
        }
    }
}