USE [master]
GO
/****** Object:  Database [MaxiTechTestEmployeeBeneficiary]    Script Date: 6/3/2024 8:58:48 PM ******/
CREATE DATABASE [MaxiTechTestEmployeeBeneficiary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MaxiTechTestEmployeeBeneficiary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MaxiTechTestEmployeeBeneficiary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MaxiTechTestEmployeeBeneficiary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MaxiTechTestEmployeeBeneficiary_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MaxiTechTestEmployeeBeneficiary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET  MULTI_USER 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET QUERY_STORE = ON
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MaxiTechTestEmployeeBeneficiary]
GO
/****** Object:  Table [dbo].[Beneficiaries]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiaries](
	[BeneficiaryId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[NationalityId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [smalldatetime] NOT NULL,
	[Curp] [nvarchar](18) NOT NULL,
	[Ssn] [nvarchar](20) NOT NULL,
	[Phone] [bigint] NOT NULL,
	[ParticipationPercentage] [int] NOT NULL,
 CONSTRAINT [PK_Beneficiaries] PRIMARY KEY CLUSTERED 
(
	[BeneficiaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[NationalityId] [int] NOT NULL,
	[EmployeeNumber] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [smalldatetime] NOT NULL,
	[Curp] [nvarchar](18) NOT NULL,
	[Ssn] [nvarchar](20) NOT NULL,
	[Phone] [bigint] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogs](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[ErrorNumber] [int] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorProcedure] [nvarchar](max) NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_ErrorLogs] PRIMARY KEY CLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nationalities]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationalities](
	[NationalityId] [int] IDENTITY(1,1) NOT NULL,
	[NationalityName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Nationalities] PRIMARY KEY CLUSTERED 
(
	[NationalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ErrorLogs] ADD  CONSTRAINT [DF_ErrorLogs_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
ALTER TABLE [dbo].[Beneficiaries]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiaries_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Beneficiaries] CHECK CONSTRAINT [FK_Beneficiaries_Employees]
GO
ALTER TABLE [dbo].[Beneficiaries]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiaries_Nationalities] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationalities] ([NationalityId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Beneficiaries] CHECK CONSTRAINT [FK_Beneficiaries_Nationalities]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Nationalities] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationalities] ([NationalityId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Nationalities]
GO
/****** Object:  StoredProcedure [dbo].[SPAddBeneficiary]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Add new beneficiary
-- =============================================
CREATE PROCEDURE [dbo].[SPAddBeneficiary] 
	@EmployeeId		int,
	@NationalityId	int,
	@Name			nvarchar(50),
	@LastName		nvarchar(50),
	@BirthDate		smalldatetime,
	@Curp			nvarchar(18),
	@Ssn			nvarchar(20),
	@Phone			bigint,
	@ParticipationPercentage int
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @Result INT = 0,
			@TransactionName VARCHAR(20) = 'AddBeneficiary'

	BEGIN TRANSACTION @TransactionName
  
	BEGIN TRY
		INSERT INTO [dbo].[Beneficiaries]
			   ([EmployeeId]
			   ,[NationalityId]
			   ,[Name]
			   ,[LastName]
			   ,[BirthDate]
			   ,[Curp]
			   ,[Ssn]
			   ,[Phone]
			   ,[ParticipationPercentage])
		 VALUES
			   (@EmployeeId
			   ,@NationalityId
			   ,@Name
			   ,@LastName
			   ,@BirthDate
			   ,@Curp
			   ,@Ssn
			   ,@Phone
			   ,@ParticipationPercentage)

		SELECT @Result = SCOPE_IDENTITY()


	END TRY  
	BEGIN CATCH  
		ROLLBACK TRANSACTION @TransactionName
		DECLARE @ErNumber INT
				,@ErSeverity INT
				,@ErState INT
				,@ErProcedure NVARCHAR(MAX)
				,@ErLine INT
				,@ErMessage NVARCHAR(MAX)

		SELECT  
			@ErNumber = ERROR_NUMBER()
			,@ErSeverity = ERROR_SEVERITY()
			,@ErState = ERROR_STATE()
			,@ErProcedure = ERROR_PROCEDURE()
			,@ErLine = ERROR_LINE()
			,@ErMessage = ERROR_MESSAGE()

		EXEC SPAddErrorLog
			@ErrorNumber = @ErNumber
			,@ErrorSeverity = @ErSeverity
			,@ErrorState = @ErState
			,@ErrorProcedure = @ErProcedure
			,@ErrorLine = @ErLine
			,@ErrorMessage = @ErMessage

		SET @Result = 0
			
	END CATCH

    IF @Result > 0
		COMMIT TRANSACTION @TransactionName

    SELECT @Result AS ResultId
END
GO
/****** Object:  StoredProcedure [dbo].[SPAddEmployee]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Add new employee
-- =============================================
CREATE PROCEDURE [dbo].[SPAddEmployee] 
	@NationalityId	int			,
	@EmployeeNumber nvarchar(20),
	@Name			nvarchar(50),
	@LastName		nvarchar(50),
	@BirthDate		smalldatetime,
	@Curp			nvarchar(18),
	@Ssn			nvarchar(20),
	@Phone			bigint
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @Result INT = 0,
			@TransactionName VARCHAR(20) = 'AddEmployee'

	BEGIN TRANSACTION @TransactionName
  
	BEGIN TRY  
		INSERT INTO [dbo].[Employees]
			   ([NationalityId]
			   ,[EmployeeNumber]
			   ,[Name]
			   ,[LastName]
			   ,[BirthDate]
			   ,[Curp]
			   ,[Ssn]
			   ,[Phone])
		 VALUES
			   (@NationalityId,
			   @EmployeeNumber,
			   @Name,
			   @LastName,
			   @BirthDate,
			   @Curp,
			   @Ssn,
			   @Phone)

		SELECT @Result = SCOPE_IDENTITY()


	END TRY  
	BEGIN CATCH  
		ROLLBACK TRANSACTION @TransactionName
		DECLARE @ErNumber INT
				,@ErSeverity INT
				,@ErState INT
				,@ErProcedure NVARCHAR(MAX)
				,@ErLine INT
				,@ErMessage NVARCHAR(MAX)

		SELECT  
			@ErNumber = ERROR_NUMBER()
			,@ErSeverity = ERROR_SEVERITY()
			,@ErState = ERROR_STATE()
			,@ErProcedure = ERROR_PROCEDURE()
			,@ErLine = ERROR_LINE()
			,@ErMessage = ERROR_MESSAGE()

		EXEC SPAddErrorLog
			@ErrorNumber = @ErNumber
			,@ErrorSeverity = @ErSeverity
			,@ErrorState = @ErState
			,@ErrorProcedure = @ErProcedure
			,@ErrorLine = @ErLine
			,@ErrorMessage = @ErMessage

		SET @Result = 0
			
	END CATCH

    IF @Result > 0
		COMMIT TRANSACTION @TransactionName

    SELECT @Result AS ResultId
END
GO
/****** Object:  StoredProcedure [dbo].[SPAddErrorLog]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Add new error log
-- =============================================
CREATE PROCEDURE [dbo].[SPAddErrorLog]
	@ErrorNumber	int					NULL,
	@ErrorSeverity	int					NULL,
	@ErrorState		int					NULL,
	@ErrorProcedure	nvarchar(max)		NULL,
	@ErrorLine		int					NULL,
	@ErrorMessage	nvarchar(max)		NULL
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [dbo].[ErrorLogs]
			   ([ErrorNumber]
			   ,[ErrorSeverity]
			   ,[ErrorState]
			   ,[ErrorProcedure]
			   ,[ErrorLine]
			   ,[ErrorMessage])
		 VALUES
			   (@ErrorNumber
			   ,@ErrorSeverity
			   ,@ErrorState
			   ,@ErrorProcedure
			   ,@ErrorLine
			   ,@ErrorMessage)

END
GO
/****** Object:  StoredProcedure [dbo].[SPDeleteBeneficiary]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Delete Beneficiary
-- =============================================
CREATE PROCEDURE [dbo].[SPDeleteBeneficiary]
	@BeneficiaryId		int
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE @Result INT = 0,
			@TransactionName VARCHAR(20) = 'DeleteBeneficiary'

	BEGIN TRANSACTION @TransactionName
  
	BEGIN TRY  
		DELETE FROM [dbo].[Beneficiaries] 
		WHERE BeneficiaryId = @BeneficiaryId

		SELECT @Result = 1

	END TRY  
	BEGIN CATCH  
		ROLLBACK TRANSACTION @TransactionName
		DECLARE @ErNumber INT
				,@ErSeverity INT
				,@ErState INT
				,@ErProcedure NVARCHAR(MAX)
				,@ErLine INT
				,@ErMessage NVARCHAR(MAX)

		SELECT  
			@ErNumber = ERROR_NUMBER()
			,@ErSeverity = ERROR_SEVERITY()
			,@ErState = ERROR_STATE()
			,@ErProcedure = ERROR_PROCEDURE()
			,@ErLine = ERROR_LINE()
			,@ErMessage = ERROR_MESSAGE()

		EXEC SPAddErrorLog
			@ErrorNumber = @ErNumber
			,@ErrorSeverity = @ErSeverity
			,@ErrorState = @ErState
			,@ErrorProcedure = @ErProcedure
			,@ErrorLine = @ErLine
			,@ErrorMessage = @ErMessage

		SET @Result = 0
			
	END CATCH

	IF @Result = 1
		COMMIT TRANSACTION @TransactionName

    SELECT @Result AS ResultId
END
GO
/****** Object:  StoredProcedure [dbo].[SPDeleteEmployee]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Delete employee
-- =============================================
CREATE PROCEDURE [dbo].[SPDeleteEmployee]
	@EmployeeId		int
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE @Result INT = 0,
			@TransactionName VARCHAR(20) = 'DeleteEmployee'

	BEGIN TRANSACTION @TransactionName
  
	BEGIN TRY  
		DELETE FROM [dbo].[Employees] 
		WHERE EmployeeId = @EmployeeId

		SELECT @Result = 1

	END TRY  
	BEGIN CATCH  
		ROLLBACK TRANSACTION @TransactionName
		DECLARE @ErNumber INT
				,@ErSeverity INT
				,@ErState INT
				,@ErProcedure NVARCHAR(MAX)
				,@ErLine INT
				,@ErMessage NVARCHAR(MAX)

		SELECT  
			@ErNumber = ERROR_NUMBER()
			,@ErSeverity = ERROR_SEVERITY()
			,@ErState = ERROR_STATE()
			,@ErProcedure = ERROR_PROCEDURE()
			,@ErLine = ERROR_LINE()
			,@ErMessage = ERROR_MESSAGE()

		EXEC SPAddErrorLog
			@ErrorNumber = @ErNumber
			,@ErrorSeverity = @ErSeverity
			,@ErrorState = @ErState
			,@ErrorProcedure = @ErProcedure
			,@ErrorLine = @ErLine
			,@ErrorMessage = @ErMessage

		SET @Result = 0
			
	END CATCH

	IF @Result = 1
		COMMIT TRANSACTION @TransactionName

    SELECT @Result AS ResultId
END
GO
/****** Object:  StoredProcedure [dbo].[SPEditBeneficiary]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Edit beneficiary
-- =============================================
CREATE PROCEDURE [dbo].[SPEditBeneficiary] 
	@BeneficiaryId	int,
	@NationalityId	int,
	@Name			nvarchar(50),
	@LastName		nvarchar(50),
	@BirthDate		smalldatetime,
	@Curp			nvarchar(18),
	@Ssn			nvarchar(20),
	@Phone			bigint,
	@ParticipationPercentage int
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE @Result INT = 0,
			@TransactionName VARCHAR(20) = 'EditBeneficiary'

	BEGIN TRANSACTION @TransactionName
  
	BEGIN TRY  
		UPDATE [dbo].[Beneficiaries] SET
			   [NationalityId]		= @NationalityId
			   ,[Name]				= @Name
			   ,[LastName]			= @LastName
			   ,[BirthDate]			= @BirthDate
			   ,[Curp]				= @Curp
			   ,[Ssn]				= @Ssn
			   ,[Phone]				= @Phone
			   ,[ParticipationPercentage] = @ParticipationPercentage
		WHERE BeneficiaryId = @BeneficiaryId

		SELECT @Result = @BeneficiaryId

	END TRY  
	BEGIN CATCH  
		ROLLBACK TRANSACTION @TransactionName
		DECLARE @ErNumber INT
				,@ErSeverity INT
				,@ErState INT
				,@ErProcedure NVARCHAR(MAX)
				,@ErLine INT
				,@ErMessage NVARCHAR(MAX)

		SELECT  
			@ErNumber = ERROR_NUMBER()
			,@ErSeverity = ERROR_SEVERITY()
			,@ErState = ERROR_STATE()
			,@ErProcedure = ERROR_PROCEDURE()
			,@ErLine = ERROR_LINE()
			,@ErMessage = ERROR_MESSAGE()

		EXEC SPAddErrorLog
			@ErrorNumber = @ErNumber
			,@ErrorSeverity = @ErSeverity
			,@ErrorState = @ErState
			,@ErrorProcedure = @ErProcedure
			,@ErrorLine = @ErLine
			,@ErrorMessage = @ErMessage

		SET @Result = 0
			
	END CATCH

    IF @Result > 0
		COMMIT TRANSACTION @TransactionName

    SELECT @Result AS ResultId
END
GO
/****** Object:  StoredProcedure [dbo].[SPEditEmployee]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Edit employee
-- =============================================
CREATE PROCEDURE [dbo].[SPEditEmployee] 
	@EmployeeId		int,
	@NationalityId	int			,
	@EmployeeNumber nvarchar(20),
	@Name			nvarchar(50),
	@LastName		nvarchar(50),
	@BirthDate		smalldatetime,
	@Curp			nvarchar(18),
	@Ssn			nvarchar(20),
	@Phone			bigint
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE @Result INT = 0,
			@TransactionName VARCHAR(20) = 'EditEmployee'

	BEGIN TRANSACTION @TransactionName
  
	BEGIN TRY  
		UPDATE [dbo].[Employees] SET
			   [NationalityId]		= @NationalityId
			   ,[EmployeeNumber]	= @EmployeeNumber
			   ,[Name]				= @Name
			   ,[LastName]			= @LastName
			   ,[BirthDate]			= @BirthDate
			   ,[Curp]				= @Curp
			   ,[Ssn]				= @Ssn
			   ,[Phone]				= @Phone
		WHERE EmployeeId = @EmployeeId

		SELECT @Result = @EmployeeId

	END TRY  
	BEGIN CATCH  
		ROLLBACK TRANSACTION @TransactionName
		DECLARE @ErNumber INT
				,@ErSeverity INT
				,@ErState INT
				,@ErProcedure NVARCHAR(MAX)
				,@ErLine INT
				,@ErMessage NVARCHAR(MAX)

		SELECT  
			@ErNumber = ERROR_NUMBER()
			,@ErSeverity = ERROR_SEVERITY()
			,@ErState = ERROR_STATE()
			,@ErProcedure = ERROR_PROCEDURE()
			,@ErLine = ERROR_LINE()
			,@ErMessage = ERROR_MESSAGE()

		EXEC SPAddErrorLog
			@ErrorNumber = @ErNumber
			,@ErrorSeverity = @ErSeverity
			,@ErrorState = @ErState
			,@ErrorProcedure = @ErProcedure
			,@ErrorLine = @ErLine
			,@ErrorMessage = @ErMessage

		SET @Result = 0
			
	END CATCH

    IF @Result > 0
		COMMIT TRANSACTION @TransactionName

    SELECT @Result AS ResultId
END
GO
/****** Object:  StoredProcedure [dbo].[SPGetAllBeneficiaries]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Get all beneficiaries
-- =============================================
CREATE PROCEDURE [dbo].[SPGetAllBeneficiaries]
	@EmployeeId int
AS
BEGIN

	SET NOCOUNT ON

		SELECT b.[BeneficiaryId]
			  ,b.[EmployeeId]
			  ,b.[NationalityId]
			  ,b.[Name]
			  ,b.[LastName]
			  ,b.[BirthDate]
			  ,b.[Curp]
			  ,b.[Ssn]
			  ,b.[Phone]
			  ,b.[ParticipationPercentage]
			  ,n.NationalityName
		FROM [dbo].[Beneficiaries] b WITH(NOLOCK) INNER JOIN
			 [dbo].[Nationalities] n WITH(NOLOCK) ON b.NationalityId = n.NationalityId
		WHERE	b.EmployeeId = @EmployeeId
END
GO
/****** Object:  StoredProcedure [dbo].[SPGetAllEmployees]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Get all employees
-- =============================================
CREATE PROCEDURE [dbo].[SPGetAllEmployees]
AS
BEGIN

	SET NOCOUNT ON

		SELECT e.[EmployeeId]
			  ,e.[NationalityId]
			  ,e.[EmployeeNumber]
			  ,e.[Name]
			  ,e.[LastName]
			  ,e.[BirthDate]
			  ,e.[Curp]
			  ,e.[Ssn]
			  ,e.[Phone]
			  ,(
				SELECT	COUNT(BeneficiaryId) 
				FROM	[dbo].[Beneficiaries]  WITH(NOLOCK)
				WHERE	EmployeeId = e.EmployeeId
			   ) AS BeneficiariesCount
			  ,n.NationalityName
		FROM [dbo].[Employees] e WITH(NOLOCK) INNER JOIN
			 [dbo].[Nationalities] n WITH(NOLOCK) ON e.NationalityId = n.NationalityId
END
GO
/****** Object:  StoredProcedure [dbo].[SPGetBeneficiary]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Get all beneficiaries
-- =============================================
CREATE PROCEDURE [dbo].[SPGetBeneficiary]
	@BeneficiaryId int
AS
BEGIN

	SET NOCOUNT ON

		SELECT b.[BeneficiaryId]
			  ,b.[EmployeeId]
			  ,b.[NationalityId]
			  ,b.[Name]
			  ,b.[LastName]
			  ,b.[BirthDate]
			  ,b.[Curp]
			  ,b.[Ssn]
			  ,b.[Phone]
			  ,b.[ParticipationPercentage]
		FROM [dbo].[Beneficiaries] b WITH(NOLOCK) INNER JOIN
			 [dbo].[Nationalities] n WITH(NOLOCK) ON b.NationalityId = n.NationalityId
		WHERE	b.BeneficiaryId = @BeneficiaryId
END
GO
/****** Object:  StoredProcedure [dbo].[SPGetEmployee]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Get one employee
-- =============================================
CREATE PROCEDURE [dbo].[SPGetEmployee]
	@EmployeeId		int
AS
BEGIN
	
	SET NOCOUNT ON;
    
		SELECT e.[EmployeeId]
			  ,e.[NationalityId]
			  ,e.[EmployeeNumber]
			  ,e.[Name]
			  ,e.[LastName]
			  ,e.[BirthDate]
			  ,e.[Curp]
			  ,e.[Ssn]
			  ,e.[Phone]
			  ,(
				SELECT	COUNT(BeneficiaryId) 
				FROM	[dbo].[Beneficiaries]  WITH(NOLOCK)
				WHERE	EmployeeId = e.EmployeeId
			   ) AS BeneficiariesCount
			  ,n.NationalityName
		FROM [dbo].[Employees] e WITH(NOLOCK) INNER JOIN
			 [dbo].[Nationalities] n WITH(NOLOCK) ON e.NationalityId = n.NationalityId
		WHERE EmployeeId = @EmployeeId
END
GO
/****** Object:  StoredProcedure [dbo].[SPGetNationalities]    Script Date: 6/3/2024 8:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Salomon
-- Create date: 2024-06-02
-- Description:	Get all nationalities
-- =============================================
CREATE PROCEDURE [dbo].[SPGetNationalities]
AS
BEGIN

	SET NOCOUNT ON

		SELECT n.NationalityId
			  ,n.NationalityName
		FROM [dbo].[Nationalities] n WITH(NOLOCK)
END
GO
USE [master]
GO
ALTER DATABASE [MaxiTechTestEmployeeBeneficiary] SET  READ_WRITE 
GO

SET IDENTITY_INSERT [dbo].[Nationalities] ON 

INSERT [dbo].[Nationalities] ([NationalityId], [NationalityName]) VALUES (1, N'Mexican')
INSERT [dbo].[Nationalities] ([NationalityId], [NationalityName]) VALUES (2, N'American')
INSERT [dbo].[Nationalities] ([NationalityId], [NationalityName]) VALUES (3, N'Indian')
INSERT [dbo].[Nationalities] ([NationalityId], [NationalityName]) VALUES (4, N'Colombian')
SET IDENTITY_INSERT [dbo].[Nationalities] OFF
GO
