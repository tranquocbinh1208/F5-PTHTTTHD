using System;

namespace Common
{
    public static class AppUtils
    {
        #region String format

        public static string GetTransactionID(LoaiGiaoDich loaiGd, DateTime date)
        {
            var gd = string.Empty;
            switch (loaiGd)
            {
                case LoaiGiaoDich.GuiTien:
                    gd = "GT";
                    break;
                case LoaiGiaoDich.RutTien:
                    gd = "RT";
                    break;
                case LoaiGiaoDich.ChuyenTien:
                    gd = "CT";
                    break;
                default:
                    gd = "STK";
                    break;
            }

            return $"GD{gd}{date.ToString("yyyy-MM-dd-HH-mm-ss")}";
        }

        public static string GetCurrencyFormat(decimal money)
        {
            return money.ToString("#,##0");
        }

        public static readonly string DateFormat_yyyy_mm_dd_hh_mm_ss = "yyyy-mm-dd, HH:mm:ss";
        #endregion
    }
}