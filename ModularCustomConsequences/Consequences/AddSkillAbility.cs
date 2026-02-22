using ModularSkillScripts;
using System;

namespace MTCustomScripts.Consequences;

public class ConsequenceAddSkillAbility : IModularConsequence
{
    public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
    {
        SkillModel skill = modular.modsa_skillModel;
        if (circles[0] != "Self") skill = modular.modsa_oppoAction.Skill;
        if (skill == null) return;
        string skillScriptName = circles[1];
        skillScriptName = $"SkillAbility_{skillScriptName}";
        try
        {
            SkillAbility newSkillAbility = (SkillAbility)Activator.CreateInstance(typeof(SkillAbility).Assembly.GetType(skillScriptName));
            skill._skillAbilityList.Add(newSkillAbility);
        }
        catch (Exception msg)
        {
            MTCustomScripts.Main.Logger.LogError($"Couldn't add skill script '{skillScriptName}': {msg}");
        }
    }
}