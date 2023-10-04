-- Tạo Database trước
CREATE DATABASE [DB_QLXuatKhauGao]

-- SAU ĐÓ
USE [DB_QLXuatKhauGao]

-- SAU ĐÓ BÔI ĐEN HẾT PHẦN CODE PHÍA ĐƯỚI ẤN F5
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 04/10/2023 9:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[matkhau] [nvarchar](30) NULL,
	[isAdmin] [int] NULL DEFAULT ((2)),
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 04/10/2023 9:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[mota] [nvarchar](max) NULL,
	[thue] [float] NULL DEFAULT ((0)),
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 04/10/2023 9:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[diachi] [nvarchar](max) NULL,
	[sdt] [varchar](12) NULL,
	[login_id] [int] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 04/10/2023 9:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[mota] [nvarchar](300) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 04/10/2023 9:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SanPham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DanhMuc_id] [int] NOT NULL,
	[ten] [nvarchar](100) NOT NULL,
	[mota] [nvarchar](max) NULL,
	[soluong] [int] NULL,
	[trongluong] [float] NULL,
	[gia] [float] NOT NULL,
	[hinhanh] [varchar](max) NULL,
	[ngaytao] [datetime] NULL DEFAULT (getdate()),
	[ngaysua] [datetime] NULL DEFAULT (NULL),
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DangNhap] ON 

INSERT [dbo].[DangNhap] ([id], [email], [matkhau], [isAdmin]) VALUES (1, N'admin@gmail.com', N'admin', 1)
INSERT [dbo].[DangNhap] ([id], [email], [matkhau], [isAdmin]) VALUES (2, N'user1@gmail.com', N'user1', 2)
INSERT [dbo].[DangNhap] ([id], [email], [matkhau], [isAdmin]) VALUES (6, N'nguyenvu@gmail.com', N'nguyenvu', 2)
INSERT [dbo].[DangNhap] ([id], [email], [matkhau], [isAdmin]) VALUES (7, N'truongvu@gmail.com', N'truongvu', 2)
SET IDENTITY_INSERT [dbo].[DangNhap] OFF
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([id], [ten], [mota], [thue]) VALUES (1, N'Gạo nở khô', N'Gạo nở khô có giá thành thấp, với tính chất nở xốp mềm thì đây là ưu tiên số 1 cho việc kinh doanh quán cơm bình dân', 0)
INSERT [dbo].[DanhMuc] ([id], [ten], [mota], [thue]) VALUES (2, N'Gạo xốp ngọt', N'Gạo có màu trắng trong. Hạt gạo đều, khô ráo, mặt gạo không bóng. Gạo cho cơm khô ráo, ngon ngọt cơm Giá thành trung bình thích hợp trong việc kinh doanh cơm chiên hoặc chế biến các loại cơm chiên dương châu, cơm chiên hải sản', 0)
INSERT [dbo].[DanhMuc] ([id], [ten], [mota], [thue]) VALUES (3, N'Gạo dẻo vừa', N'Được lai qua nhiều thế hệ F1 từ các loại gạo ngon khác, gạo dẻo vừa mang đầy đủ hương vị tính chất của các loại gạo nên đáp ứng được mọi sở thích của từng người, đặc biệt trong mùa đông gạo dẻo luôn được mọi người chú ý bởi nó tạo cảm giác dễ ăn ngoài ra các bà mẹ luôn dùng loại gạo dẻo để làm bột, cháo cho trẻ sơ sinh', 0)
INSERT [dbo].[DanhMuc] ([id], [ten], [mota], [thue]) VALUES (4, N'Gạo dẻo nhiều', N'Được lai qua nhiều thế hệ F1 từ các loại gạo ngon khác, gạo dẻo vừa mang đầy đủ hương vị tính chất của các loại gạo nên đáp ứng được mọi sở thích của từng người, đặc biệt trong mùa đông gạo dẻo luôn được mọi người chú ý bởi nó tạo cảm giác dễ ăn ngoài ra các bà mẹ luôn dùng loại gạo dẻo để làm bột, cháo cho trẻ sơ sinh', 0)
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([id], [ten], [diachi], [sdt], [login_id]) VALUES (1, N'TruongVu', N'Tp.HCM', N'0303030303', 1)
INSERT [dbo].[KhachHang] ([id], [ten], [diachi], [sdt], [login_id]) VALUES (2, N'Khachhang1', N'TPHCM', N'1221313', 2)
INSERT [dbo].[KhachHang] ([id], [ten], [diachi], [sdt], [login_id]) VALUES (6, N'Nguyễn Tấn Trường Vũ', NULL, NULL, 6)
INSERT [dbo].[KhachHang] ([id], [ten], [diachi], [sdt], [login_id]) VALUES (7, N'truongvu', N'TP.HCM', N'03030303003', 7)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([id], [ten], [mota]) VALUES (1, N'admin', N'admin')
INSERT [dbo].[PhanQuyen] ([id], [ten], [mota]) VALUES (2, N'usr', N'user')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([id], [DanhMuc_id], [ten], [mota], [soluong], [trongluong], [gia], [hinhanh], [ngaytao], [ngaysua]) VALUES (71, 2, N'Gạo Tám Thơm', N'Gạo tám thơm từ lâu đã nổi tiếng là loại gạo thơm ngon, dẻo như gạo nếp.', 2, 3000, 17000, N'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', CAST(N'2023-10-02 13:41:49.673' AS DateTime), NULL)
INSERT [dbo].[SanPham] ([id], [DanhMuc_id], [ten], [mota], [soluong], [trongluong], [gia], [hinhanh], [ngaytao], [ngaysua]) VALUES (72, 1, N'Gạo Jasmine', N'Gạo Jasmine là loại lúa thơm dẻo có thời gian sinh trưởng ngắn ( hay còn gọi là lúa ngắn ngày). Gạo Jasmine hiện đang được trồng phổ biến rộng rãi chiếm diện tích lớn nhất trong tổng diện tích trồng lúa. Vì gạo jasmine cho năng suất và giá trị cao.', 4, 2000, 10000, N'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', CAST(N'2023-10-02 13:55:47.600' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__DangNhap__CE900A1E82A77823]    Script Date: 04/10/2023 9:22:04 PM ******/
ALTER TABLE [dbo].[DangNhap] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DangNhap]  WITH CHECK ADD  CONSTRAINT [FK_DangNhap_PhanQuyen] FOREIGN KEY([isAdmin])
REFERENCES [dbo].[PhanQuyen] ([id])
GO
ALTER TABLE [dbo].[DangNhap] CHECK CONSTRAINT [FK_DangNhap_PhanQuyen]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_DangNhap] FOREIGN KEY([login_id])
REFERENCES [dbo].[DangNhap] ([id])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_DangNhap]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMuc] FOREIGN KEY([DanhMuc_id])
REFERENCES [dbo].[DanhMuc] ([id])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DanhMuc]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD CHECK  (([gia]>=(0)))
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD CHECK  (([soluong]>=(1)))
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD CHECK  (([trongluong]>(0)))
GO
