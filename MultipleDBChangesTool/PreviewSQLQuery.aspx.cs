using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultipleDBChangesTool
{
    public partial class PreviewSQLQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = "";
            if (Request.QueryString["fileName"] != null)
            {
                fileName = Request.QueryString["fileName"];
            }

            if (string.IsNullOrEmpty(fileName))
            {
                ShowError("File name not provided.");
                return;
            }

            string filePath = Server.MapPath($"~/Documents/{fileName}");

            if (!File.Exists(filePath))
            {
                ShowError("File not found.");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                string escapedContent = HttpUtility.HtmlEncode(fileContent);

                ClientScript.RegisterStartupScript(this.GetType(), "SetSQLContent", $@"
                    document.getElementById('sqlContent').textContent = `{escapedContent}`;
                ", true);
            }
            catch (Exception ex)
            {
                ShowError("An error occurred while reading the file: " + ex.Message);
            }
        }

        private void ShowError(string message)
        {
            Response.Write($"<h2>{message}</h2><button onclick='window.close()'>Close</button>");
            Response.End();
        }
    }
}