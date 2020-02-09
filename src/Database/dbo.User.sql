USE [APIDatabase]
GO

/****** Object:  Table [dbo].[User]    Script Date: 2/8/2020 10:02:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[CreateAt] [datetime2](7) NULL,
	[UpdateAt] [datetime2](7) NULL,
	[Name] [nvarchar](60) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

