using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WinFormProJect
{
    class GetData
    {
        public string name { set; get; }
        public string money { set; get; }
        public GetData()
        { }
        public GetData(string name, string money)
        {
            this.name = name;
            this.money = money;
        }
     
    }
}
