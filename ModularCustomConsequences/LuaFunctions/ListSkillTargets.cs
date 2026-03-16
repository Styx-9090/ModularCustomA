using ModularSkillScripts;
using ModularSkillScripts.LuaFunction;
using System.Threading;
using System.Threading.Tasks;
using Lua;

namespace MTCustomScripts.LuaFunctions;

public class LuaFunctionListSkillTargets : IModularLuaFunction
{
    public ValueTask<int> ExecuteLuaFunction(ModularSA modular, LuaFunctionExecutionContext context, System.Span<LuaValue> buffer, CancellationToken ct)
    {
        if (modular.modsa_selfAction == null) return ValueTask.FromResult(0);
        
        LuaTable table = new LuaTable();
        table[1] = $"inst{modular.modsa_selfAction._targetDataDetail.GetCurrentTargetSet()._mainTarget.GetTargetUnit().InstanceID}";
        int i = 2;
        foreach(TargetSinActionData tsad in modular.modsa_selfAction._targetDataDetail.GetCurrentTargetSet()._subTargetList)
        {
            table[i] = $"inst{tsad.GetTargetUnit().InstanceID}";
            i++;
        }
        buffer[0] = table;
        return ValueTask.FromResult(1);
    }
}