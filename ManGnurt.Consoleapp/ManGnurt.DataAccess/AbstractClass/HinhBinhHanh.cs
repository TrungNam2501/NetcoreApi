using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.AbstractClass
{
    public class HinhBinhHanh : HinhHoc
    {
        public double CanhDay { get; set; }
        public double ChieuCao { get; set; }
        public HinhBinhHanh(double canhDay, double chieuCao)
        {
            CanhDay = canhDay;
            ChieuCao = chieuCao;
        }
        public override double TinhChuVi()
        {
            return 2 * (CanhDay + ChieuCao);
        }
        public override double TinhDienTich()
        {
            return CanhDay * ChieuCao;
        }
    }
}
