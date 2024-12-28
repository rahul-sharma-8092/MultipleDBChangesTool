using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAL
{
    public static class CommonFunc
    {
        static string ScriptUploadPath = ConfigurationManager.AppSettings["ScriptUploadPath"];

        static public string UploadFile(HttpPostedFile file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string uploadPath = HttpContext.Current.Server.MapPath(ScriptUploadPath);
                    
                    //Create directory if not exist.
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string path = Path.Combine(uploadPath, fileName);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    file.SaveAs(path);
                    return path;
                }
                return "";
            }
            catch (Exception ex)
            {
                AddLogToDB(ex);
                return "";
            }
        }

        public static void AddLogToDB(Exception ex, int logType = 1)
        {
            LogTable log = new LogTable();
            log.LogType = logType;
            log.Message = ex.Message;
            log.StackTrace = ex.StackTrace;
            log.InnerException = ex.InnerException != null ? ex.InnerException.Message : "";
            CommonSQL.AddLogToDB(log);
        }
    }
}
