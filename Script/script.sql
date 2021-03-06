USE [master]
GO
/****** Object:  Database [BankManagement]    Script Date: 3/19/2017 4:08:02 PM ******/
CREATE DATABASE [BankManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BankManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BankManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BankManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BankManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BankManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BankManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BankManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BankManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BankManagement]
GO
/****** Object:  Table [dbo].[GiaoDichCapNhatTaiKhoan]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoDichCapNhatTaiKhoan](
	[MaGiaoDich] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[HoVaTen] [nchar](10) NULL,
	[NgaySinh] [datetime] NULL,
	[CMND] [nvarchar](50) NULL,
	[NoiSinh] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[QuocTich] [nvarchar](50) NULL,
	[DiaChiThuongTru] [nvarchar](250) NULL,
	[DiaChiLienLac] [nvarchar](250) NULL,
	[DienThoaiBan] [nvarchar](50) NULL,
	[DTDD] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[TinhTrangHonNhan] [nvarchar](50) NULL,
	[TinhTrangNgheNghiep] [nvarchar](50) NULL,
	[HinhChuKy] [nvarchar](250) NULL,
	[GiaoDichVien] [int] NULL,
 CONSTRAINT [PK_GiaoDichCapNhatTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaGiaoDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiaoDichChuyenTien]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoDichChuyenTien](
	[MaGiaoDich] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[HoTenNguoiNhan] [nvarchar](50) NULL,
	[DiaChiNguoiNhan] [nvarchar](250) NULL,
	[SDTNguoiNhan] [nvarchar](50) NULL,
	[CMNDNguoiNhan] [nvarchar](50) NULL,
	[SoTienCanChuyen] [money] NULL,
	[NoiDung] [nvarchar](250) NULL,
	[NgayGiaoDich] [datetime] NULL,
	[GiaoDichVien] [int] NULL,
 CONSTRAINT [PK_GiaoDichChuyenTien] PRIMARY KEY CLUSTERED 
(
	[MaGiaoDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiaoDichLapSoTietKiem]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoDichLapSoTietKiem](
	[MaGiaoDich] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[SoTienGui] [money] NULL,
	[KyHan] [int] NULL,
	[LaiSuat] [float] NULL,
	[NgayGiaoDich] [datetime] NULL,
	[GiaoDichVien] [int] NULL,
 CONSTRAINT [PK_GiaoDichLapSoTietKiem] PRIMARY KEY CLUSTERED 
(
	[MaGiaoDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[NoiSinh] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[CMND] [nvarchar](50) NULL,
	[NgayCap] [datetime] NULL,
	[NoiCap] [nvarchar](50) NULL,
	[QuocTich] [nvarchar](50) NULL,
	[DiaChiThuongTru] [nvarchar](250) NULL,
	[DiaChiLienLac] [nvarchar](250) NULL,
	[DienThoaiBan] [nvarchar](50) NULL,
	[DTDD] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[TinhTrangHonNhan] [nvarchar](50) NULL,
	[TinhTrangNgheNghiep] [nvarchar](50) NULL,
	[HinhChuKy] [nvarchar](250) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNhanVien] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTruSo]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTruSo](
	[MaLoaiTruSo] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiTruSo] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiTruSo] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTruSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[CMND] [nvarchar](50) NULL,
	[NgayCap] [datetime] NULL,
	[NoiCap] [nvarchar](50) NULL,
	[TruSo] [int] NULL,
	[MaLoaiNhanVien] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoanTienGuiThanhToan]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanTienGuiThanhToan](
	[MaSoTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[SoDuThuc] [money] NULL,
	[SoDuKhaDung] [money] NULL,
 CONSTRAINT [PK_TaiKhoanTienGuiThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaSoTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoanTietKiem]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanTietKiem](
	[MaSoTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[SoTienGui] [money] NULL,
	[KyHan] [int] NULL,
	[LaiSuat] [float] NULL,
	[NgayGui] [datetime] NULL,
	[NgayDaoHan] [datetime] NULL,
 CONSTRAINT [PK_TaiKhoanTietKiem] PRIMARY KEY CLUSTERED 
(
	[MaSoTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TruSo]    Script Date: 3/19/2017 4:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruSo](
	[MaTruSo] [int] IDENTITY(1,1) NOT NULL,
	[TenTruSo] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[GiamDoc] [int] NULL,
	[LoaiTruSo] [int] NULL,
 CONSTRAINT [PK_TruSo] PRIMARY KEY CLUSTERED 
(
	[MaTruSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [BankManagement] SET  READ_WRITE 
GO
