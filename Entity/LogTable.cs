using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LogTable
    {
        public int LogID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public int LogType { get; set; }
        public string CreatedBY { get; set; }
        public bool IsDeleted { get; set; }
    }
}
