use TimeKeepingDB
drop table TimeOffShift
ALTER TABLE DayOff
ADD FromHour varchar(5) not null,
ToHour varchar(5) not null;

EXEC sp_rename 'dbo.DayOff.DayOff', 'DayOffAt', 'COLUMN';
EXEC sp_rename 'dbo.TimeOffRequestState.TimeOffRequestState', 'TimeOffRequestStateName', 'COLUMN';
EXEC sp_rename 'dbo.NumberOfShift.NumberOfShift', 'Count', 'COLUMN';