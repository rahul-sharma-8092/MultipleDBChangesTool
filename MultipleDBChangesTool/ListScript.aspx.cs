using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultipleDBChangesTool
{
    public partial class ListScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            List<Scripts> lstScript = new BAL.ScriptsMgt().GetAllScriptFile();

            if (lstScript != null)
            {
                rptScripts.DataSource = lstScript;
                rptScripts.DataBind();
            }

        }

        protected void rptScripts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteScript")
            {
                string[] arguments = e.CommandArgument.ToString().Split('|');
                int ID = Convert.ToInt32(arguments[0]);
                string PhysicalFilePath = arguments[1];
                int result = new BAL.ScriptsMgt().DeleteScriptFile(ID);
                if (result > 0)
                {
                    if (File.Exists(PhysicalFilePath))
                    {
                        File.Delete(PhysicalFilePath);
                    }
                    BindRepeater();
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptKey", "alert('Script Deleted Successfully');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptKey", "alert('Something went wrong.');", true);
                }
            }
            else if(e.CommandName == "ExecuteScript")
            {
                string ScriptId = e.CommandArgument.ToString();
                Response.Redirect("ExecuteScript.aspx?ScriptId=" + ScriptId);
            }
        }
    }
}