using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mm.DomainModel;
using Mm.DataAccessLayer;

namespace Mm.BusinessLayer
{
    public class BusinessLayer:IBusinessLayer
    {
        private readonly ILoaiNhanVienRepository _loainvRepository;
        private readonly INhanVienRepository _nvRepository;

        public BusinessLayer()
        {
            _loainvRepository = new LoaiNhanVienRepository();
            _nvRepository = new NhanVienRepository();
        }


        public IList<DomainModel.LoaiNhanVien> GetAllLoaiNhanVien()
        {
            return _loainvRepository.GetAll();
        }

        public DomainModel.LoaiNhanVien GetTenLoaiNhanVien(string name)
        {
            return _loainvRepository.GetSingle(d => d.TenLoaiNhanVien.Equals(name), d => d.NhanViens);
        }

        public void AddLoaiNhanVien(params DomainModel.LoaiNhanVien[] loainhanviens)
        {
            _loainvRepository.add(loainhanviens);
        }

        public void UpdateLoaiNhanVien(params DomainModel.LoaiNhanVien[] loainhanviens)
        {
            _loainvRepository.update(loainhanviens);
        }

        public void RemoveLoaiNhanVien(params DomainModel.LoaiNhanVien[] loainhanviens)
        {
            _loainvRepository.remove(loainhanviens);
        }

        public IList<DomainModel.NhanVien> GetNhanVienTheoTenLoaiNhanVien(string tenloainv)
        {
            return _nvRepository.GetList(d => d.LoaiNhanVien.TenLoaiNhanVien.Equals(tenloainv));
        }

        public void AddNhanVien(params DomainModel.NhanVien[] nhanviens)
        {
            _nvRepository.add(nhanviens);
        }

        public void UpdateNhanVien(params DomainModel.NhanVien[] nhanviens)
        {
            _nvRepository.update(nhanviens);
        }

        public void RemoveNhanVien(params DomainModel.NhanVien[] nhanviens)
        {
            _nvRepository.remove(nhanviens);
        }
    }
}
