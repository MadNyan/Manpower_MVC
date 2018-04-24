CREATE TABLE [dbo].[WorkList] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [SerialNum]  NVARCHAR (50) NOT NULL,
    [SingleNum]  NVARCHAR (50) NULL,
    [CreateDate] DATE          NOT NULL,
    [BuildingID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Worker] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [SalaryDay]      INT           DEFAULT ((0)) NOT NULL,
    [OvertimeHr]     INT           DEFAULT ((0)) NOT NULL,
    [OverOvertimeHr] INT           DEFAULT ((0)) NOT NULL,
    [ListID]         INT           NOT NULL,
    [EmpID]          INT           NOT NULL,
    [WorkCareID]     INT           NOT NULL,
    [Remark]         NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[WorkCategory] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [WorkCareID]      NVARCHAR (50) NOT NULL,
    [WorkCareName]    NVARCHAR (50) NOT NULL,
    [Salary]          INT           NOT NULL,
    [OvertimeSal]     INT           NOT NULL,
    [OverOvertimeSal] INT           NOT NULL,
    [Remark]          NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[WorkRight] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [EmpID]          INT           NOT NULL,
    [WorkCateID]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[User] (
    [ID]             INT IDENTITY (1, 1) NOT NULL,
    [Account]        NVARCHAR (50) NOT NULL,
    [Password]       NVARCHAR (50) NOT NULL,
    [Name] 			 NVARCHAR (50) NOT NULL,
    [isAdmin]        BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[OwnerPayment] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [PayID]   NVARCHAR (50) NOT NULL,
    [OwnerID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[OwnerPayWork] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
	[SalaryDay]      INT           DEFAULT ((0)) NOT NULL,
    [OvertimeHr]     INT           DEFAULT ((0)) NOT NULL,
    [OverOvertimeHr] INT           DEFAULT ((0)) NOT NULL,
    [WorkCareID]     INT           NOT NULL,
	[PayID]     INT           NOT NULL,
	[Remark] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[OwnerBuilding] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [BuildingName] NVARCHAR (50) NOT NULL,
    [ConPerson]    NVARCHAR (50) NULL,
    [ConPersonTel] NVARCHAR (50) NULL,
    [Address]      NVARCHAR (50) NULL,
    [OwnerID]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Owner] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [OwnerID]        NVARCHAR (50) NOT NULL,
    [OwnerName]      NVARCHAR (50) NOT NULL,
    [Tel]            NVARCHAR (50) NULL,
    [Tel2]           NVARCHAR (50) NULL,
    [ConPerson]      NVARCHAR (50) NULL,
    [ConPersonPhone] NVARCHAR (50) NULL,
    [ConPersonTel]   NVARCHAR (50) NULL,
    [UnifiedNum]     NVARCHAR (50) NOT NULL,
    [Address]        NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[InsCate] (
    [ID]       INT           NOT NULL,
    [InsID]    NVARCHAR (50) NOT NULL,
    [InsName]  NVARCHAR (50) NOT NULL,
    [PosOrNeg] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Employee] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [EmpID]        NVARCHAR (50) NOT NULL,
    [EmpName]      NVARCHAR (50) NOT NULL,
    [Tel]          NVARCHAR (50) NULL,
    [Phone]        NVARCHAR (50) NULL,
    [ConPerson]    NVARCHAR (50) NULL,
    [ConPersonTel] NVARCHAR (50) NULL,
    [CreateDate]   DATE          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[EmpInsurance] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Price]  INT           NOT NULL,
    [InsID]  INT           NOT NULL,
    [EmpID]  INT           NOT NULL,
    [Remark] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

