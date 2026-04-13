using ManGnurt.DataAccess.Struct;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess
{
    public class Employeer_Manager
    {
        List<ManGnurt.DataAccess.Struct.Employeer> empl = new List<Struct.Employeer>();
        public int Employeer_Insert(string EmpLoyeerCodeInput, string EmpLoyeerNameInput, DateTime StartDateInput)
        {
            var ketqua = 0;
            try
            {
                //Bước 1 : Kiểm tra dữ liệu đầu vào 
                if (!ManGnurt.Common.ValidatorInput.IsValidString(EmpLoyeerCodeInput)
                    || !ManGnurt.Common.ValidatorInput.IsSafeFromXSS(EmpLoyeerCodeInput))
                {
                    ketqua = (int)EmployeerManager_Status.MA_NHAN_VIEN_KHONG_HOP_LE;
                    return ketqua;
                }
                if (!ManGnurt.Common.ValidatorInput.IsValidString(EmpLoyeerNameInput)
                     || !ManGnurt.Common.ValidatorInput.IsSafeFromXSS(EmpLoyeerNameInput))
                {
                    ketqua = (int)EmployeerManager_Status.TEN_KHONG_HOP_LE;
                    return ketqua;
                }
                // Bước 2: Check trùng trong List chưa
                //C1
                var isDuplicate = false;
                for (int i = 0; i < empl.Count; i++)
                {
                    if (empl[i].EmployeerCode == EmpLoyeerCodeInput)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (isDuplicate)
                {
                    ketqua = (int)EmployeerManager_Status.DA_TON_TAI;
                }
                //C2
                //var isdup = empl.FindAll(s => s.EmployeerCode == EmpLoyeerCodeInput).FirstOrDefault();
                //if (isdup.EmployeerCode != null)
                //{
                //    ketqua = (int)EmployeerManager_Status.DA_TON_TAI;
                //}
                var new_emp = new Employeer();
                new_emp.EmployeerCode = EmpLoyeerCodeInput;
                new_emp.EmployeerName = EmpLoyeerNameInput;
                new_emp.StartDate = StartDateInput;


                empl.Add(new_emp);
                ketqua = (int)EmployeerManager_Status.THANH_CONG;
                return ketqua;

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ngoại lệ ?:" + ex.Message);
            }
            return ketqua;
        }
        public string Employeer_Insert_FromExcelFile(string filePath)
        {
            var ketqua = string.Empty;
            var errName = new StringBuilder();
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("trunnam");
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {

                        var code = worksheet.Cells[row, 1].Text;
                        var name = worksheet.Cells[row, 2].Text;
                        var startDate = worksheet.Cells[row, 3].Text;

                        if (!ManGnurt.Common.ValidatorInput.IsValidString(code)
                    || !ManGnurt.Common.ValidatorInput.IsSafeFromXSS(code)
                    )
                        {
                            errName.Append("Hàng : " + row + "| Cột 0 dữ liệu không hợp lệ");
                            continue;
                        }
                        if (!ManGnurt.Common.ValidatorInput.IsValidString(name)
                 || !ManGnurt.Common.ValidatorInput.IsSafeFromXSS(name)
                 )
                        {
                            errName.Append("Hàng : " + row + "| Cột 1 dữ liệu không hợp lệ");
                            continue;
                        }
                    }

                    Console.WriteLine();
                }

                if (errName != null)
                {
                    return errName.ToString();
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ketqua;
        }

    }
}
