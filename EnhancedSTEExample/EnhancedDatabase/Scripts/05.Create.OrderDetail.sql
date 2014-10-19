USE [EnhancedSTE]
GO

/****** Object:  Table [dbo].[OrderDetail]    Script Date: 09/27/2010 20:57:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderDetail](
	[OrderHeaderID] [int] NOT NULL,
	[LineNumber] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderHeaderID] ASC,
	[LineNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_OrderHeader] FOREIGN KEY([OrderHeaderID])
REFERENCES [dbo].[OrderHeader] ([OrderHeaderID])
GO

ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_OrderHeader]
GO

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO

ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO


