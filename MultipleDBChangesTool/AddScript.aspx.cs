﻿using System;
using System.Collections.Generic;
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
                if (!FileUpload1.HasFile)
                {
                    return;
                }
                 
            }
        }
    }
}