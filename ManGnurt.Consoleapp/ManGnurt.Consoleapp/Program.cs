using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGnurt.DataAccess;
using ManGnurt.DataAccess.Struct;

namespace ManGnurt.Consoleapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeerManager = new Employeer_Manager();

            //var result = employeerManager.Employeer_Insert("<asas>", "MR QUÂN", DateTime.Now);

            //switch (result)
            //{
            //    case (int)EmployeerManager_Status.THANH_CONG:
            //        Console.WriteLine("Thêm thành công!");

            //        break;

            //    case (int)EmployeerManager_Status.MA_NHAN_VIEN_KHONG_HOP_LE:
            //        Console.WriteLine("Mã nhân viên không hợp lê!");

            //        break;

            //    case (int)EmployeerManager_Status.TEN_KHONG_HOP_LE:
            //        Console.WriteLine("Tên nhân viên không hợp lê!");

            //        break;
            //}


            var path = "C:\\Users\\tnamit\\Desktop\\Book1.xlsx";
            var rs = employeerManager.Employeer_Insert_FromExcelFile(path);
            Console.WriteLine(rs);
           }
    }
}
