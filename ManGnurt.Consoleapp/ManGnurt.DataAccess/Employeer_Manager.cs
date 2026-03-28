using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess
{
     public static class Employeer_Manager
    {
        public static int Employeer_Insert(string EmpLoyeerCode, string EmpLoyeerName, DateTime StartDate)
        {
            var ketqua = 0;
            try
            {
                if (ManGnurt.Common.ValidatorInput.IsValidString(EmpLoyeerCode))
                {

                }
                    

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ketqua;
        }
    }
}
