using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCustomScripts.MiscClasses
{
    public class MTModData(string dataID, object dataValue)
    {
        public string dataID = dataID;
        public object dataValue = dataValue;

        public System.Type dataType;
        public string dataSource;
    }
}
