using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ScriptsMgt
    {
        public int AddScriptFile(Scripts scripts)
        {
            return new DAL.ScriptsSQL().AddScriptFile(scripts);
        }

        public Scripts GetScriptFileByID(int ID)
        {
            return new DAL.ScriptsSQL().GetScriptFileByID(ID);
        }

        public List<Scripts> GetAllScriptFile()
        {
            return new DAL.ScriptsSQL().GetAllScriptFile();
        }

        public int DeleteScriptFile(int ID)
        {
            return new DAL.ScriptsSQL().DeleteScriptFile(ID);
        }

        public bool TestConnection(SqlServer sqlServer)
        {
            return new DAL.ScriptsSQL().TestConnection(sqlServer);
        }
    }
}
