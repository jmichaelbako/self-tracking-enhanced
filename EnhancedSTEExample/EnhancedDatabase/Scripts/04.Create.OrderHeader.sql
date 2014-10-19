USE [EnhancedSTE]
GO

/****** Object:  Table [dbo].[OrderHeader]    Script Date: 09/27/2010 20:57:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrderHeader](
	[OrderHeaderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [varchar](10) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalAmount] [money] NOT NULL,
 CONSTRAINT [PK_OrderHeader] PRIMARY KEY CLUSTERED 
(
	[OrderHeaderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


