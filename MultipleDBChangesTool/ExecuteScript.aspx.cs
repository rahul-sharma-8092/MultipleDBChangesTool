using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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
                //string script = System.IO.File.ReadAllText(hdnPhysicalPath.Value);
                divListDB.Visible = btnExecuteScript.Enabled = true;
                List<ListItem> DBName = new BAL.ScriptsMgt().GetAllDataBase(sql);
                chkDatabaseList.DataSource = DBName;
                chkDatabaseList.DataTextField = "Text";
                chkDatabaseList.DataValueField = "Value";
                chkDatabaseList.DataBind();
            }
            else
            {
                divListDB.Visible = btnExecuteScript.Enabled = false;
                chkDatabaseList.DataSource = new List<ListItem>();
                chkDatabaseList.DataTextField = "Text";
                chkDatabaseList.DataValueField = "Value";
                chkDatabaseList.DataBind();
                ClientScript.RegisterStartupScript(this.GetType(), "connTest", "alert('Something went wrong. Please check creditinals.');", true);
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

        protected void btnExecuteScript_Click(object sender, EventArgs e)
        {
            List<string> result = null;
            List<SqlServer> allDB = new List<SqlServer>();
            string script = System.IO.File.ReadAllText(hdnPhysicalPath.Value).Trim();

            chkDatabaseList.Items.Cast<ListItem>().Where(i => i.Selected).ToList().ForEach(x =>
            {
                SqlServer sql = new SqlServer();
                sql.ServerName = txtServerName.Text;
                sql.Authentication = ddlAuthentication.SelectedValue;
                sql.UserName = sql.Password = x.Value.Split('_')[0];
                sql.DataBaseName = x.Value.Contains("MultipleDBChangesTool") ? "MultipleDBChangesTool" : x.Value;

                allDB.Add(sql);
            });

            if (!string.IsNullOrEmpty(script) && allDB.Count > 0)
            {
                result = new BAL.ScriptsMgt().ExecuteScript(allDB, script);
                if (result != null && result.Count == 0)
                {
                   ClientScript.RegisterStartupScript(this.GetType(), "scriptExec", "alert('Script executed successfully in all Selected DB.');", true);
                }
                else if(result != null && result.Count > 0)
                {
                    string dbName = "";
                    result.ForEach(x =>
                    {
                        string xxx = Regex.Replace(x, @"[\n\r\t]", " ");
                        dbName += xxx != null ? xxx + "\\n" : "";
                    });
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptExecFail", "alert('Script " + dbName + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "InternalError", "alert('Something went wrong.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "DBNotSelected", "alert('Please select atleast one DB.');", true);
            }
        }
    }
}