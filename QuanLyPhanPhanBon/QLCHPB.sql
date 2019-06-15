USE [master]
GO
/****** Object:  Database [QuanLyPhanBon]    Script Date: 6/15/2019 2:13:31 PM ******/
CREATE DATABASE [QuanLyPhanBon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyPhanBon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyPhanBon.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyPhanBon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyPhanBon_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyPhanBon] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyPhanBon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyPhanBon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyPhanBon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyPhanBon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyPhanBon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyPhanBon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyPhanBon] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyPhanBon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyPhanBon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyPhanBon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyPhanBon] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyPhanBon] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyPhanBon', N'ON'
GO
USE [QuanLyPhanBon]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/15/2019 2:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IDKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[SDT] [nvarchar](10) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[IsThieuTien] [bit] NULL,
	[TienNo] [money] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 6/15/2019 2:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[IDKhuyenMai] [nchar](10) NOT NULL,
	[TenKhuyenMai] [nvarchar](50) NOT NULL,
	[NgayBatDau] [datetime] NOT NULL,
	[NgayKetThuc] [datetime] NOT NULL,
	[PhanTram] [float] NOT NULL,
 CONSTRAINT [PK_KhuyenMai] PRIMARY KEY CLUSTERED 
(
	[IDKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiPhanBon]    Script Date: 6/15/2019 2:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhanBon](
	[IDLoaiPhanBon] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiPhanBon] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NguonPhanBon] PRIMARY KEY CLUSTERED 
(
	[IDLoaiPhanBon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/15/2019 2:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IDNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[SDT] [nchar](10) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Luong] [int] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanBon]    Script Date: 6/15/2019 2:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhanBon](
	[IDPhanBon] [int] IDENTITY(1,1) NOT NULL,
	[TenPhanBon] [nvarchar](100) NOT NULL,
	[LoaiPhanBon] [int] NOT NULL,
	[Gia] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
	[SoLuong] [int] NULL,
	[HinhAnh] [varchar](50) NULL,
 CONSTRAINT [PK_PhanBon_1] PRIMARY KEY CLUSTERED 
(
	[IDPhanBon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanBon_KH]    Script Date: 6/15/2019 2:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanBon_KH](
	[IDPhanBon] [int] NOT NULL,
	[IDKhachHang] [int] NOT NULL,
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[KhuyenMai] [nchar](10) NULL,
	[Gia] [money] NOT NULL,
	[TenPhanBon] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PhanBon_KH_1] PRIMARY KEY CLUSTERED 
(
	[IDPhanBon] ASC,
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/15/2019 2:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IDNhanVien] [int] NOT NULL,
	[TenTaiKhoan] [nchar](15) NOT NULL,
	[MatKhau] [nchar](15) NOT NULL,
 CONSTRAINT [PK_TaiKhoan_1] PRIMARY KEY CLUSTERED 
(
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (1, N'Nguyễn Văn Nam', N'Nam', N'0987524568', N'123 Dương Bá Trạc', 1, 1000000.0000)
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (2, N'Trần Đình Thắng', N'Nam', N'0668975186', N'13 Nguyễn Văn Cừ', 0, 200000.0000)
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (3, N'Trần Phi Hùng', N'Nữ', N'0468958858', N'151 Hùng Vương', 1, 5000000.0000)
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (4, N'Nguyễn Thị Mỹ', N'Nữ', N'0165878486', N'120 Dương Bá Trạc', 0, 550000.0000)
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (5, N'Lê Thành', N'Nam', N'0484548888', N'160 Nguyễn Thị Tần', 0, 0.0000)
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (6, N'Lê Hùng', N'Nam', N'0848945862', N'11 An Dương Vương', 0, 10000.0000)
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (7, N'Trần Văn Vũ', N'Nam', N'0897845555', N'111 Nguyễn Văn Cừ', 0, 0.0000)
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKhachHang], [GioiTinh], [SDT], [DiaChi], [IsThieuTien], [TienNo]) VALUES (18, N'Nguyễn Quang Hào', N'Nam', N'088484888', N'123 Nguyễn Trãi', 1, 1000000.0000)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
INSERT [dbo].[KhuyenMai] ([IDKhuyenMai], [TenKhuyenMai], [NgayBatDau], [NgayKetThuc], [PhanTram]) VALUES (N'001       ', N'Black Friday', CAST(N'2019-05-31 00:00:00.000' AS DateTime), CAST(N'2019-05-30 00:00:00.000' AS DateTime), 20)
INSERT [dbo].[KhuyenMai] ([IDKhuyenMai], [TenKhuyenMai], [NgayBatDau], [NgayKetThuc], [PhanTram]) VALUES (N'002       ', N'Sinh nhật', CAST(N'2019-06-15 00:00:00.000' AS DateTime), CAST(N'2019-06-25 00:00:00.000' AS DateTime), 10)
INSERT [dbo].[KhuyenMai] ([IDKhuyenMai], [TenKhuyenMai], [NgayBatDau], [NgayKetThuc], [PhanTram]) VALUES (N'003       ', N'Trung thu', CAST(N'2019-06-20 00:00:00.000' AS DateTime), CAST(N'2019-06-25 00:00:00.000' AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[LoaiPhanBon] ON 

INSERT [dbo].[LoaiPhanBon] ([IDLoaiPhanBon], [TenLoaiPhanBon]) VALUES (1, N'Hóa học')
INSERT [dbo].[LoaiPhanBon] ([IDLoaiPhanBon], [TenLoaiPhanBon]) VALUES (2, N'Vi Sinh')
INSERT [dbo].[LoaiPhanBon] ([IDLoaiPhanBon], [TenLoaiPhanBon]) VALUES (3, N'Hữu cơ')
SET IDENTITY_INSERT [dbo].[LoaiPhanBon] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (1, N'Nguyễn Sỹ Nam', N'NAm', N'0987566315', N'121 Cao Thắng', 3000000)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (2, N'Trần Đình An', N'Nam', N'0598756635', N'22 Nguyễn Trãi', 5000000)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (3, N'Nguyễn Thị Lan', N'Nữ', N'0589478686', N'234 Lý Thái Tổ', 4000000)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (4, N'Nguyễn Thị Thúy', N'Nữ', N'0578778788', N'223 Lý Thường Kiếth', 5000000)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (5, N'Lê Văn Thành', N'Nam', N'0588525885', N'222 Cao Thắng', 4000000)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (6, N'Lê Thành Đạt', N'NAm', N'0548848754', N'11 Nguyễn Trãi', 4000000)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (7, N'Trần Thị Thanh', N'Nữ', N'0148568898', N'25 Nguyễn Thị Thập', 5000000)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [SDT], [DiaChi], [Luong]) VALUES (8, N'Lê Văn Vũ', N'Nam', N'0684548484', N'134 Trần Hưng Đạo', 7000000)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[PhanBon] ON 

INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (1, N'NPK', 1, 200000, 0, 50, NULL)
INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (2, N'Đạm Phú Mỹ', 2, 300000, 1, 20, NULL)
INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (3, N'Đầu Trâu', 3, 500000, 1, 15, NULL)
INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (4, N'Lâm thao', 3, 500000, 1, 20, NULL)
INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (5, N'Bình Điền', 1, 600000, 1, 60, NULL)
INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (6, N'Kali', 2, 700000, 0, 15, NULL)
INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (7, N'Thuốc trừ sâu', 2, 400000, 0, 17, NULL)
INSERT [dbo].[PhanBon] ([IDPhanBon], [TenPhanBon], [LoaiPhanBon], [Gia], [isDelete], [SoLuong], [HinhAnh]) VALUES (8, N'Phân Lân', 3, 1000000, 0, 25, NULL)
SET IDENTITY_INSERT [dbo].[PhanBon] OFF
SET IDENTITY_INSERT [dbo].[PhanBon_KH] ON 

INSERT [dbo].[PhanBon_KH] ([IDPhanBon], [IDKhachHang], [STT], [SoLuong], [NgayBan], [KhuyenMai], [Gia], [TenPhanBon]) VALUES (1, 2, 1, 2, CAST(N'2019-06-20 00:00:00.000' AS DateTime), NULL, 200000.0000, N'NPK')
INSERT [dbo].[PhanBon_KH] ([IDPhanBon], [IDKhachHang], [STT], [SoLuong], [NgayBan], [KhuyenMai], [Gia], [TenPhanBon]) VALUES (1, 4, 5, 1, CAST(N'2019-06-19 00:00:00.000' AS DateTime), NULL, 1000000.0000, N'NPK')
INSERT [dbo].[PhanBon_KH] ([IDPhanBon], [IDKhachHang], [STT], [SoLuong], [NgayBan], [KhuyenMai], [Gia], [TenPhanBon]) VALUES (2, 1, 2, 3, CAST(N'2019-06-15 00:00:00.000' AS DateTime), N'001       ', 5000000.0000, N'Đạm Phú Mỹ')
INSERT [dbo].[PhanBon_KH] ([IDPhanBon], [IDKhachHang], [STT], [SoLuong], [NgayBan], [KhuyenMai], [Gia], [TenPhanBon]) VALUES (2, 5, 6, 2, CAST(N'2019-06-19 00:00:00.000' AS DateTime), NULL, 8000000.0000, N'Đạm Phú Mỹ')
INSERT [dbo].[PhanBon_KH] ([IDPhanBon], [IDKhachHang], [STT], [SoLuong], [NgayBan], [KhuyenMai], [Gia], [TenPhanBon]) VALUES (6, 1, 3, 1, CAST(N'2019-06-18 00:00:00.000' AS DateTime), N'001       ', 7000000.0000, N'Kali')
SET IDENTITY_INSERT [dbo].[PhanBon_KH] OFF
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (2, N'admin          ', N'123            ')
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (7, N'ducdeptrai     ', N'123            ')
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (1, N'hau            ', N'123            ')
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (6, N'hoang          ', N'123            ')
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (5, N'hung           ', N'123            ')
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (3, N'nam            ', N'123            ')
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (4, N'ngoc           ', N'123            ')
INSERT [dbo].[TaiKhoan] ([IDNhanVien], [TenTaiKhoan], [MatKhau]) VALUES (8, N'thang          ', N'123            ')
ALTER TABLE [dbo].[PhanBon]  WITH CHECK ADD  CONSTRAINT [FK_PhanBon_LoaiPhanBon] FOREIGN KEY([LoaiPhanBon])
REFERENCES [dbo].[LoaiPhanBon] ([IDLoaiPhanBon])
GO
ALTER TABLE [dbo].[PhanBon] CHECK CONSTRAINT [FK_PhanBon_LoaiPhanBon]
GO
ALTER TABLE [dbo].[PhanBon_KH]  WITH CHECK ADD  CONSTRAINT [FK_PhanBon_KH_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[PhanBon_KH] CHECK CONSTRAINT [FK_PhanBon_KH_KhachHang]
GO
ALTER TABLE [dbo].[PhanBon_KH]  WITH CHECK ADD  CONSTRAINT [FK_PhanBon_KH_KhuyenMai] FOREIGN KEY([KhuyenMai])
REFERENCES [dbo].[KhuyenMai] ([IDKhuyenMai])
GO
ALTER TABLE [dbo].[PhanBon_KH] CHECK CONSTRAINT [FK_PhanBon_KH_KhuyenMai]
GO
ALTER TABLE [dbo].[PhanBon_KH]  WITH CHECK ADD  CONSTRAINT [FK_PhanBon_KH_PhanBon1] FOREIGN KEY([IDPhanBon])
REFERENCES [dbo].[PhanBon] ([IDPhanBon])
GO
ALTER TABLE [dbo].[PhanBon_KH] CHECK CONSTRAINT [FK_PhanBon_KH_PhanBon1]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [QuanLyPhanBon] SET  READ_WRITE 
GO
