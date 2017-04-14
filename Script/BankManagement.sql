USE [master]
GO
/****** Object:  Database [BankManagerment]    Script Date: 15/04/2017 1:31:00 SA ******/
CREATE DATABASE [BankManagerment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankManagerment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\BankManagerment.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BankManagerment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\BankManagerment_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BankManagerment] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankManagerment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankManagerment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankManagerment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankManagerment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankManagerment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankManagerment] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankManagerment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankManagerment] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BankManagerment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankManagerment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankManagerment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankManagerment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankManagerment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankManagerment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankManagerment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankManagerment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankManagerment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BankManagerment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankManagerment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankManagerment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankManagerment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankManagerment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankManagerment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankManagerment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankManagerment] SET RECOVERY FULL 
GO
ALTER DATABASE [BankManagerment] SET  MULTI_USER 
GO
ALTER DATABASE [BankManagerment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankManagerment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankManagerment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankManagerment] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BankManagerment', N'ON'
GO
USE [BankManagerment]
GO
/****** Object:  Table [dbo].[GiaoDichChuyenTien]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GiaoDichGoiTien]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GiaoDichGoiTienTietKiem]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GiaoDichGoiTienTietKiem](
	[MaGD] [varchar](15) NOT NULL,
	[MaKH] [varchar](15) NOT NULL,
	[SoTien] [money] NOT NULL,
	[MaNV] [varchar](15) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_GiaoDichGoiTienTietKiem] PRIMARY KEY CLUSTERED 
(
	[MaGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GiaoDichRutTien]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNhanVien] [nvarchar](100) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTruSo]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTruSo](
	[MaLoaiTruSo] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiTruSo] [nvarchar](100) NOT NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_LoaiTruSo] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTruSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SoTietKiem]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TruSo]    Script Date: 15/04/2017 1:31:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[GiaoDichChuyenTien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichChuyenTien_KhachHang] FOREIGN KEY([MaKHGoi])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[GiaoDichChuyenTien] CHECK CONSTRAINT [FK_GiaoDichChuyenTien_KhachHang]
GO
ALTER TABLE [dbo].[GiaoDichChuyenTien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichChuyenTien_KhachHang1] FOREIGN KEY([MaKHNhan])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[GiaoDichChuyenTien] CHECK CONSTRAINT [FK_GiaoDichChuyenTien_KhachHang1]
GO
ALTER TABLE [dbo].[GiaoDichChuyenTien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichChuyenTien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[GiaoDichChuyenTien] CHECK CONSTRAINT [FK_GiaoDichChuyenTien_NhanVien]
GO
ALTER TABLE [dbo].[GiaoDichGoiTien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichGoiTien_KhachHang] FOREIGN KEY([MaKHNhan])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[GiaoDichGoiTien] CHECK CONSTRAINT [FK_GiaoDichGoiTien_KhachHang]
GO
ALTER TABLE [dbo].[GiaoDichGoiTien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichGoiTien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[GiaoDichGoiTien] CHECK CONSTRAINT [FK_GiaoDichGoiTien_NhanVien]
GO
ALTER TABLE [dbo].[GiaoDichGoiTienTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichGoiTienTietKiem_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[GiaoDichGoiTienTietKiem] CHECK CONSTRAINT [FK_GiaoDichGoiTienTietKiem_KhachHang]
GO
ALTER TABLE [dbo].[GiaoDichGoiTienTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichGoiTienTietKiem_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[GiaoDichGoiTienTietKiem] CHECK CONSTRAINT [FK_GiaoDichGoiTienTietKiem_NhanVien]
GO
ALTER TABLE [dbo].[GiaoDichRutTien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichRutTien_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[GiaoDichRutTien] CHECK CONSTRAINT [FK_GiaoDichRutTien_KhachHang]
GO
ALTER TABLE [dbo].[GiaoDichRutTien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDichRutTien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[GiaoDichRutTien] CHECK CONSTRAINT [FK_GiaoDichRutTien_NhanVien]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_LoaiNhanVien] FOREIGN KEY([MaLoaiNhanVien])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNhanVien])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_LoaiNhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TruSo] FOREIGN KEY([MaTruSo])
REFERENCES [dbo].[TruSo] ([MaTruSo])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TruSo]
GO
ALTER TABLE [dbo].[SoTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_SoTietKiem_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[SoTietKiem] CHECK CONSTRAINT [FK_SoTietKiem_KhachHang]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_KhachHang]
GO
ALTER TABLE [dbo].[TruSo]  WITH CHECK ADD  CONSTRAINT [FK_TruSo_LoaiTruSo] FOREIGN KEY([MaLoaiTruSo])
REFERENCES [dbo].[LoaiTruSo] ([MaLoaiTruSo])
GO
ALTER TABLE [dbo].[TruSo] CHECK CONSTRAINT [FK_TruSo_LoaiTruSo]
GO
USE [master]
GO
ALTER DATABASE [BankManagerment] SET  READ_WRITE 
GO
