USE [TimeKeepingDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplySeniorityPolicy]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplySeniorityPolicy](
	[TimeOffPolicyId] [varchar](10) NOT NULL,
	[SeniorityPolicyId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ApplySeniorityPolicy] PRIMARY KEY CLUSTERED 
(
	[TimeOffPolicyId] ASC,
	[SeniorityPolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalProcess]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalProcess](
	[ApprovalProcessId] [varchar](10) NOT NULL,
	[ApprovalProcessName] [nvarchar](50) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_ApprovalProcess] PRIMARY KEY CLUSTERED 
(
	[ApprovalProcessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DayOff]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DayOff](
	[DayOffId] [varchar](10) NOT NULL,
	[TimeOffRequestId] [varchar](10) NOT NULL,
	[DayOffAt] [datetime] NOT NULL,
	[Del] [bit] NULL,
	[FromHour] [varchar](5) NOT NULL,
	[ToHour] [varchar](5) NOT NULL,
 CONSTRAINT [PK_DayOff] PRIMARY KEY CLUSTERED 
(
	[DayOffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaysOfWeek]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaysOfWeek](
	[DaysOfWeekId] [varchar](10) NOT NULL,
	[DaysOfWeekName] [nvarchar](50) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_DaysOfWeek] PRIMARY KEY CLUSTERED 
(
	[DaysOfWeekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormTimeOff]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormTimeOff](
	[FormTimeOffId] [varchar](10) NOT NULL,
	[FormTimeOffName] [nvarchar](50) NOT NULL,
	[TypeTimeOffId] [varchar](10) NOT NULL,
	[RequireApproval] [bit] NOT NULL,
	[ApprovalProcessId] [varchar](10) NOT NULL,
	[RequireLimitedDaysOff] [bit] NOT NULL,
	[ProcessingTime] [tinyint] NULL,
	[NumberOfDaysBeforeTimeOff] [tinyint] NULL,
	[LimitedDaysOff] [tinyint] NULL,
	[Regulations] [nvarchar](100) NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_FormTimeOff] PRIMARY KEY CLUSTERED 
(
	[FormTimeOffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Office]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Office](
	[OfficeId] [varchar](10) NOT NULL,
	[OfficeName] [nvarchar](100) NOT NULL,
	[OfficeAddress] [nvarchar](100) NOT NULL,
	[OfficePhone] [varchar](15) NOT NULL,
	[OfficeEmail] [varchar](50) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED 
(
	[OfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[PersonnelId] [varchar](10) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[OfficeId] [varchar](10) NOT NULL,
	[WorkScheduleId] [varchar](10) NOT NULL,
	[WorkingAreaId] [varchar](10) NOT NULL,
	[PositionId] [varchar](10) NOT NULL,
	[SalaryPolicyId] [varchar](10) NOT NULL,
	[TypePersonnelId] [varchar](10) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[ActualSalary] [money] NOT NULL,
	[BasicSalary] [money] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[OfficialDate] [datetime] NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Phone] [varchar](15) NULL,
	[Sex] [bit] NOT NULL,
	[PersonnelAddress] [nvarchar](100) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_Personnel] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonnelApplyTimeOffPolicy]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonnelApplyTimeOffPolicy](
	[PersonnelId] [varchar](10) NOT NULL,
	[TimeOffPolicyId] [varchar](10) NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[NumberOfDaysOffLastYear] [tinyint] NOT NULL,
	[NumberOfDaysOffStandard] [tinyint] NOT NULL,
	[NumberOfDaysOffSeniority] [tinyint] NOT NULL,
	[NumberOfDaysOffOffset] [tinyint] NOT NULL,
	[Note] [nvarchar](100) NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_PersonnelApplyTimeOffPolicy] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC,
	[TimeOffPolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [varchar](10) NOT NULL,
	[PositionName] [nvarchar](100) NOT NULL,
	[WorkingAreaId] [varchar](10) NOT NULL,
	[TypePositionId] [varchar](10) NOT NULL,
	[LowestSalary] [money] NOT NULL,
	[HighestSalary] [money] NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryPolicy]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryPolicy](
	[SalaryPolicyId] [varchar](10) NOT NULL,
	[SalaryPolicyName] [nvarchar](100) NOT NULL,
	[Describe] [nvarchar](100) NULL,
	[States] [bit] NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_SalaryPolicy] PRIMARY KEY CLUSTERED 
(
	[SalaryPolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeniorityPolicy]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeniorityPolicy](
	[SeniorityPolicyId] [varchar](10) NOT NULL,
	[SeniorityMonth] [int] NOT NULL,
	[PolicyDay] [tinyint] NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_SeniorityPolicy] PRIMARY KEY CLUSTERED 
(
	[SeniorityPolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[WorkScheduleId] [varchar](10) NOT NULL,
	[DaysOfWeekId] [varchar](10) NOT NULL,
	[ShiftId] [varchar](10) NOT NULL,
	[ShiftName] [nvarchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeOffApprover]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeOffApprover](
	[PersonnelId] [varchar](10) NOT NULL,
	[FormTimeOffId] [varchar](10) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TimeOffApprover] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC,
	[FormTimeOffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeOffFollower]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeOffFollower](
	[PersonnelId] [varchar](10) NOT NULL,
	[FormTimeOffId] [varchar](10) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TimeOffFollower] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC,
	[FormTimeOffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeOffPolicy]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeOffPolicy](
	[TimeOffPolicyId] [varchar](10) NOT NULL,
	[TimeOffPolicyName] [nvarchar](100) NOT NULL,
	[TypePolicyId] [varchar](10) NOT NULL,
	[NumberOfDaysOffStandard] [tinyint] NOT NULL,
	[NumberOfDaysOffLastYear] [tinyint] NOT NULL,
	[Describe] [nvarchar](100) NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TimeOffPolicy] PRIMARY KEY CLUSTERED 
(
	[TimeOffPolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeOffRequest]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeOffRequest](
	[PersonnelId] [varchar](10) NOT NULL,
	[TimeOffRequestId] [varchar](10) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[FormTimeOffId] [varchar](10) NOT NULL,
	[Reason] [nvarchar](200) NOT NULL,
	[RequireHandOver] [bit] NOT NULL,
	[HandOverWorks] [nvarchar](200) NULL,
	[ManagerId] [varchar](10) NOT NULL,
	[Attachment] [nvarchar](100) NULL,
	[TimeOffDate] [datetime] NOT NULL,
	[TimeOffRequestStateId] [varchar](10) NOT NULL,
	[Feedback] [nvarchar](100) NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TimeOffRequest] PRIMARY KEY CLUSTERED 
(
	[TimeOffRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeOffRequestState]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeOffRequestState](
	[TimeOffRequestStateId] [varchar](10) NOT NULL,
	[TimeOffRequestStateName] [nvarchar](50) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TimeOffRequestState] PRIMARY KEY CLUSTERED 
(
	[TimeOffRequestStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePersonnel]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePersonnel](
	[TypePersonnelId] [varchar](10) NOT NULL,
	[TypePersonnelName] [nvarchar](100) NOT NULL,
	[Describe] [nvarchar](100) NULL,
	[States] [bit] NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TypePersonnel] PRIMARY KEY CLUSTERED 
(
	[TypePersonnelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePolicy]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePolicy](
	[TypePolicyId] [varchar](10) NOT NULL,
	[TypePolicyName] [nvarchar](50) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TypePolicy] PRIMARY KEY CLUSTERED 
(
	[TypePolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePosition]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePosition](
	[TypePositionId] [varchar](10) NOT NULL,
	[TypePositionName] [nvarchar](50) NOT NULL,
	[Describe] [nvarchar](100) NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TypePosition] PRIMARY KEY CLUSTERED 
(
	[TypePositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeTimeOff]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeTimeOff](
	[TypeTimeOffId] [varchar](10) NOT NULL,
	[TypeTimeOffName] [nvarchar](50) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TypeTimeOff] PRIMARY KEY CLUSTERED 
(
	[TypeTimeOffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeWorkSchedule]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeWorkSchedule](
	[TypeWorkScheduleId] [varchar](10) NOT NULL,
	[TypeWorkScheduleName] [nvarchar](50) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_TypeWorkSchedule] PRIMARY KEY CLUSTERED 
(
	[TypeWorkScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkingArea]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingArea](
	[WorkingAreaId] [varchar](10) NOT NULL,
	[WorkingAreaName] [nvarchar](100) NOT NULL,
	[Describe] [nvarchar](100) NULL,
	[States] [bit] NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_WorkingArea] PRIMARY KEY CLUSTERED 
(
	[WorkingAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkingAreaApplyFormTimeOff]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingAreaApplyFormTimeOff](
	[WorkingAreaId] [varchar](10) NOT NULL,
	[FormTimeOffId] [varchar](10) NOT NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_WorkingAreaApplyFormTimeOff] PRIMARY KEY CLUSTERED 
(
	[WorkingAreaId] ASC,
	[FormTimeOffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkSchedule]    Script Date: 21/12/2021 5:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkSchedule](
	[WorkScheduleId] [varchar](10) NOT NULL,
	[WorkScheduleName] [nvarchar](100) NOT NULL,
	[TypeWorkScheduleId] [varchar](10) NOT NULL,
	[RequireCheckout] [bit] NOT NULL,
	[WorkingHoursPerDay] [tinyint] NULL,
	[MinutesLate] [tinyint] NOT NULL,
	[MinutesEarly] [tinyint] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[States] [bit] NULL,
	[Del] [bit] NULL,
 CONSTRAINT [PK_WorkSchedule] PRIMARY KEY CLUSTERED 
(
	[WorkScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApprovalProcess] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[DayOff] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[DaysOfWeek] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[FormTimeOff] ADD  DEFAULT ((1)) FOR [RequireApproval]
GO
ALTER TABLE [dbo].[FormTimeOff] ADD  DEFAULT ((1)) FOR [RequireLimitedDaysOff]
GO
ALTER TABLE [dbo].[FormTimeOff] ADD  DEFAULT ((24)) FOR [ProcessingTime]
GO
ALTER TABLE [dbo].[FormTimeOff] ADD  DEFAULT ((2)) FOR [NumberOfDaysBeforeTimeOff]
GO
ALTER TABLE [dbo].[FormTimeOff] ADD  DEFAULT ((5)) FOR [LimitedDaysOff]
GO
ALTER TABLE [dbo].[FormTimeOff] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[Office] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[Personnel] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[PersonnelApplyTimeOffPolicy] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[Position] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[SalaryPolicy] ADD  DEFAULT ((1)) FOR [States]
GO
ALTER TABLE [dbo].[SalaryPolicy] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[SeniorityPolicy] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[Shift] ADD  CONSTRAINT [DF__Shift__Del__412EB0B6]  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TimeOffApprover] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TimeOffFollower] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TimeOffPolicy] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TimeOffRequest] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TimeOffRequestState] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TypePersonnel] ADD  DEFAULT ((1)) FOR [States]
GO
ALTER TABLE [dbo].[TypePersonnel] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TypePolicy] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TypePosition] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TypeTimeOff] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[TypeWorkSchedule] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[WorkingArea] ADD  DEFAULT ((1)) FOR [States]
GO
ALTER TABLE [dbo].[WorkingArea] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[WorkingAreaApplyFormTimeOff] ADD  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[WorkSchedule] ADD  CONSTRAINT [DF__WorkSched__Requi__398D8EEE]  DEFAULT ((1)) FOR [RequireCheckout]
GO
ALTER TABLE [dbo].[WorkSchedule] ADD  CONSTRAINT [DF__WorkSched__Worki__3A81B327]  DEFAULT ((8)) FOR [WorkingHoursPerDay]
GO
ALTER TABLE [dbo].[WorkSchedule] ADD  CONSTRAINT [DF__WorkSched__Minut__3B75D760]  DEFAULT ((15)) FOR [MinutesLate]
GO
ALTER TABLE [dbo].[WorkSchedule] ADD  CONSTRAINT [DF__WorkSched__Minut__3C69FB99]  DEFAULT ((15)) FOR [MinutesEarly]
GO
ALTER TABLE [dbo].[WorkSchedule] ADD  CONSTRAINT [DF__WorkSched__State__3D5E1FD2]  DEFAULT ((1)) FOR [States]
GO
ALTER TABLE [dbo].[WorkSchedule] ADD  CONSTRAINT [DF__WorkSchedul__Del__3E52440B]  DEFAULT ((1)) FOR [Del]
GO
ALTER TABLE [dbo].[ApplySeniorityPolicy]  WITH CHECK ADD  CONSTRAINT [PR_ApplySeniorityPolicy_SeniorityPolicy] FOREIGN KEY([SeniorityPolicyId])
REFERENCES [dbo].[SeniorityPolicy] ([SeniorityPolicyId])
GO
ALTER TABLE [dbo].[ApplySeniorityPolicy] CHECK CONSTRAINT [PR_ApplySeniorityPolicy_SeniorityPolicy]
GO
ALTER TABLE [dbo].[ApplySeniorityPolicy]  WITH CHECK ADD  CONSTRAINT [PR_ApplySeniorityPolicy_TimeOffPolicy] FOREIGN KEY([TimeOffPolicyId])
REFERENCES [dbo].[TimeOffPolicy] ([TimeOffPolicyId])
GO
ALTER TABLE [dbo].[ApplySeniorityPolicy] CHECK CONSTRAINT [PR_ApplySeniorityPolicy_TimeOffPolicy]
GO
ALTER TABLE [dbo].[DayOff]  WITH CHECK ADD  CONSTRAINT [PR_DayOff_TimeOffRequest] FOREIGN KEY([TimeOffRequestId])
REFERENCES [dbo].[TimeOffRequest] ([TimeOffRequestId])
GO
ALTER TABLE [dbo].[DayOff] CHECK CONSTRAINT [PR_DayOff_TimeOffRequest]
GO
ALTER TABLE [dbo].[FormTimeOff]  WITH CHECK ADD  CONSTRAINT [PR_FormTimeOff_ApprovalProcess] FOREIGN KEY([ApprovalProcessId])
REFERENCES [dbo].[ApprovalProcess] ([ApprovalProcessId])
GO
ALTER TABLE [dbo].[FormTimeOff] CHECK CONSTRAINT [PR_FormTimeOff_ApprovalProcess]
GO
ALTER TABLE [dbo].[FormTimeOff]  WITH CHECK ADD  CONSTRAINT [PR_FormTimeOff_TypeTimeOff] FOREIGN KEY([TypeTimeOffId])
REFERENCES [dbo].[TypeTimeOff] ([TypeTimeOffId])
GO
ALTER TABLE [dbo].[FormTimeOff] CHECK CONSTRAINT [PR_FormTimeOff_TypeTimeOff]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [PR_Personnel_Office] FOREIGN KEY([OfficeId])
REFERENCES [dbo].[Office] ([OfficeId])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [PR_Personnel_Office]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [PR_Personnel_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [PR_Personnel_Position]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [PR_Personnel_SalaryPolicy] FOREIGN KEY([SalaryPolicyId])
REFERENCES [dbo].[SalaryPolicy] ([SalaryPolicyId])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [PR_Personnel_SalaryPolicy]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [PR_Personnel_TypePersonnel] FOREIGN KEY([TypePersonnelId])
REFERENCES [dbo].[TypePersonnel] ([TypePersonnelId])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [PR_Personnel_TypePersonnel]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [PR_Personnel_WorkingArea] FOREIGN KEY([WorkingAreaId])
REFERENCES [dbo].[WorkingArea] ([WorkingAreaId])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [PR_Personnel_WorkingArea]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [PR_Personnel_WorkSchedule] FOREIGN KEY([WorkScheduleId])
REFERENCES [dbo].[WorkSchedule] ([WorkScheduleId])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [PR_Personnel_WorkSchedule]
GO
ALTER TABLE [dbo].[PersonnelApplyTimeOffPolicy]  WITH CHECK ADD  CONSTRAINT [PR_PersonnelApplyTimeOffPolicy_Personnel] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO
ALTER TABLE [dbo].[PersonnelApplyTimeOffPolicy] CHECK CONSTRAINT [PR_PersonnelApplyTimeOffPolicy_Personnel]
GO
ALTER TABLE [dbo].[PersonnelApplyTimeOffPolicy]  WITH CHECK ADD  CONSTRAINT [PR_PersonnelApplyTimeOffPolicy_TimeOffPolicy] FOREIGN KEY([TimeOffPolicyId])
REFERENCES [dbo].[TimeOffPolicy] ([TimeOffPolicyId])
GO
ALTER TABLE [dbo].[PersonnelApplyTimeOffPolicy] CHECK CONSTRAINT [PR_PersonnelApplyTimeOffPolicy_TimeOffPolicy]
GO
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [PR_Position_TypePosition] FOREIGN KEY([TypePositionId])
REFERENCES [dbo].[TypePosition] ([TypePositionId])
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [PR_Position_TypePosition]
GO
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [PR_Position_WorkingArea] FOREIGN KEY([WorkingAreaId])
REFERENCES [dbo].[WorkingArea] ([WorkingAreaId])
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [PR_Position_WorkingArea]
GO
ALTER TABLE [dbo].[Shift]  WITH CHECK ADD  CONSTRAINT [PR_Shift_DaysOfWeek] FOREIGN KEY([DaysOfWeekId])
REFERENCES [dbo].[DaysOfWeek] ([DaysOfWeekId])
GO
ALTER TABLE [dbo].[Shift] CHECK CONSTRAINT [PR_Shift_DaysOfWeek]
GO
ALTER TABLE [dbo].[Shift]  WITH CHECK ADD  CONSTRAINT [PR_Shift_WorkSchedule] FOREIGN KEY([WorkScheduleId])
REFERENCES [dbo].[WorkSchedule] ([WorkScheduleId])
GO
ALTER TABLE [dbo].[Shift] CHECK CONSTRAINT [PR_Shift_WorkSchedule]
GO
ALTER TABLE [dbo].[TimeOffApprover]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffApprover_FormTimeOff] FOREIGN KEY([FormTimeOffId])
REFERENCES [dbo].[FormTimeOff] ([FormTimeOffId])
GO
ALTER TABLE [dbo].[TimeOffApprover] CHECK CONSTRAINT [PR_TimeOffApprover_FormTimeOff]
GO
ALTER TABLE [dbo].[TimeOffApprover]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffApprover_Personnel] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO
ALTER TABLE [dbo].[TimeOffApprover] CHECK CONSTRAINT [PR_TimeOffApprover_Personnel]
GO
ALTER TABLE [dbo].[TimeOffFollower]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffFollower_FormTimeOff] FOREIGN KEY([FormTimeOffId])
REFERENCES [dbo].[FormTimeOff] ([FormTimeOffId])
GO
ALTER TABLE [dbo].[TimeOffFollower] CHECK CONSTRAINT [PR_TimeOffFollower_FormTimeOff]
GO
ALTER TABLE [dbo].[TimeOffFollower]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffFollower_Personnel] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO
ALTER TABLE [dbo].[TimeOffFollower] CHECK CONSTRAINT [PR_TimeOffFollower_Personnel]
GO
ALTER TABLE [dbo].[TimeOffPolicy]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffPolicy_TypePolicy] FOREIGN KEY([TypePolicyId])
REFERENCES [dbo].[TypePolicy] ([TypePolicyId])
GO
ALTER TABLE [dbo].[TimeOffPolicy] CHECK CONSTRAINT [PR_TimeOffPolicy_TypePolicy]
GO
ALTER TABLE [dbo].[TimeOffRequest]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffRequest_FormTimeOff] FOREIGN KEY([FormTimeOffId])
REFERENCES [dbo].[FormTimeOff] ([FormTimeOffId])
GO
ALTER TABLE [dbo].[TimeOffRequest] CHECK CONSTRAINT [PR_TimeOffRequest_FormTimeOff]
GO
ALTER TABLE [dbo].[TimeOffRequest]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffRequest_Manager] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO
ALTER TABLE [dbo].[TimeOffRequest] CHECK CONSTRAINT [PR_TimeOffRequest_Manager]
GO
ALTER TABLE [dbo].[TimeOffRequest]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffRequest_Personnel] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO
ALTER TABLE [dbo].[TimeOffRequest] CHECK CONSTRAINT [PR_TimeOffRequest_Personnel]
GO
ALTER TABLE [dbo].[TimeOffRequest]  WITH CHECK ADD  CONSTRAINT [PR_TimeOffRequest_TimeOffRequestState] FOREIGN KEY([TimeOffRequestStateId])
REFERENCES [dbo].[TimeOffRequestState] ([TimeOffRequestStateId])
GO
ALTER TABLE [dbo].[TimeOffRequest] CHECK CONSTRAINT [PR_TimeOffRequest_TimeOffRequestState]
GO
ALTER TABLE [dbo].[WorkingAreaApplyFormTimeOff]  WITH CHECK ADD  CONSTRAINT [PR_WorkingAreaApplyFormTimeOff_FormTimeOff] FOREIGN KEY([FormTimeOffId])
REFERENCES [dbo].[FormTimeOff] ([FormTimeOffId])
GO
ALTER TABLE [dbo].[WorkingAreaApplyFormTimeOff] CHECK CONSTRAINT [PR_WorkingAreaApplyFormTimeOff_FormTimeOff]
GO
ALTER TABLE [dbo].[WorkingAreaApplyFormTimeOff]  WITH CHECK ADD  CONSTRAINT [PR_WorkingAreaApplyFormTimeOff_WorkingArea] FOREIGN KEY([WorkingAreaId])
REFERENCES [dbo].[WorkingArea] ([WorkingAreaId])
GO
ALTER TABLE [dbo].[WorkingAreaApplyFormTimeOff] CHECK CONSTRAINT [PR_WorkingAreaApplyFormTimeOff_WorkingArea]
GO
ALTER TABLE [dbo].[WorkSchedule]  WITH CHECK ADD  CONSTRAINT [PR_WorkSchedule_TypeWorkSchedule] FOREIGN KEY([TypeWorkScheduleId])
REFERENCES [dbo].[TypeWorkSchedule] ([TypeWorkScheduleId])
GO
ALTER TABLE [dbo].[WorkSchedule] CHECK CONSTRAINT [PR_WorkSchedule_TypeWorkSchedule]
GO
