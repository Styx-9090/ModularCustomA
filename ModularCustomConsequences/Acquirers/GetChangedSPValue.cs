using ModularSkillScripts;
using System;
using System.Collections.Generic;

namespace MTCustomScripts.Acquirers
{
    internal class AcquirerGetChangedSPValue : IModularAcquirer
    {
        public int ExecuteAcquirer(ModularSA modular, string section, string circledSection, string[] circles)
        {
            /*
             * var_1 = target
             * var_2 = oldsp/newsp
             */

            if (circles.Length < 2) return -1;

            BattleUnitModel unit = modular.GetTargetModel(circles[0]);
            if (unit == null || !Main.Instance.changeMpDict.TryGetValue(unit, out int[] spArray)) return -1;

            switch (circles[1].ToLower())
            {
                case "oldsp":
                    return spArray[0];
                case "newsp":
                    return spArray[1];
            }

            return -1;
        }
    }
}
