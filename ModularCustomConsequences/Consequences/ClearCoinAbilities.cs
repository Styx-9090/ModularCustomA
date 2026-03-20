using ModularSkillScripts;
using System.Linq;
using System;

namespace MTCustomScripts.Consequences;

public class ConsequenceClearCoinAbilities : IModularConsequence
{
	public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
    {
        SkillModel skill = modular.modsa_skillModel;
        if (circles[0] != "Self") skill = modular.modsa_oppoAction.Skill;
        if (skill == null) return;
        if (circles.Length > 1)
        {
            foreach (string circle in circles.Skip(1))
            {
                int idx = modular.GetNumFromParamString(circle);
                if (idx < 0)
                {
                    modular.modsa_coinModel._coinAbilityList.Clear();
                    continue;
                }
                idx = Math.Min(idx, skill.CoinList.Count - 1);
                skill.GetCoinByIndex(idx)._coinAbilityList.Clear();
            }
            return;
        }
        foreach (CoinModel cm in skill.CoinList)
        {
            cm._coinAbilityList.Clear();
        }
    }
}