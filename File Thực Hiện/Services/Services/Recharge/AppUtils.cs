using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recharge
{
    public static class AppUtils
    {
        #region String format

        public static string GetTransactionID(DateTime date)
        {
            return $"GD{date.ToString("yyyy-MM-dd-HH-mm-ss")}";
        }

        public static string GetCurrencyFormat(decimal money)
        {
            return money.ToString("#,##0");
        }

        #endregion
    }
}
