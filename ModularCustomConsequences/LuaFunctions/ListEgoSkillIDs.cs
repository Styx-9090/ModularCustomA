using ModularSkillScripts;
using ModularSkillScripts.LuaFunction;
using System.Threading;
using System.Threading.Tasks;
using Lua;
using System.Collections.Generic;

namespace MTCustomScripts.LuaFunctions;

public class LuaFunctionListEgoSkillIDs : IModularLuaFunction
{
    public ValueTask<int> ExecuteLuaFunction(ModularSA modular, LuaFunctionExecutionContext context, System.Span<LuaValue> buffer, CancellationToken ct)
    {
        BattleUnitModel target = modular.GetTargetModel(context.GetArgument(0).Read<string>());
        if (target == null) return ValueTask.FromResult(0);

        var tempDict = new Dictionary<string, List<int[]>>();
        foreach(BattleEgoModel battleEgoModel in target._erosionData._egoList)
        {
            string egoType = battleEgoModel.GetEgoType().ToString();
            int[] skillIdPair = new int[] {battleEgoModel.GetAwakeningSkillID(), battleEgoModel.GetCorrosionSkillID()};

            if (!tempDict.TryGetValue(egoType, out List<int[]> listn))
            {
                listn = new List<int[]>();
                tempDict[egoType] = listn;
            }
            listn.Add(skillIdPair);
        }

        LuaTable table = new LuaTable();
        foreach(var elem in tempDict)
        {
            string key = elem.Key;
            List<int[]> pairs = elem.Value;

            LuaTable newList = new LuaTable();

            for (int i = 0; i < pairs.Count; i++)
            {
                LuaTable pair = new LuaTable();
                pair[1] = pairs[i][0];
                pair[2] = pairs[i][1];

                newList[i + 1] = pair;
            }

            table[key] = newList;
        }

        buffer[0] = table;
        return ValueTask.FromResult(1);
    }
}