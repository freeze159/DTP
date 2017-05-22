using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WinFormProJect
{
    class MaTuDong
    {

        public static string matuDong(DataTable bang, string bieuThuc, int vitriSo)
        {
            string str = bang.Compute(bieuThuc, "").ToString();
            string strLeft = str.Substring(0, vitriSo);
            int so = int.Parse(str.Substring(vitriSo));
            so++;
            return strLeft + String.Format("{0:00000}", so);
        }
    }
}
