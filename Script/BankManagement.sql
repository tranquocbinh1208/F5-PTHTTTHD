USE [master]

CREATE DATABASE [BankManagerment]

CREATE TABLE [dbo].[GiaoDichChuyenTien](
	[MaGD] [varchar](15) NOT NULL,
	[MaKHGoi] [varchar](15) NOT NULL,
	[MaKHNhan] [varchar](15) NOT NULL,
	[SoTien] [money] NOT NULL,
	[NoiDung] [nvarchar](200) NULL,
	[MaNV] [varchar](15) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_GiaoDichChuyenTien] PRIMARY KEY CLUSTERED 
(
	[MaGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[GiaoDichGoiTien](
	[MaGD] [varchar](15) NOT NULL,
	[HoTenNguoiGoi] [nvarchar](100) NOT NULL,
	[CMND] [varchar](15) NOT NULL,
	[NgayCapCMND] [date] NOT NULL,
	[NoiCapCMND] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[SDT] [varchar](15) NULL,
	[SoTien] [money] NOT NULL,
	[NoiDung] [nvarchar](200) NULL,
	[MaKHNhan] [varchar](15) NOT NULL,
	[MaNV] [varchar](15) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_GiaoDichGoiTien] PRIMARY KEY CLUSTERED 
(
	[MaGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[GiaoDichGoiTienTietKiem](
	[MaGD] [varchar](15) NOT NULL,
	[MaKH] [varchar](15) NOT NULL,
	[SoTien] [money] NOT NULL,
	[LaiSuat] [float] NOT NULL,
	[KyHan] [int] NOT NULL,
	[MaNV] [varchar](15) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_GiaoDichGoiTienTietKiem] PRIMARY KEY CLUSTERED 
(
	[MaGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[GiaoDichRutTien](
	[MaGD] [varchar](15) NOT NULL,
	[MaKH] [varchar](15) NOT NULL,
	[SoTien] [money] NOT NULL,
	[NoiDung] [nvarchar](200) NULL,
	[MaNV] [varchar](15) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_GiaoDichRutTien] PRIMARY KEY CLUSTERED 
(
	[MaGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[KhachHang](
	[MaKH] [varchar](15) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[SDT] [varchar](15) NULL,
	[CMND] [varchar](15) NOT NULL,
	[NgayCapCMND] [date] NULL,
	[NoiCapCMND] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[Email] [varchar](50) NULL,
	[HinhChuKy] [nvarchar](200) NOT NULL,
	[MaNV] [varchar](15) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[NgayCapNhat] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNhanVien] [nvarchar](100) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[LoaiTruSo](
	[MaLoaiTruSo] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiTruSo] [nvarchar](100) NOT NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_LoaiTruSo] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTruSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](15) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[SDT] [varchar](15) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[CMND] [varchar](15) NOT NULL,
	[NgayCapCMND] [date] NULL,
	[NoiCapCMND] [nvarchar](100) NULL,
	[MaLoaiNhanVien] [int] NOT NULL,
	[MaTruSo] [int] NOT NULL,
	[NgayTao] [date] NOT NULL,
	[NgayCapNhat] [date] NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[SoTietKiem](
	[MaSoTietKiem] [varchar](15) NOT NULL,
	[MaKH] [varchar](15) NOT NULL,
	[SoTienGoi] [money] NOT NULL,
	[KyHan] [int] NOT NULL,
	[LaiSuat] [float] NOT NULL,
	[NgayGoi] [date] NOT NULL,
	[NgayDaoHan] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_SoTietKiem] PRIMARY KEY CLUSTERED 
(
	[MaSoTietKiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[TaiKhoan](
	[MaSoTaiKhoan] [varchar](15) NOT NULL,
	[MaKH] [varchar](15) NOT NULL,
	[SoDuThuc] [money] NOT NULL,
	[SoDuKhaDung] [money] NOT NULL,
	[NgayTao] [date] NOT NULL,
	[NgayHetHan] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaSoTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[TruSo](
	[MaTruSo] [int] IDENTITY(1,1) NOT NULL,
	[TenTruSo] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SDT] [varchar](15) NOT NULL,
	[Fax] [varchar](15) NOT NULL,
	[MaLoaiTruSo] [int] NOT NULL,
	[NgayTao] [date] NOT NULL,
	[NgayCapNhat] [date] NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_TruSo] PRIMARY KEY CLUSTERED 
(
	[MaTruSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
