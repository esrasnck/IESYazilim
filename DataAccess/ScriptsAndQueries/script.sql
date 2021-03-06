USE [ITSPTS]
GO
/****** Object:  Table [dbo].[carrier]    Script Date: 11/14/2021 6:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carrier](
	[carrierid] [bigint] IDENTITY(1,1) NOT NULL,
	[transferid] [bigint] NULL,
	[carrierLabel] [varchar](20) NULL,
	[containerType] [nvarchar](50) NULL,
	[altcarrierid] [bigint] NULL,
 CONSTRAINT [carrier_carrieridAsc] PRIMARY KEY CLUSTERED 
(
	[carrierid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productList]    Script Date: 11/14/2021 6:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productList](
	[productListid] [bigint] IDENTITY(1,1) NOT NULL,
	[GTIN] [nvarchar](14) NULL,
	[lotNumber] [nvarchar](20) NULL,
	[productionDate] [date] NULL,
	[expirationDate] [date] NULL,
	[PONumber] [nvarchar](255) NULL,
	[carrierid] [bigint] NULL,
 CONSTRAINT [productList_productListidAsc] PRIMARY KEY CLUSTERED 
(
	[productListid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serialNumber]    Script Date: 11/14/2021 6:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serialNumber](
	[serialNumberid] [bigint] IDENTITY(1,1) NOT NULL,
	[serialNumber] [nvarchar](20) NULL,
	[productListid] [bigint] NULL,
	[hatakodu] [int] NULL,
 CONSTRAINT [serialNumber_serialNumberidAsc] PRIMARY KEY CLUSTERED 
(
	[serialNumberid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [serialNumber_productListidserialNumberAsc] UNIQUE NONCLUSTERED 
(
	[productListid] ASC,
	[serialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transfer]    Script Date: 11/14/2021 6:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transfer](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[sourceGLN] [varchar](13) NULL,
	[destinationGLN] [varchar](13) NULL,
	[actionType] [nvarchar](1) NULL,
	[shipTo] [nvarchar](20) NULL,
	[documentNumber] [nvarchar](20) NULL,
	[documentDate] [date] NULL,
	[note] [nvarchar](50) NULL,
	[version] [nvarchar](50) NULL,
 CONSTRAINT [transfer_idAsc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/14/2021 6:21:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PasswordSalt] [varbinary](500) NULL,
	[PasswordHash] [varbinary](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[carrier]  WITH CHECK ADD  CONSTRAINT [carrier_transferidFK] FOREIGN KEY([transferid])
REFERENCES [dbo].[transfer] ([id])
GO
ALTER TABLE [dbo].[carrier] CHECK CONSTRAINT [carrier_transferidFK]
GO
ALTER TABLE [dbo].[productList]  WITH CHECK ADD  CONSTRAINT [productList_carrieridFK] FOREIGN KEY([carrierid])
REFERENCES [dbo].[carrier] ([carrierid])
GO
ALTER TABLE [dbo].[productList] CHECK CONSTRAINT [productList_carrieridFK]
GO
ALTER TABLE [dbo].[serialNumber]  WITH CHECK ADD  CONSTRAINT [serialNumber_productListidFK] FOREIGN KEY([productListid])
REFERENCES [dbo].[productList] ([productListid])
GO
ALTER TABLE [dbo].[serialNumber] CHECK CONSTRAINT [serialNumber_productListidFK]
GO
