using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mm.DomainModel;

namespace Mm.DataAccessLayer
{
    public interface ILoaiNhanVienRepository : IGenericDataRepository<LoaiNhanVien> { }
    public interface INhanVienRepository : IGenericDataRepository<NhanVien> { }
    public class LoaiNhanVienRepository : GenericDataRepository<LoaiNhanVien>, ILoaiNhanVienRepository { }
    public class NhanVienRepository : GenericDataRepository<NhanVien>, INhanVienRepository { }
}
