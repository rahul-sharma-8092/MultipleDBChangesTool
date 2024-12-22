using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultipleDBChangesTool
{
    public partial class ExecuteScript : System.Web.UI.Page
    {
        string ScriptId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ScriptId"] != null)
            {
                ScriptId = Convert.ToString(Request.QueryString["ScriptId"]);
            }

            if (!Page.IsPostBack)
            {
                FillDetails();
            }
        }

        protected void btnTestConn_Click(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            sql.ServerName = txtServerName.Text;
            sql.Authentication = ddlAuthentication.SelectedValue;
            sql.UserName = txtLogin.Text;
            sql.Password = txtPassword.Text;

            sql.IsAuthenticated = new BAL.ScriptsMgt().TestConnection(sql);
            if (sql.IsAuthenticated)
            {
                
            }
        }

        private void FillDetails()
        {
            if (!string.IsNullOrEmpty(ScriptId))
            {
                Scripts script = new BAL.ScriptsMgt().GetScriptFileByID(Convert.ToInt32(ScriptId));
                if (script != null)
                {
                    hdnScriptID.Value = ScriptId;
                    txtScriptName.Text = hdnName.Value = script.Name;
                    hdnPhysicalPath.Value = script.PhySicalPath;
                    hdnServerPath.Value = script.ServerPath;
                }
            }
        }
    }
}