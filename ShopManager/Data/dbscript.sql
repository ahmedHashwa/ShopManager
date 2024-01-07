USE [ShopDatabase]
GO
/****** Object:  Table [dbo].[SalesKinds]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesKinds]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesKinds](
	[SalesKindID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kinds] PRIMARY KEY CLUSTERED 
(
	[SalesKindID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Fridges]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fridges]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Fridges](
	[FridgeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Fridges] PRIMARY KEY CLUSTERED 
(
	[FridgeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suppliers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BeginningBalance] [money] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clients]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BeginningBalance] [money] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Additions]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Additions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Additions](
	[ID] [bigint] IDENTITY(2,2) NOT NULL,
	[Inserted] [money] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Additions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Flags]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Flags]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Flags](
	[Name] [nvarchar](50) NOT NULL,
	[Value] [money] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Expenses Types]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses Types]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Expenses Types](
	[ExpenseTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Expenses Types] PRIMARY KEY CLUSTERED 
(
	[ExpenseTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[RawKinds]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RawKinds]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RawKinds](
	[RawID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RawKinds] PRIMARY KEY CLUSTERED 
(
	[RawID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Purchases]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Purchases](
	[PurchaseID] [bigint] IDENTITY(1,1) NOT NULL,
	[RawID] [int] NOT NULL,
	[N_Cages] [int] NULL,
	[Date] [datetime] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[KiloPrice] [money] NOT NULL,
	[N_Kilos] [int] NOT NULL,
	[Paid] [money] NOT NULL,
	[CagePrice] [money] NOT NULL,
	[BillNO] [bigint] NULL,
 CONSTRAINT [PK_Purchases] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Manufacturings]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Manufacturings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Manufacturings](
	[ManufacutringID] [bigint] IDENTITY(1,1) NOT NULL,
	[RawID] [int] NOT NULL,
	[RawWeight] [int] NOT NULL,
	[RawPrice] [money] NOT NULL,
	[SugarPrice] [money] NOT NULL,
	[JerkinPrice] [money] NOT NULL,
	[Date] [datetime] NOT NULL,
	[QauntityInLiters] [int] NOT NULL,
	[SalesKindID] [smallint] NOT NULL,
 CONSTRAINT [PK_Manufacturings] PRIMARY KEY CLUSTERED 
(
	[ManufacutringID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FridgeStorages]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FridgeStorages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FridgeStorages](
	[FridgeStorageID] [bigint] IDENTITY(1,1) NOT NULL,
	[FridgeID] [int] NOT NULL,
	[RawID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[N_Cages] [int] NOT NULL,
	[N_Kilos] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[RecieptNo] [bigint] NOT NULL,
 CONSTRAINT [PK_FridgeStorages] PRIMARY KEY CLUSTERED 
(
	[FridgeStorageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expenses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Expenses](
	[ExpenseID] [bigint] IDENTITY(1,1) NOT NULL,
	[ExpenseTypeID] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[Date] [datetime] NOT NULL,
	[OrderForPayment] [bigint] NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[ExpenseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sales]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sales](
	[SaleID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Gained] [money] NOT NULL,
	[BillNO] [bigint] NULL,
 CONSTRAINT [PK_SoldItems] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SalesSubKinds]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesSubKinds]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesSubKinds](
	[SalesKindID] [smallint] NOT NULL,
	[SalesSubKindID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TableTypes] PRIMARY KEY CLUSTERED 
(
	[SalesKindID] ASC,
	[SalesSubKindID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FridgeOuts]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FridgeOuts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FridgeOuts](
	[FridgeOutID] [bigint] IDENTITY(1,1) NOT NULL,
	[FridgeID] [int] NOT NULL,
	[RawID] [int] NOT NULL,
	[N_Cages] [int] NOT NULL,
	[N_Kilos] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[DismissalNoticeNo] [bigint] NOT NULL,
	[ClientID] [int] NOT NULL,
 CONSTRAINT [PK_FridgeOuts] PRIMARY KEY CLUSTERED 
(
	[FridgeOutID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SalesItems]    Script Date: 06/25/2010 17:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesItems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesItems](
	[SaleItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleID] [bigint] NOT NULL,
	[SalesKindID] [smallint] NOT NULL,
	[SalesSubKindID] [smallint] NOT NULL,
	[PiecePrice] [money] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_SalesItems] PRIMARY KEY CLUSTERED 
(
	[SaleItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Default [DF_Kinds_Description]    Script Date: 06/25/2010 17:53:26 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Kinds_Description]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesKinds]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Kinds_Description]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SalesKinds] ADD  CONSTRAINT [DF_Kinds_Description]  DEFAULT (N'وصف') FOR [Name]
END


End
GO
/****** Object:  ForeignKey [FK_Expenses_Expenses Types]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Expenses_Expenses Types]') AND parent_object_id = OBJECT_ID(N'[dbo].[Expenses]'))
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Expenses Types] FOREIGN KEY([ExpenseTypeID])
REFERENCES [dbo].[Expenses Types] ([ExpenseTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Expenses_Expenses Types]') AND parent_object_id = OBJECT_ID(N'[dbo].[Expenses]'))
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Expenses Types]
GO
/****** Object:  ForeignKey [FK_FridgeOuts_Clients]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeOuts_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeOuts]'))
ALTER TABLE [dbo].[FridgeOuts]  WITH CHECK ADD  CONSTRAINT [FK_FridgeOuts_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeOuts_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeOuts]'))
ALTER TABLE [dbo].[FridgeOuts] CHECK CONSTRAINT [FK_FridgeOuts_Clients]
GO
/****** Object:  ForeignKey [FK_FridgeOuts_Fridges]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeOuts_Fridges]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeOuts]'))
ALTER TABLE [dbo].[FridgeOuts]  WITH CHECK ADD  CONSTRAINT [FK_FridgeOuts_Fridges] FOREIGN KEY([FridgeID])
REFERENCES [dbo].[Fridges] ([FridgeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeOuts_Fridges]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeOuts]'))
ALTER TABLE [dbo].[FridgeOuts] CHECK CONSTRAINT [FK_FridgeOuts_Fridges]
GO
/****** Object:  ForeignKey [FK_FridgeOuts_RawKinds]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeOuts_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeOuts]'))
ALTER TABLE [dbo].[FridgeOuts]  WITH CHECK ADD  CONSTRAINT [FK_FridgeOuts_RawKinds] FOREIGN KEY([RawID])
REFERENCES [dbo].[RawKinds] ([RawID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeOuts_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeOuts]'))
ALTER TABLE [dbo].[FridgeOuts] CHECK CONSTRAINT [FK_FridgeOuts_RawKinds]
GO
/****** Object:  ForeignKey [FK_FridgeStorages_Fridges]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeStorages_Fridges]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeStorages]'))
ALTER TABLE [dbo].[FridgeStorages]  WITH CHECK ADD  CONSTRAINT [FK_FridgeStorages_Fridges] FOREIGN KEY([FridgeID])
REFERENCES [dbo].[Fridges] ([FridgeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeStorages_Fridges]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeStorages]'))
ALTER TABLE [dbo].[FridgeStorages] CHECK CONSTRAINT [FK_FridgeStorages_Fridges]
GO
/****** Object:  ForeignKey [FK_FridgeStorages_RawKinds]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeStorages_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeStorages]'))
ALTER TABLE [dbo].[FridgeStorages]  WITH CHECK ADD  CONSTRAINT [FK_FridgeStorages_RawKinds] FOREIGN KEY([RawID])
REFERENCES [dbo].[RawKinds] ([RawID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeStorages_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeStorages]'))
ALTER TABLE [dbo].[FridgeStorages] CHECK CONSTRAINT [FK_FridgeStorages_RawKinds]
GO
/****** Object:  ForeignKey [FK_FridgeStorages_Suppliers]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeStorages_Suppliers]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeStorages]'))
ALTER TABLE [dbo].[FridgeStorages]  WITH CHECK ADD  CONSTRAINT [FK_FridgeStorages_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FridgeStorages_Suppliers]') AND parent_object_id = OBJECT_ID(N'[dbo].[FridgeStorages]'))
ALTER TABLE [dbo].[FridgeStorages] CHECK CONSTRAINT [FK_FridgeStorages_Suppliers]
GO
/****** Object:  ForeignKey [FK_Manufacturings_RawKinds]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Manufacturings_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[Manufacturings]'))
ALTER TABLE [dbo].[Manufacturings]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturings_RawKinds] FOREIGN KEY([RawID])
REFERENCES [dbo].[RawKinds] ([RawID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Manufacturings_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[Manufacturings]'))
ALTER TABLE [dbo].[Manufacturings] CHECK CONSTRAINT [FK_Manufacturings_RawKinds]
GO
/****** Object:  ForeignKey [FK_Manufacturings_SalesKinds]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Manufacturings_SalesKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[Manufacturings]'))
ALTER TABLE [dbo].[Manufacturings]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturings_SalesKinds] FOREIGN KEY([SalesKindID])
REFERENCES [dbo].[SalesKinds] ([SalesKindID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Manufacturings_SalesKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[Manufacturings]'))
ALTER TABLE [dbo].[Manufacturings] CHECK CONSTRAINT [FK_Manufacturings_SalesKinds]
GO
/****** Object:  ForeignKey [FK_Purchases_RawKinds]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Purchases_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[Purchases]'))
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_RawKinds] FOREIGN KEY([RawID])
REFERENCES [dbo].[RawKinds] ([RawID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Purchases_RawKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[Purchases]'))
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_RawKinds]
GO
/****** Object:  ForeignKey [FK_Purchases_Supplier]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Purchases_Supplier]') AND parent_object_id = OBJECT_ID(N'[dbo].[Purchases]'))
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Purchases_Supplier]') AND parent_object_id = OBJECT_ID(N'[dbo].[Purchases]'))
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Supplier]
GO
/****** Object:  ForeignKey [FK_Sales _Clients]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sales _Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sales]'))
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales _Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sales _Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sales]'))
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales _Clients]
GO
/****** Object:  ForeignKey [FK_SalesItems_Sales]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesItems_Sales]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesItems]'))
ALTER TABLE [dbo].[SalesItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesItems_Sales] FOREIGN KEY([SaleID])
REFERENCES [dbo].[Sales] ([SaleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesItems_Sales]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesItems]'))
ALTER TABLE [dbo].[SalesItems] CHECK CONSTRAINT [FK_SalesItems_Sales]
GO
/****** Object:  ForeignKey [FK_SalesItems_SalesSubKinds]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesItems_SalesSubKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesItems]'))
ALTER TABLE [dbo].[SalesItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesItems_SalesSubKinds] FOREIGN KEY([SalesKindID], [SalesSubKindID])
REFERENCES [dbo].[SalesSubKinds] ([SalesKindID], [SalesSubKindID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesItems_SalesSubKinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesItems]'))
ALTER TABLE [dbo].[SalesItems] CHECK CONSTRAINT [FK_SalesItems_SalesSubKinds]
GO
/****** Object:  ForeignKey [FK_Models_Kinds]    Script Date: 06/25/2010 17:53:26 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Models_Kinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesSubKinds]'))
ALTER TABLE [dbo].[SalesSubKinds]  WITH CHECK ADD  CONSTRAINT [FK_Models_Kinds] FOREIGN KEY([SalesKindID])
REFERENCES [dbo].[SalesKinds] ([SalesKindID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Models_Kinds]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesSubKinds]'))
ALTER TABLE [dbo].[SalesSubKinds] CHECK CONSTRAINT [FK_Models_Kinds]
GO
