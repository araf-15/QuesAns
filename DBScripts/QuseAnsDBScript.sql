USE [QuesAnsDB]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/19/2022 9:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserType] [nvarchar](20) NOT NULL,
	[PasswordHash] [nvarchar](50) NOT NULL,
	[InstituteName] [nvarchar](50) NOT NULL,
	[InstituteId] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
