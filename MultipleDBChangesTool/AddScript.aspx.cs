using BAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultipleDBChangesTool
{
	public partial class AddScript : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnUploadBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!(FileUpload1.HasFile && FileUpload1.FileName.Split('.')[1].ToLower() == "sql"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptKey", "alert('Please select a valid SQL file.');", true);
                    return;
                }

                Scripts scripts = new Scripts();
                scripts.Name = FileUpload1.FileName;
                scripts.PhySicalPath = CommonFunc.UploadFile(FileUpload1.PostedFile);
                scripts.ServerPath = Path.Combine(ConfigurationManager.AppSettings["ScriptUploadPath"], FileUpload1.FileName);
                scripts.Query = File.ReadAllText(scripts.PhySicalPath);

                int result = new ScriptsMgt().AddScriptFile(scripts);
                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptKey", "alert('Script Added Successfully');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "scriptKey", "alert('Something went wrong.');", true);
                }
            }
        }
    }
}