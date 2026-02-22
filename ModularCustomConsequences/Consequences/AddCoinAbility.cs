using ModularSkillScripts;
using System;
using System.Linq;

namespace MTCustomScripts.Consequences;

public class ConsequenceAddCoinAbility : IModularConsequence
{
    public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
    {
        SkillModel skill = modular.modsa_skillModel;
        if (circles[0] != "Self") skill = modular.modsa_oppoAction.Skill;
        if (skill == null) return;
        string coinScriptName = circles[1];
        coinScriptName = $"CoinAbility_{coinScriptName}";
        try
        {
            if (circles.Length > 2)
            {
                foreach (string circle in circles.Skip(2))
                {
                    CoinAbility newCoinAbility = (CoinAbility)Activator.CreateInstance(typeof(CoinAbility).Assembly.GetType(coinScriptName));
                    int idx = modular.GetNumFromParamString(circle);
                    if (idx < 0)
                    {
                        modular.modsa_coinModel._coinAbilityList.Add(newCoinAbility);
                        continue;
                    }
                    idx = Math.Min(idx, modular.modsa_skillModel.CoinList.Count - 1);
                    modular.modsa_skillModel.GetCoinByIndex(idx)._coinAbilityList.Add(newCoinAbility);
                }
                return;
            }
            foreach(CoinModel CM in modular.modsa_skillModel._coinList)
            {
                CoinAbility newCoinAbility = (CoinAbility)Activator.CreateInstance(typeof(CoinAbility).Assembly.GetType(coinScriptName));
                CM._coinAbilityList.Add(newCoinAbility);
            }
        }
        catch (Exception msg)
        {
            MTCustomScripts.Main.Logger.LogError($"Couldn't add coin script '{coinScriptName}': {msg}");
        }
    }
}