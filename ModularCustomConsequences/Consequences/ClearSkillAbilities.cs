using ModularSkillScripts;

namespace MTCustomScripts.Consequences;

public class ConsequenceClearSkillAbilities : IModularConsequence
{
	public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
    {
        SkillModel skill = modular.modsa_skillModel;
        if (circles[0] != "Self") skill = modular.modsa_oppoAction.Skill;
        if (skill == null) return;
        skill._skillAbilityList.Clear();
    }
}