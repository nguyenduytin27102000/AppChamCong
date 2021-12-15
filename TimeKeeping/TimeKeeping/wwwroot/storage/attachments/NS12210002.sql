USE [TimeKeepingDB]
GO
INSERT [dbo].[Office] ([OfficeId], [OfficeName], [OfficeAddress], [OfficePhone], [OfficeEmail], [Del]) VALUES (N'1', N'CH Play', N'21 Le Loi', N'113', N'conganxa@gmal.com', 0)
GO
INSERT [dbo].[WorkingArea] ([WorkingAreaId], [WorkingAreaName], [Describe], [States], [Del]) VALUES (N'1', N'Seller', N'Sell chieu', 1, 0)
GO
INSERT [dbo].[SalaryPolicy] ([SalaryPolicyId], [SalaryPolicyName], [Describe], [States], [Del]) VALUES (N'1', N'Luong CB', N'Lương cơ bản', 1, 0)
GO
INSERT [dbo].[TypePersonnel] ([TypePersonnelId], [TypePersonnelName], [Describe], [States], [Del]) VALUES (N'1', N'Chính Thức', N'Nhân viên chính thức', 1, 0)
GO
INSERT [dbo].[TypeWorkSchedule] ([TypeWorkScheduleId], [TypeWorkScheduleName], [Del]) VALUES (N'1', N'Lịch chính quy', 0)
GO
INSERT [dbo].[CheckinPolicy] ([CheckinPolicyId], [CheckinPolicyName], [Del]) VALUES (N'1', N'abcxyz', 0)
GO
INSERT [dbo].[NumberOfShift] ([NumberOfShiftId], [Count], [Del]) VALUES (N'1', 2, 0)
GO
INSERT [dbo].[WorkSchedule] ([WorkScheduleId], [WorkScheduleName], [TypeWorkScheduleId], [CheckinPolicyId], [NumberOfShiftId], [RequireCheckout], [WorkingHoursPerDay], [MinutesLate], [MinutesEarly], [Regulations], [States], [Del]) VALUES (N'1', N'Lịch làm cho nhân viên chính', N'1', N'1', N'1', 1, 8, 10, 10, N'không', 1, 0)
GO
INSERT [dbo].[TypePosition] ([TypePositionId], [TypePositionName], [Describe], [Del]) VALUES (N'1', N'Nhân viên', N'abc', 0)
GO
INSERT [dbo].[Position] ([PositionId], [PositionName], [WorkingAreaId], [TypePositionId], [LowestSalary], [HighestSalary], [Del]) VALUES (N'1', N'Nhân viên quèn', N'1', N'1', 2000.0000, 2000.0000, 0)
GO
INSERT [dbo].[Personnel] ([PersonnelId], [FirstName], [LastName], [Email], [OfficeId], [WorkScheduleId], [WorkingAreaId], [PositionId], [SalaryPolicyId], [TypePersonnelId], [Title], [ActualSalary], [BasicSalary], [StartDate], [OfficialDate], [DateOfBirth], [Phone], [Sex], [PersonnelAddress], [Del]) VALUES (N'1', N'Nguyễn', N'Sơn Tùng', N'sontung@gmail.com', N'1', N'1', N'1', N'1', N'1', N'1', N'Nhân viên cùi', 2000.0000, 3000.0000, CAST(N'2000-02-11T00:00:00.000' AS DateTime), CAST(N'2000-05-15T00:00:00.000' AS DateTime), CAST(N'1899-02-11T00:00:00.000' AS DateTime), N'22', 1, N'cát lợi', 0)
INSERT [dbo].[Personnel] ([PersonnelId], [FirstName], [LastName], [Email], [OfficeId], [WorkScheduleId], [WorkingAreaId], [PositionId], [SalaryPolicyId], [TypePersonnelId], [Title], [ActualSalary], [BasicSalary], [StartDate], [OfficialDate], [DateOfBirth], [Phone], [Sex], [PersonnelAddress], [Del]) VALUES (N'2', N'Lê', N'Câm', N'lecam@yahoo.com', N'1', N'1', N'1', N'1', N'1', N'1', N'Nhân viên bào', 2000.0000, 5000.0000, CAST(N'2003-03-20T00:00:00.000' AS DateTime), CAST(N'2003-03-25T00:00:00.000' AS DateTime), CAST(N'1877-03-14T00:00:00.000' AS DateTime), N'2222', 1, N'Hà nội', 0)
GO
INSERT [dbo].[DaysOfWeek] ([DaysOfWeekId], [DaysOfWeekName], [Del]) VALUES (N'1', N'Thứ 4', 0)
GO
INSERT [dbo].[TypeShift] ([TypeShiftId], [TypeShiftName], [Del]) VALUES (N'1', N'Ca cơ bản', 0)
GO
INSERT [dbo].[Shift] ([WorkScheduleId], [DaysOfWeekId], [ShiftId], [TypeShiftId], [ShiftName], [StartTime], [EndTime], [DayOff], [Del]) VALUES (N'1', N'1', N'1', N'1', N'Sáng', CAST(N'2021-12-12T07:00:00.000' AS DateTime), CAST(N'2021-12-12T10:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[Shift] ([WorkScheduleId], [DaysOfWeekId], [ShiftId], [TypeShiftId], [ShiftName], [StartTime], [EndTime], [DayOff], [Del]) VALUES (N'1', N'1', N'2', N'1', N'Chiều', CAST(N'2021-12-12T13:00:00.000' AS DateTime), CAST(N'2021-12-12T17:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[Shift] ([WorkScheduleId], [DaysOfWeekId], [ShiftId], [TypeShiftId], [ShiftName], [StartTime], [EndTime], [DayOff], [Del]) VALUES (N'1', N'1', N'3', N'1', N'Tối', CAST(N'2021-12-12T18:00:00.000' AS DateTime), CAST(N'2021-12-12T23:00:00.000' AS DateTime), 0, 0)
GO
INSERT [dbo].[TypeTimeOff] ([TypeTimeOffId], [TypeTimeOffName], [Del]) VALUES (N'1', N'Nghỉ do bầu bì', 0)
GO
INSERT [dbo].[ApprovalProcess] ([ApprovalProcessId], [ApprovalProcessName], [Del]) VALUES (N'1', N'Cơ bản', 0)
GO
INSERT [dbo].[FormTimeOff] ([FormTimeOffId], [FormTimeOffName], [TypeTimeOffId], [RequireApproval], [ApprovalProcessId], [RequireLimitedDaysOff], [ProcessingTime], [NumberOfDaysBeforeTimeOff], [LimitedDaysOff], [Regulations], [Del]) VALUES (N'1', N'Mẫu nghỉ số 1', N'1', 1, N'1', 1, 10, 3, 3, N'thích thf nghỉ', 0)
GO
INSERT [dbo].[TimeOffRequestState] ([TimeOffRequestStateId], [TimeOffRequestStateName], [Del]) VALUES (N'1', N'Pending', 0)
INSERT [dbo].[TimeOffRequestState] ([TimeOffRequestStateId], [TimeOffRequestStateName], [Del]) VALUES (N'2', N'Accepted', 0)
INSERT [dbo].[TimeOffRequestState] ([TimeOffRequestStateId], [TimeOffRequestStateName], [Del]) VALUES (N'3', N'Denied', 0)
GO
INSERT [dbo].[TimeOffRequest] ([PersonnelId], [TimeOffRequestId], [Title], [FormTimeOffId], [Reason], [RequireHandOver], [HandOverWorks], [ManagerId], [Attachment], [TimeOffDate], [TimeOffRequestStateId], [Feedback], [Del]) VALUES (N'1', N'NS12210001', N'f', N'1', N'f', 1, N'f', N'1', NULL, CAST(N'2021-12-14T23:34:05.027' AS DateTime), N'1', N'', 0)
GO
INSERT [dbo].[DayOff] ([DayOffId], [TimeOffRequestId], [DayOffAt], [Del], [FromHour], [ToHour]) VALUES (N'NP12210001', N'NS12210001', CAST(N'2021-12-02T00:00:00.000' AS DateTime), 0, N'8:00', N'17:00')
GO
