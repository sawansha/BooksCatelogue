USE [Northwind]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 3/12/2022 9:41:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Books(

	[ISBN] [nchar](13) NOT NULL,
	[Authors] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[PublicationDate] [datetime] NOT NULL ,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	ISBN ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


