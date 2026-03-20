using ModularSkillScripts;

namespace MTCustomScripts.Consequences;

public class ConsequenceSetMainTarget : IModularConsequence
{
    public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
    {
        if (modular.modsa_selfAction == null) return;
        BattleUnitModel target = modular.GetTargetModel(circles[0]);
        if (target == null) return;
        Il2CppSystem.Collections.Generic.List<SinActionModel> actionList = Singleton<SinManager>.Instance.GetActionListByUnit(target);
        if (actionList.Count < 1) return;
        modular.modsa_selfAction._targetDataDetail.GetCurrentTargetSet()._mainTarget = new TargetSinActionData(actionList[0]);
    }
}