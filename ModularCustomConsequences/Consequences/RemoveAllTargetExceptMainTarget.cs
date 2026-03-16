using ModularSkillScripts;

namespace MTCustomScripts.Consequences;

public class ConsequenceRemoveAllTargetExceptMainTarget : IModularConsequence
{
    public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
    {
        if (modular.modsa_selfAction == null) return;
        modular.modsa_selfAction.RemoveAllTargetExceptMainTarget();
    }
}