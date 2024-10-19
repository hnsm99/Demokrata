IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 25/03/2024 7:29:53 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[SecondFirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SecondLastName] [nvarchar](50) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Salary] [decimal](18, 0) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedAt] [datetime] NULL
) ON [PRIMARY]
GO