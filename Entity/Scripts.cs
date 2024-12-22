using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entity
{
    public class Scripts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhySicalPath { get; set; }
        public string ServerPath { get; set; }
        public string Query { get; set; }
        public string CreatedBY { get; set; }
        public string CreatedAT { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SqlServer
    {
        public string ServerName { get; set; }
        public string Authentication { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
