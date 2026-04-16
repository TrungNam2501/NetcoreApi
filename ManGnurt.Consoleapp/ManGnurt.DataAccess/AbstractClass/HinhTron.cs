using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.AbstractClass
{
    public class HinhTron: HinhHoc
    {
        public double BanKinh { get; set; }
        public HinhTron(double banKinh)
        {
            BanKinh = banKinh;
        }
        public override double TinhDienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }
        public override double TinhChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }
    }
}
