using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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

        public List<ListItem> GetAllDataBase(SqlServer sqlServer)
        {
            return new DAL.ScriptsSQL().GetAllDataBase(sqlServer);
        }

        public int ExecuteScript(SqlServer sqlServer, string script)
        {
            return new DAL.ScriptsSQL().ExecuteScript(sqlServer, script);
        }
    }
}
