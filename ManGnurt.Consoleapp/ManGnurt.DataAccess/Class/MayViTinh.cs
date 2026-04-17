using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Class
{
    public  class MayViTinh //Class Cha
    {
        public string TenMay { get; set; }
        public int ChieuDai { get; set; }
        public int ChieuRong { get; set; }
        public void UpRam()
        {
            Console.WriteLine("Up Ram");
        }
         public void UpRom()
        {
            Console.WriteLine("Up Rom");
        }
    }
}
