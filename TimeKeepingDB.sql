--CREATE DATABASE TimeKeepingDB
--USE TimeKeepingDB 
--GO 
--  Create all tables in DB
-- module 1: "human resource management"
-- This section will store information about employees, offices, etc
CREATE TABLE Office  ( /*1*/
OfficeId varchar(10) not null,
OfficeName Nvarchar(100) not null,
OfficeAddress Nvarchar(100) not null,
OfficePhone varchar(15) not null,
OfficeEmail varchar(50) not null,
Del bit default(1)
);
CREATE TABLE TypeWorkSchedule ( /*1*/
TypeWorkScheduleId varchar(10) not null,
TypeWorkScheduleName Nvarchar(50) not null,
Del bit default(1)
);
CREATE TABLE CheckinPolicy (/*1*/
CheckinPolicyId varchar(10) not null,
CheckinPolicyName Nvarchar(50) not null,
Del bit default(1)
);
CREATE TABLE NumberOfShift /*1*/
(
NumberOfShiftId varchar(10) not null,
NumberOfShift tinyint not null,
Del bit default(1)
);
CREATE TABLE DaysOfWeek( /*1*/
DaysOfWeekId varchar(10) not null,
DaysOfWeekName Nvarchar(50) not null,
Del bit default(1)
);
CREATE TABLE TypeShift( /*1*/
TypeShiftId varchar(10) not null,
TypeShiftName Nvarchar(50) not null,
Del bit default(1)
);
CREATE TABLE WorkingArea ( /*1*/
WorkingAreaId varchar(10) not null,
WorkingAreaName Nvarchar(100) not null,
Describe Nvarchar(100),
States bit default(1),
Del bit default(1)
);
CREATE TABLE TypePosition ( /*1*/
TypePositionId varchar(10) not null,
TypePositionName Nvarchar(50) not null,
Describe Nvarchar(100),
Del bit default(1)
);
CREATE TABLE SalaryPolicy ( /*1*/
SalaryPolicyId varchar(10) not null,
SalaryPolicyName Nvarchar(100) not null,
Describe Nvarchar(100),
States bit default(1),
Del bit default(1)
);

CREATE TABLE TypePersonnel ( /*1*/
TypePersonnelId varchar(10) not null,
TypePersonnelName Nvarchar(100) not null,
Describe Nvarchar(100),
States bit default(1),
Del bit default(1)
);

CREATE TABLE WorkSchedule ( /*2*/
WorkScheduleId varchar(10) not null,
WorkScheduleName Nvarchar(100) not null,
TypeWorkScheduleId varchar(10) not null,
CheckinPolicyId varchar(10) not null,
NumberOfShiftId varchar(10) not null,
RequireCheckout bit default(1) not null,
WorkingHoursPerDay tinyint default(8) not null,
MinutesLate tinyint default(15) not null,
MinutesEarly tinyint default(15) not null,
Regulations Nvarchar(100),
States bit default(1),
Del bit default(1)
);

CREATE TABLE Shift( /*2*/
WorkScheduleId varchar(10) not null,
DaysOfWeekId varchar(10) not null,
ShiftId varchar(10) not null,
TypeShiftId varchar(10) not null,
ShiftName Nvarchar(50) not null, 
StartTime datetime not null,
EndTime datetime not null,
DayOff bit default(1) not null,
Del bit default(1)
);
CREATE TABLE Position ( /*2*/
PositionId varchar(10) not null,
PositionName Nvarchar(100) not null,
WorkingAreaId varchar(10) not null,
TypePositionId varchar(10) not null,
LowestSalary money not null,
HighestSalary money not null,
Del bit default(1)
);

CREATE TABLE Personnel ( /*2*/
PersonnelId varchar(10) not null,
FirstName Nvarchar(100) not null,
LastName Nvarchar(100) not null,
Email varchar(100) not null,
OfficeId varchar(10) not null,
WorkScheduleId varchar(10) not null,
WorkingAreaId varchar(10) not null,
PositionId varchar(10) not null,
SalaryPolicyId varchar(10) not null,
TypePersonnelId varchar(10) not null,
Title Nvarchar(100),
ActualSalary money not null,
BasicSalary money not null,
StartDate datetime not null,
OfficialDate datetime,
DateOfBirth datetime not null,
Phone varchar(15),
Sex bit not null,
PersonnelAddress Nvarchar(100) not null,
Del bit default(1)
);

-- Module 2: TimeOff. this section will contain information sheets about leave application form, leave application, leave policy etc

CREATE TABLE TypeTimeOff( /*1*/
TypeTimeOffId varchar(10) not null,
TypeTimeOffName Nvarchar(50) not null,
Del bit default(1)
);

CREATE TABLE ApprovalProcess( /*1*/
ApprovalProcessId  varchar(10) not null,
ApprovalProcessName Nvarchar(50) not null,
Del bit default(1)
);

CREATE TABLE FormTimeOff( /*2*/
FormTimeOffId varchar(10) not null,
FormTimeOffName Nvarchar(50) not null,
TypeTimeOffId varchar(10) not null,
RequireApproval bit default(1) not null,
ApprovalProcessId  varchar(10) not null,
RequireLimitedDaysOff bit default(1) not null,
ProcessingTime tinyint default(24),
NumberOfDaysBeforeTimeOff tinyint default(2),
LimitedDaysOff tinyint default(5),
Regulations Nvarchar(100),
Del bit default(1)
);

CREATE TABLE WorkingAreaApplyFormTimeOff( /*3*/
WorkingAreaId varchar(10) not null,
FormTimeOffId varchar(10) not null,
Del bit default(1)
);

CREATE TABLE TimeOffApprover( /*3*/
PersonnelId varchar(10) not null,
FormTimeOffId varchar(10) not null,
Del bit default(1)
);

CREATE TABLE TimeOffFollower( /*3*/
PersonnelId varchar(10) not null,
FormTimeOffId varchar(10) not null,
Del bit default(1)
);

CREATE TABLE TimeOffRequest( /*1*/
PersonnelId varchar(10) not null,
TimeOffRequestId varchar(10) not null,
Title Nvarchar(50) not null,
FormTimeOffId varchar(10) not null,
Reason Nvarchar(200) not null,
RequireHandOver bit not null, 
HandOverWorks Nvarchar(200),
ManagerId varchar(10) not null,
Attachment Nvarchar(100),
TimeOffDate datetime not null,
States Nvarchar(50) not null,
Feedback Nvarchar(100),
Del bit default(1)
);

CREATE TABLE DayOff( /*2*/
DayOffId varchar(10) not null,
TimeOffRequestId varchar(10) not null,
DayOff datetime not null,
Del bit default(1)
);

CREATE TABLE TimeOffShift( /*3*/
DayOffId varchar(10) not null,
TimeOffRequestId varchar(10) not null,
ShiftId varchar(10) not null,
Del bit default(1)
);

CREATE TABLE TypePolicy( /*1*/
TypePolicyId varchar(10) not null,
TypePolicyName Nvarchar(50) not null,
Del bit default(1)
);

CREATE TABLE SeniorityPolicy( /*1*/
SeniorityPolicyId varchar(10) not null,
SeniorityMonth int not null,
PolicyDay tinyint not null,
Del bit default(1)
);

CREATE TABLE TimeOffPolicy( /*2*/
TimeOffPolicyId varchar(10) not null,
TimeOffPolicyName Nvarchar(100) not null,
TypePolicyId varchar(10) not null,
NumberOfDaysOffStandard tinyint not null,
NumberOfDaysOffLastYear tinyint not null,
Describe Nvarchar(100),
Del bit default(1)
);

CREATE TABLE ApplySeniorityPolicy( /*3*/
TimeOffPolicyId varchar(10) not null,
SeniorityPolicyId varchar(10) not null,
);

CREATE TABLE PersonnelApplyTimeOffPolicy( /*1*/
PersonnelId varchar(10) not null,
TimeOffPolicyId varchar(10) not null,
EffectiveDate datetime not null,
NumberOfDaysOffLastYear tinyint not null,
NumberOfDaysOffStandard tinyint not null,
NumberOfDaysOffSeniority tinyint not null,
NumberOfDaysOffOffset tinyint not null,
Note Nvarchar(100),
Del bit default(1)
);

-- Create all Key

-- Keys for Module 1: 
--   primary key
alter table Office
add constraint PK_Office primary key(OfficeId)

alter table TypeWorkSchedule
add constraint PK_TypeWorkSchedule primary key(TypeWorkScheduleId)

alter table CheckinPolicy
add constraint PK_CheckinPolicy primary key(CheckinPolicyId)

alter table NumberOfShift
add constraint PK_NumberOfShift primary key(NumberOfShiftId)

alter table DaysOfWeek
add constraint PK_DaysOfWeek primary key(DaysOfWeekId)

alter table TypeShift
add constraint PK_TypeShift primary key(TypeShiftId)

alter table WorkingArea
add constraint PK_WorkingArea primary key(WorkingAreaId)

alter table TypePosition
add constraint PK_TypePosition primary key(TypePositionId)

alter table SalaryPolicy
add constraint PK_SalaryPolicy primary key(SalaryPolicyId)

alter table TypePersonnel
add constraint PK_TypePersonnel primary key(TypePersonnelId)

alter table WorkSchedule
add constraint PK_WorkSchedule primary key(WorkScheduleId)

alter table Shift
add constraint PK_Shift primary key(ShiftId)

alter table Position
add constraint PK_Position primary key(PositionId)

alter table Personnel
add constraint PK_Personnel primary key(PersonnelId)

/* Foreign Keys*/

ALTER TABLE WorkSchedule
add constraint PR_WorkSchedule_TypeWorkSchedule foreign key(TypeWorkScheduleId) references TypeWorkSchedule(TypeWorkScheduleId),
constraint PR_WorkSchedule_CheckinPolicy foreign key(CheckinPolicyId) references CheckinPolicy(CheckinPolicyId),
constraint PR_WorkSchedule_NumberOfShift foreign key(NumberOfShiftId) references NumberOfShift(NumberOfShiftId)



ALTER TABLE Shift
add constraint PR_Shift_WorkSchedule foreign key(WorkScheduleId) references WorkSchedule(WorkScheduleId),
constraint PR_Shift_DaysOfWeek foreign key(DaysOfWeekId) references DaysOfWeek(DaysOfWeekId),
constraint PR_Shift_TypeShift foreign key(TypeShiftId) references TypeShift(TypeShiftId)

ALTER TABLE Position
add constraint PR_Position_WorkingArea foreign key(WorkingAreaId) references WorkingArea(WorkingAreaId),
constraint PR_Position_TypePosition foreign key(TypePositionId) references TypePosition(TypePositionId)


ALTER TABLE Personnel
add constraint PR_Personnel_Office foreign key(OfficeId) references Office(OfficeId),
constraint PR_Personnel_WorkSchedule foreign key(WorkScheduleId) references WorkSchedule(WorkScheduleId),
constraint PR_Personnel_WorkingArea foreign key(WorkingAreaId) references WorkingArea(WorkingAreaId),
constraint PR_Personnel_Position foreign key(PositionId) references Position(PositionId),
constraint PR_Personnel_SalaryPolicy foreign key(SalaryPolicyId) references SalaryPolicy(SalaryPolicyId),
constraint PR_Personnel_TypePersonnel foreign key(TypePersonnelId) references TypePersonnel(TypePersonnelId)

/*Module 2: Timeoff*/

/*Primary Key*/
alter table TypeTimeOff
add constraint PK_TypeTimeOff primary key(TypeTimeOffId)

alter table ApprovalProcess
add constraint PK_ApprovalProcess primary key(ApprovalProcessId)

alter table FormTimeOff
add constraint PK_FormTimeOff primary key(FormTimeOffId)

alter table WorkingAreaApplyFormTimeOff
add constraint PK_WorkingAreaApplyFormTimeOff primary key(WorkingAreaId,FormTimeOffId)


alter table TimeOffApprover
add constraint PK_TimeOffApprover primary key(PersonnelId, FormTimeOffId)

alter table TimeOffFollower
add constraint PK_TimeOffFollower primary key(PersonnelId,FormTimeOffId)

alter table TimeOffRequest
add constraint PK_TimeOffRequest primary key(TimeOffRequestId)

alter table DayOff
add constraint PK_DayOff primary key(DayOffId)

alter table TimeOffShift
add constraint PK_TimeOffShift primary key(DayOffId,TimeOffRequestId,ShiftId)


alter table TypePolicy
add constraint PK_TypePolicy primary key(TypePolicyId)

alter table SeniorityPolicy
add constraint PK_SeniorityPolicy primary key(SeniorityPolicyId)

alter table TimeOffPolicy
add constraint PK_TimeOffPolicy primary key(TimeOffPolicyId)

alter table ApplySeniorityPolicy
add constraint PK_ApplySeniorityPolicy primary key(TimeOffPolicyId,SeniorityPolicyId)

alter table PersonnelApplyTimeOffPolicy
add constraint PK_PersonnelApplyTimeOffPolicy primary key(PersonnelId,TimeOffPolicyId)

/*Foreign Keys*/

ALTER TABLE FormTimeOff
add constraint PR_FormTimeOff_TypeTimeOff foreign key(TypeTimeOffId) references TypeTimeOff(TypeTimeOffId),
constraint PR_FormTimeOff_ApprovalProcess foreign key(ApprovalProcessId) references ApprovalProcess(ApprovalProcessId)

ALTER TABLE WorkingAreaApplyFormTimeOff
add constraint PR_WorkingAreaApplyFormTimeOff_WorkingArea foreign key(WorkingAreaId) references WorkingArea(WorkingAreaId),
constraint PR_WorkingAreaApplyFormTimeOff_FormTimeOff foreign key(FormTimeOffId) references FormTimeOff(FormTimeOffId)

ALTER TABLE TimeOffApprover
add constraint PR_TimeOffApprover_Personnel foreign key(PersonnelId) references Personnel(PersonnelId),
constraint PR_TimeOffApprover_FormTimeOff foreign key(FormTimeOffId) references FormTimeOff(FormTimeOffId)

ALTER TABLE TimeOffFollower
add constraint PR_TimeOffFollower_Personnel foreign key(PersonnelId) references Personnel(PersonnelId),
constraint PR_TimeOffFollower_FormTimeOff foreign key(FormTimeOffId) references FormTimeOff(FormTimeOffId)

ALTER TABLE TimeOffRequest
add constraint PR_TimeOffRequest_Personnel foreign key(PersonnelId) references Personnel(PersonnelId),
constraint PR_TimeOffRequest_FormTimeOff foreign key(FormTimeOffId) references FormTimeOff(FormTimeOffId),
constraint PR_TimeOffRequest_Manager foreign key(ManagerId) references Personnel(PersonnelId)

ALTER TABLE DayOff
add constraint PR_DayOff_TimeOffRequest foreign key(TimeOffRequestId) references TimeOffRequest(TimeOffRequestId)


ALTER TABLE TimeOffShift
add constraint PR_TimeOffShift_TimeOffRequest foreign key(TimeOffRequestId) references TimeOffRequest(TimeOffRequestId),
constraint PR_TimeOffShift_Shift foreign key(ShiftId) references Shift(ShiftId),
constraint PR_TimeOffShift_DayOff foreign key(DayOffId) references DayOff(DayOffId)


ALTER TABLE TimeOffPolicy
add constraint PR_TimeOffPolicy_TypePolicy foreign key(TypePolicyId) references TypePolicy(TypePolicyId)

ALTER TABLE ApplySeniorityPolicy
add constraint PR_ApplySeniorityPolicy_TimeOffPolicy foreign key(TimeOffPolicyId) references TimeOffPolicy(TimeOffPolicyId),
constraint PR_ApplySeniorityPolicy_SeniorityPolicy foreign key(SeniorityPolicyId) references SeniorityPolicy(SeniorityPolicyId)

ALTER TABLE PersonnelApplyTimeOffPolicy
add constraint PR_PersonnelApplyTimeOffPolicy_Personnel foreign key(PersonnelId) references Personnel(PersonnelId),
constraint PR_PersonnelApplyTimeOffPolicy_TimeOffPolicy foreign key(TimeOffPolicyId) references TimeOffPolicy(TimeOffPolicyId)

-- INSERT INTO

-- Office
INSERT INTO Office
(OfficeId, OfficeName, OfficeAddress, OfficePhone, OfficeEmail, Del)
VALUES
('OF001', 'Office A', 'Tran Phu Street', '0123456789', 'a@gmail.com', 1),
('OF002', 'Office B', 'Nguyen Thi Minh Khai Street', '0456789123', 'b@gmail.com', 1),
('OF003', 'Office C', 'Hung Vuong Street', '0789123456', 'c@gmail.com', 1)
GO

-- Type Work Schedule
INSERT INTO TypeWorkSchedule
(TypeWorkScheduleId, TypeWorkScheduleName, Del)
VALUES
('TWS001', 'Type 001', 1),
('TWS002', 'Type 002', 1),
('TWS003', 'Type 003', 1)
GO

-- Checkin Policy
INSERT INTO CheckinPolicy
(CheckinPolicyId, CheckinPolicyName, Del)
VALUES
('CP001', 'Checkin Policy 1', 1),
('CP002', 'Checkin Policy 2', 1),
('CP003', 'Checkin Policy 3', 1)
GO

-- Number Of Shift
INSERT INTO NumberOfShift
(NumberOfShiftId, NumberOfShift, Del)
VALUES
('NOS001', 1, 1),
('NOS002', 2, 1),
('NOS003', 3, 1)
GO

-- Work Schedule
INSERT INTO WorkSchedule
(WorkScheduleId, WorkScheduleName, TypeWorkScheduleId, CheckinPolicyId, NumberOfShiftId, RequireCheckout, WorkingHoursPerDay, MinutesLate, MinutesEarly, Regulations, States, Del)
VALUES
('WS001', 'Work Schedule 1', 'TWS001', 'CP001', 'NOS001', 1, 4, 0, 0, '...', 1, 1),
('WS002', 'Work Schedule 2', 'TWS002', 'CP002', 'NOS002', 2, 8, 0, 0, '...', 1, 1),
('WS003', 'Work Schedule 3', 'TWS003', 'CP003', 'NOS003', 3, 12, 0, 0, '...', 1, 1)
GO

-- Working Area
INSERT INTO WorkingArea
(WorkingAreaId, WorkingAreaName, Describe, States, Del)
VALUES
('WA001', 'Office', '...', 1, 1),
('WA002', 'Design', '...', 1, 1),
('WA003', 'IT', '...', 1, 1)
GO

-- Type Position
INSERT INTO TypePosition
(TypePositionId, TypePositionName, Describe, Del)
VALUES
('TP001', 'Type Position 1', '...', 1),
('TP002', 'Type Position 2', '...', 1),
('TP003', 'Type Position 3', '...', 1)
GO

-- Position
INSERT INTO Position
(PositionId, PositionName, WorkingAreaId, TypePositionId, LowestSalary, HighestSalary, Del)
VALUES
('P001', 'Position 1', 'WA001', 'TP001', 500000, 2500000, 1),
('P002', 'Position 2', 'WA002', 'TP002', 2000000, 10000000, 1),
('P003', 'Position 3', 'WA003', 'TP003', 5000000, 25000000, 1)
GO

-- Salary Policy
INSERT INTO SalaryPolicy
(SalaryPolicyId, SalaryPolicyName, Describe, States, Del)
VALUES
('SP001', 'Salary Policy 1', '...', 1, 1),
('SP002', 'Salary Policy 2', '...', 1, 1),
('SP003', 'Salary Policy 3', '...', 1, 1)
GO

-- Type Personnel
INSERT INTO TypePersonnel
(TypePersonnelId, TypePersonnelName, Describe, States, Del)
VALUES
('TP001', 'Type Personnel 1', '...', 1, 1),
('TP002', 'Type Personnel 2', '...', 1, 1),
('TP003', 'Type Personnel 3', '...', 1, 1)

