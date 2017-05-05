using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mm.DataAccessLayer;
using Mm.DomainModel;

namespace Mm.BusinessLayer
{
    public interface IBusinessLayer
    {
        // Loại nhân viên
        IList<LoaiNhanVien> GetAllLoaiNhanVien();
        LoaiNhanVien GetTenLoaiNhanVien(string name);
        void AddLoaiNhanVien(params LoaiNhanVien[] loainhanviens);
        void UpdateLoaiNhanVien(params LoaiNhanVien[] loainhanviens);
        void RemoveLoaiNhanVien(params LoaiNhanVien[] loainhanviens);

        // Nhân viên
        IList<NhanVien> GetNhanVienTheoTenLoaiNhanVien(string nhanvien);
        void AddNhanVien(params NhanVien[] nhanviens);
        void UpdateNhanVien(params NhanVien[] nhanviens);
        void RemoveNhanVien(params NhanVien[] nhanviens);
    }
}
