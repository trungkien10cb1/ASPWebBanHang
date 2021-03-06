


USE [WebBanHang]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/6/2017 11:21:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ma] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Category_ma]  DEFAULT (newid()),
	[tendanhmuc] [nvarchar](50) NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[makhachhang] [int] IDENTITY(1,1) NOT NULL,
	[shipName] [nvarchar](50) NULL,
	[shipMobile] [nvarchar](50) NULL,
	[shipAddress] [nvarchar](50) NULL,
	[shipEmail] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[makhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ma] [bigint] IDENTITY(1,1) NOT NULL,
	[makhachhang] [int] NULL,
	[ngaydathang] [datetime] NULL,
	[status] [nvarchar](50) NULL,
	[ngaygiaohang] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[masanpham] [nvarchar](50) NOT NULL,
	[madathang] [bigint] NOT NULL,
	[soluong] [int] NULL CONSTRAINT [DF_OrderDetail_soluong]  DEFAULT ((1)),
	[dongia] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[masanpham] ASC,
	[madathang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ma] [nvarchar](50) NOT NULL,
	[tensanpham] [nvarchar](50) NULL,
	[dongia] [decimal](18, 0) NULL,
	[hangsanxuat] [nvarchar](50) NULL,
	[soluong] [int] NULL,
	[producttype] [nvarchar](50) NULL,
	[imglink] [nvarchar](100) NULL,
	[mota] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[masanpham] [nvarchar](50) NOT NULL,
	[ram] [varchar](10) NULL,
	[diacung] [varchar](20) NULL,
	[vga] [varchar](20) NULL,
	[manhinh] [varchar](20) NULL,
	[vixuly] [varchar](20) NULL,
 CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED 
(
	[masanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[mahienthi] [nvarchar](50) NOT NULL,
	[tendanhmuccon] [nvarchar](50) NULL,
	[soluong] [int] NULL,
	[danhmucma] [uniqueidentifier] NULL,
 CONSTRAINT [PK_SubCategory_1] PRIMARY KEY CLUSTERED 
(
	[mahienthi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[permission] [nvarchar](10) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Category] ([ma], [tendanhmuc], [soluong]) VALUES (N'b1924d1c-9652-4565-880e-0d9ec3753be0', N'LAPTOP BUSINESS', 29)
INSERT [dbo].[Category] ([ma], [tendanhmuc], [soluong]) VALUES (N'9d8aa77f-8bb4-4d5e-995d-59322d8c4a53', N'LAPTOP PHỔ THÔNG', 155)
INSERT [dbo].[Category] ([ma], [tendanhmuc], [soluong]) VALUES (N'37d0ebb7-3ab9-4c38-a354-bc461de186b1', N'LAPTOP WORKSTATION', 36)
INSERT [dbo].[Category] ([ma], [tendanhmuc], [soluong]) VALUES (N'41c5b880-7d56-4dbd-a2fa-cee67ddc9ada', N'LAPTOP GAMING', 64)
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([makhachhang], [shipName], [shipMobile], [shipAddress], [shipEmail]) VALUES (1, N'phucvu', N'0977692112', N'Ha Dong', N'phucvu.lqd@gamil.com')
INSERT [dbo].[Customer] ([makhachhang], [shipName], [shipMobile], [shipAddress], [shipEmail]) VALUES (2, N'travan', N'0976456123', N'Ha Noi', N'travan@gmail.com')
INSERT [dbo].[Customer] ([makhachhang], [shipName], [shipMobile], [shipAddress], [shipEmail]) VALUES (3, N'DoThanh', N'0978223567', N'Hà Nội', N'donhuthanh1996@gmail.com')
INSERT [dbo].[Customer] ([makhachhang], [shipName], [shipMobile], [shipAddress], [shipEmail]) VALUES (4, N'vu phuc', N'0977692112', N'Hà nội', N'phucvu.lqd@gmail.com')
INSERT [dbo].[Customer] ([makhachhang], [shipName], [shipMobile], [shipAddress], [shipEmail]) VALUES (5, N'Đô Như Thành', N'01657957273', N'Hà Nội', N'donhuthanh1996@gmail.com')
INSERT [dbo].[Customer] ([makhachhang], [shipName], [shipMobile], [shipAddress], [shipEmail]) VALUES (6, N'Vũ Thanh Phúc', N'01234567891', N'Hà Nội', N'vuvien@gmail.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ma], [makhachhang], [ngaydathang], [status], [ngaygiaohang]) VALUES (1, 1, CAST(N'2017-06-05 23:15:24.620' AS DateTime), N'Đang giao hang', CAST(N'2017-06-05 23:15:24.620' AS DateTime))
INSERT [dbo].[Order] ([ma], [makhachhang], [ngaydathang], [status], [ngaygiaohang]) VALUES (2, 1, CAST(N'2017-06-05 23:19:38.347' AS DateTime), N'Đang giao hang', CAST(N'2017-06-05 23:19:38.347' AS DateTime))
INSERT [dbo].[Order] ([ma], [makhachhang], [ngaydathang], [status], [ngaygiaohang]) VALUES (3, 2, CAST(N'2017-06-05 23:34:44.837' AS DateTime), N'Đang giao hang', CAST(N'2017-06-05 23:34:44.837' AS DateTime))
INSERT [dbo].[Order] ([ma], [makhachhang], [ngaydathang], [status], [ngaygiaohang]) VALUES (4, 3, CAST(N'2017-06-05 23:48:57.573' AS DateTime), N'Đang giao hang', CAST(N'2017-06-05 23:48:57.573' AS DateTime))
INSERT [dbo].[Order] ([ma], [makhachhang], [ngaydathang], [status], [ngaygiaohang]) VALUES (5, 4, CAST(N'2017-06-06 00:01:37.880' AS DateTime), N'Đang giao hang', CAST(N'2017-06-06 00:01:37.880' AS DateTime))
INSERT [dbo].[Order] ([ma], [makhachhang], [ngaydathang], [status], [ngaygiaohang]) VALUES (6, 5, CAST(N'2017-06-06 03:16:57.660' AS DateTime), N'Đang giao hang', CAST(N'2017-06-06 03:16:57.660' AS DateTime))
INSERT [dbo].[Order] ([ma], [makhachhang], [ngaydathang], [status], [ngaygiaohang]) VALUES (7, 6, CAST(N'2017-06-06 03:20:31.877' AS DateTime), N'Đang giao hang', CAST(N'2017-06-06 03:20:31.877' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'ASUSROG', 1, 1, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'ASUSROG', 2, 1, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'ASUSROG', 5, 1, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'DELLI157000', 3, 1, CAST(260 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'DELLLATI6420', 7, 1, CAST(27000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'HPPAVILON17', 4, 1, CAST(230 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'THINKPADW541', 6, 2, CAST(42000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([masanpham], [madathang], [soluong], [dongia]) VALUES (N'THINKPADW541', 7, 2, CAST(42000000 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP550L', N'Laptop ASUS PRO P550L                             ', CAST(20000000 AS Decimal(18, 0)), N'Asus', 10, N'ASUSPT', N'/Content/themes/images/products/ASUS/ASUSP550L.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP560K', N'Laptop Asus Pro P560K', CAST(25000000 AS Decimal(18, 0)), N'Asus', 15, N'ASUSPT', N'/Content/themes/images/products/17.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP570K', N'Laptop Asus Pro P570K', CAST(25000000 AS Decimal(18, 0)), N'Asus', 20, N'ASUSPT', N'/Content/themes/images/products/19.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP571K', N'Laptop Asus Pro P571K', CAST(28000000 AS Decimal(18, 0)), N'Asus', 16, N'ASUSPT', N'/Content/themes/images/products/30.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP572K', N'Laptop Asus Pro P570K', CAST(27000000 AS Decimal(18, 0)), N'Asus', 16, N'ASUSPT', N'/Content/themes/images/products/29.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP574K', N'Laptop Asus Pro P574K', CAST(25000000 AS Decimal(18, 0)), N'Asus', 16, N'ASUSPT', N'/Content/themes/images/products/17.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP580K', N'Laptop Asus Pro P580K', CAST(26000000 AS Decimal(18, 0)), N'Asus', 15, N'ASUSPT', N'/Content/themes/images/products/20.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP590K', N'Laptop Asus Pro P590K', CAST(26000000 AS Decimal(18, 0)), N'Asus', 12, N'ASUSPT', N'/Content/themes/images/products/21.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ASUSP600K', N'Laptop Asus Pro P600K', CAST(27000000 AS Decimal(18, 0)), N'Asus', 13, N'ASUSPT', N'/Content/themes/images/products/25.jpg', N'Intel Core i7/4GB/750GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'DELLI157000', N'Laptop INSPIRON15 7000                            ', CAST(26000000 AS Decimal(18, 0)), N'Dell', 30, N'DELLGAME', N'/Content/themes/images/products/DELL/DELLI157000.jpg', N'Intel Core i5/4GB/500GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'DELLLATI6420', N'Laptop DELL LATITUDE 6420', CAST(27000000 AS Decimal(18, 0)), N'Dell', 19, N'DELLBUSS', N'/Content/themes/images/products/DELL/DELLLATI6420.jpg', N'Intel Core i5/4GB/320GB/14')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'DELLPRE7510', N'Laptop DELL PRECISION 7510 ', CAST(32000000 AS Decimal(18, 0)), N'Dell', 10, N'DELLWORK', N'/Content/themes/images/products/DELL/DELLPRE7510.jpg', N'Intel Core i7/16GB/500GB/AMD FirePro W1570M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'DELLVO5468', N'Laptop DELL VOSTRO 5468', CAST(15000000 AS Decimal(18, 0)), N'Dell', 5, N'DELLPT', N'/Content/themes/images/products/DELL/DELLVO5468.jpg', N'Intel Core i5/4GB/500GB/14')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'ELITE8470P', N'Laptop ELITEBOOK 8470P', CAST(30000000 AS Decimal(18, 0)), N'HP', 6, N'HPBUSS', N'/Content/themes/images/products/HP/ELITE8470P.jpg', N'Intel Core i5/4GB/320GB/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'HP8570W', N'Laptop HP PROVAI  8570W ', CAST(45000000 AS Decimal(18, 0)), N'HP', 10, N'HPWORK', N'/Content/themes/images/products/HP/HP8570W.jpg', N'Intel Core i7/8GB/500GB/NVIDIA K2000/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'HPPAVILON17', N'Laptop HP PAVILON 17  G3                          ', CAST(23000000 AS Decimal(18, 0)), N'HP', 20, N'HPGAME', N'/Content/themes/images/products/HP/HPPAVILON17.jpg', N'Intel Core i5/4GB/500GB/GTX 840M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'HPPRO450G3', N'Laptop HP PROBOOK 450 G3 ', CAST(21000000 AS Decimal(18, 0)), N'HP', 10, N'HPPT', N'/Content/themes/images/products/HP/HPPRO450G3.jpg', N'Intel Core i5/8GB/500GB/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'LENOVOIDEA110', N'Laptop LENOVO IDEAPAD 110  ', CAST(16000000 AS Decimal(18, 0)), N'Lenovo', 7, N'LENOVOPT', N'/Content/themes/images/products/LENOVO/LENOVOIDEA110.jpg', N'Intel Core i3/4GB/1TB/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'LENOVOLE720', N'Laptop LENOVO LEGIONY 720 ', CAST(18000000 AS Decimal(18, 0)), N'Lenovo', 8, N'LENOVOGAME', N'/Content/themes/images/products/LENOVO/LENOVOLE720.jpg', N'Intel Core i7/16GB/1TB/GTX 1060/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'MSIGT70', N'Laptop MSI GAMING GTI 70 ', CAST(50000000 AS Decimal(18, 0)), N'MSI', 6, N'MSIGAME', N'/Content/themes/images/products/MSI/MSIGT70.jpg', N'Intel Core i7/8GB/1TB/GTX 960M/17')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'MSIWT726QN', N'Laptop MSI GAMING WT72 6QN ', CAST(51000000 AS Decimal(18, 0)), N'MSI', 5, N'MSIWORK', N'/Content/themes/images/products/MSI/MSIWT726QN.jpg', N'Intel Core i7/32GB/512GB/NVIDIA M5500/17.3')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'THINKPADP50', N'Laptop THINKPAD PK50', CAST(44000000 AS Decimal(18, 0)), N'Lenovo', 4, N'LENOVOBUSS', N'/Content/themes/images/products/LENOVO/THINKPADP50.jpg', N'Intel Core i7/16GB/256GB/NVIDIA M2000M/15.6')
INSERT [dbo].[Product] ([ma], [tensanpham], [dongia], [hangsanxuat], [soluong], [producttype], [imglink], [mota]) VALUES (N'THINKPADW541', N'Laptop THINKPAD WS541', CAST(42000000 AS Decimal(18, 0)), N'Lenovo', 11, N'LENOVOWORK', N'/Content/themes/images/products/LENOVO/THINKPADW541.jpg', N'Intel Core i7/8GB/1TB/NVIDIA K2000/17')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP550L', N'4GB', N'750GB', N'GTX 840M', N'15.6 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP560K', N'4 GB', N'750GB', N'GTX 840M', N'15.6', N'core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP570K', N'4GB', N'750GB', N'GTX 840M', N'15.6', N'core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP571K', N'4 GB', N'750GB', N'GTX 840M', N'15.6', N'Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP572K', N'4 GB', N'750GB', N'GTX 840M', N'15.6', N'Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP574K', N'4 GB', N'750GB', N'GTX 840M', N'15.6', N'Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP580K', N'4GB', N'750GB', N'GTX 840M', N'15.6', N'Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP590K', N'4 GB', N'750GB', N'GTX 840M', N'15.6', N'Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSP600K', N'4 GB', N'750GB', N'GTX 840M', N'15.6', N'Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ASUSROG   ', N'8GB', N'1TB+128GBssd', N'GTX 880M', N'17 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'DELLI157000', N'4GB', N'500GB', N'GTX 840M', N'15.6 inch', N'Intel Core i5')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'DELLLATI6420', N'4GB', N'320GB', N'không', N'14 inch', N'Intel Core i5')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'DELLPRE7510', N'16GB', N'500GB', N'AMD FirePro W1570M', N'15.6 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'DELLVO5468', N'4GB', N'500GB', N'không', N'14 inch', N'Intel Core i5')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'ELITE8470P', N'4GB', N'320GB', N'không', N'15.6 inch', N'Intel Core i5')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'HP8570W   ', N'8GB', N'500GB', N'NVIDIA K2000', N'15.6 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'HPPAVILON17', N'4GB', N'500GB', N'GTX 840M', N'15.6 inch', N'Intel Core i5')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'HPPRO450G3', N'8GB', N'500GB', N'không ', N'15.6 inch', N'Intel Core i5')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'HPWORK', N'8GB', N'1TB', N'không', N'17 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'LENOVOIDEA110', N'4GB', N'1TB', N'không', N'15.6 inch', N'Intel Core i3')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'LENOVOLE720', N'16GB', N'1TB', N'GTX 1060', N'15.6 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'MSIGT70   ', N'8GB', N'1TB+128GBssd', N'GTX 960M', N'17 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'MSIWT726QN', N'32GB', N'512GBssd', N'NVIDIA M5500', N'17.3 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'THINKPADP50', N'16GB', N'256GBssd', N'NVIDIA M2000M', N'15.6 inch', N'Intel Core i7')
INSERT [dbo].[ProductDetail] ([masanpham], [ram], [diacung], [vga], [manhinh], [vixuly]) VALUES (N'THINKPADW541', N'8GB', N'1TB+128SSD', N'NVIDIA K2000', N'17 inch', N'Intel Core i7')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'ASUSGAME', N'Laptop Asus ROG', 0, N'41c5b880-7d56-4dbd-a2fa-cee67ddc9ada')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'ASUSPT', N'Laptop Asus', 133, N'9d8aa77f-8bb4-4d5e-995d-59322d8c4a53')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'DELLBUSS', N'Laptop Dell Latitude', 19, N'b1924d1c-9652-4565-880e-0d9ec3753be0')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'DELLGAME', N'Laptop Dell Alienware', 30, N'41c5b880-7d56-4dbd-a2fa-cee67ddc9ada')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'DELLPT', N'Laptop Dell', 5, N'9d8aa77f-8bb4-4d5e-995d-59322d8c4a53')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'DELLWORK', N'Laptop Dell workstation', 10, N'37d0ebb7-3ab9-4c38-a354-bc461de186b1')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'HPBUSS', N'Laptop HP Elitebook', 6, N'b1924d1c-9652-4565-880e-0d9ec3753be0')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'HPGAME', N'Laptop HP Gaming', 20, N'41c5b880-7d56-4dbd-a2fa-cee67ddc9ada')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'HPPT', N'Laptop HP', 10, N'9d8aa77f-8bb4-4d5e-995d-59322d8c4a53')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'HPWORK', N'Laptop HP workstation ', 10, N'37d0ebb7-3ab9-4c38-a354-bc461de186b1')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'LENOVOBUSS', N'Laptop Lenovo ThinkPad', 4, N'b1924d1c-9652-4565-880e-0d9ec3753be0')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'LENOVOGAME', N'Laptop Lenovo Gaming', 8, N'41c5b880-7d56-4dbd-a2fa-cee67ddc9ada')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'LENOVOPT', N'Laptop Lenovo', 7, N'9d8aa77f-8bb4-4d5e-995d-59322d8c4a53')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'LENOVOWORK', N'Laptop ThinkPad workstation', 11, N'37d0ebb7-3ab9-4c38-a354-bc461de186b1')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'MSIGAME', N'Laptop MSI Gaming', 6, N'41c5b880-7d56-4dbd-a2fa-cee67ddc9ada')
INSERT [dbo].[SubCategory] ([mahienthi], [tendanhmuccon], [soluong], [danhmucma]) VALUES (N'MSIWORK', N'Laptop MSI workstation', 5, N'37d0ebb7-3ab9-4c38-a354-bc461de186b1')
INSERT [dbo].[User] ([username], [password], [permission]) VALUES (N'admin', N'123456', N'admin')
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([makhachhang])
REFERENCES [dbo].[Customer] ([makhachhang])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([madathang])
REFERENCES [dbo].[Order] ([ma])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductDetail] FOREIGN KEY([ma])
REFERENCES [dbo].[ProductDetail] ([masanpham])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductDetail]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([producttype])
REFERENCES [dbo].[SubCategory] ([mahienthi])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([danhmucma])
REFERENCES [dbo].[Category] ([ma])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO
/****** Object:  StoredProcedure [dbo].[SP_PhanTrang]    Script Date: 7/6/2017 11:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PhanTrang] 
	@type nvarchar(50),
	@sotrang int
AS
BEGIN
	declare @tbd int
	set @tbd = 6*(@sotrang - 1) + 1
	select * from Product 
	where producttype = @type order by ma
	offset @tbd rows fetch next 6 rows only
END

GO
