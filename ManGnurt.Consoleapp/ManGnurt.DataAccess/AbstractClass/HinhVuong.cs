using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.AbstractClass
{
    public class HinhVuong:HinhHoc
    {
        public double Canh { get; set; }
        public HinhVuong(double canh)
        {
            Canh = canh;
        }
        public override double TinhDienTich()
        {
            return Canh * Canh;
        }
        public override double TinhChuVi()
        {
            return 4 * Canh;
        }
    }
}
