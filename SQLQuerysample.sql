USE [sample]
GO
/****** Object:  Table [dbo].[customer_master]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_master](
	[CustomerCode] [bigint] IDENTITY(1,1) NOT NULL,
	[CustName] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Status] [nvarchar](20) NULL,
	[Area] [nvarchar](150) NULL,
	[Address] [nvarchar](250) NULL,
	[AddService] [nvarchar](max) NULL,
 CONSTRAINT [PK_customer_master] PRIMARY KEY CLUSTERED 
(
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service_master]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service_master](
	[ServiceCode] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](150) NULL,
 CONSTRAINT [PK_service_master] PRIMARY KEY CLUSTERED 
(
	[ServiceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[UID] [varchar](50) NULL,
	[PWD] [varchar](250) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[deleteCustomer]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteCustomer]
(
@custid bigint
)
as 
begin
DELETE FROM [dbo].[customer_master]
 WHERE [CustomerCode]=@custid
end
GO
/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetCustomers]
as 
begin
  SELECT  [CustomerCode]
      ,[CustName]
      ,[Email]
      ,[PhoneNumber]
      ,[Status]
      ,[Area]
      ,[Address]
      ,[AddService]
  FROM [sample].[dbo].[customer_master]

end
GO
/****** Object:  StoredProcedure [dbo].[GetCustomersById]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetCustomersById]
(
@Id int
)
as 
begin
SELECT [CustomerCode]
      ,[CustName]
      ,[Email]
      ,[PhoneNumber]
      ,[Status]
      ,[Area]
      ,[Address]
      ,[AddService]
  FROM [sample].[dbo].[customer_master]
  where [CustomerCode]=@Id

end
GO
/****** Object:  StoredProcedure [dbo].[GetServices]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetServices]
as 
begin
SELECT [ServiceCode]
      ,[ServiceName]
  FROM [sample].[dbo].[service_master]
end
GO
/****** Object:  StoredProcedure [dbo].[GetServicesById]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetServicesById]
(
@Id int
)
as 
begin
SELECT  [ServiceCode]
      ,[ServiceName]
  FROM [sample].[dbo].[service_master]
  where [ServiceCode]=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertCustomer]
(
@customername nvarchar(150),
@email nvarchar(150),
@phonenumber nvarchar(15),
@status nvarchar(20),
@area nvarchar(150),
@address nvarchar(250),
@services nvarchar(100)
)
as 
begin
INSERT INTO [dbo].[customer_master]
           ([CustName]
           ,[Email]
           ,[PhoneNumber]
           ,[Status]
           ,[Area]
           ,[Address]
           ,[AddService])
     VALUES
           (@customername
           ,@email
           ,@phonenumber
           ,@status
           ,@area
           ,@address
           ,@services)

end
GO
/****** Object:  StoredProcedure [dbo].[loginUser]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[loginUser]
(
@username varchar(50),
@password varchar(50)
)
as 
begin
Select ID,[FirstName]
      ,[LastName]
      ,[UID]
      ,[PWD]
      ,[Active]  FROM [Sample].[dbo].[users]
	  where [UID] = @username and [PWD]=@password and [Active]=1

end
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 7/28/2021 9:25:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateCustomer]
(
@custid bigint,
@customername nvarchar(150),
@email nvarchar(150),
@phonenumber nvarchar(15),
@status nvarchar(20),
@area nvarchar(150),
@address nvarchar(250),
@services nvarchar(100)
)
as 
begin

		   UPDATE [dbo].[customer_master]
   SET [CustName] = @customername
      ,[Email] = @email
      ,[PhoneNumber] = @phonenumber
      ,[Status] = @status
      ,[Area] = @area
      ,[Address] = @address
      ,[AddService] = @services
 WHERE [CustomerCode]=@custid
end
GO
