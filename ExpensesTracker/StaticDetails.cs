using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses_Tracker
{
    public static class StaticDetails
    {
        public static string APIBaseURL = "https://localhost:44325/";
        public static string GastoAPIPath = APIBaseURL + "api/gastos/";
        public static string AuthAPIPath = APIBaseURL + "api/auth/";

        // To be implemented
        public static string CuotaAPIPath = APIBaseURL + "";
    }
}
