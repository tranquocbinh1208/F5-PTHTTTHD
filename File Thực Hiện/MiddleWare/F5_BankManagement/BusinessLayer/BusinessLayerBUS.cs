using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessLayerBUS
    {
        private readonly ILoaiNhanVienRepository _loainhanvienRepository;
        public BusinessLayerBUS()
        {
            _loainhanvienRepository = new LoaiNhanVienRepository();
        }
        public List<LoaiNhanVien> GetAllLoaiNhanVien()
        {
            return _loainhanvienRepository.GetAll().ToList();
        }
    }
}
