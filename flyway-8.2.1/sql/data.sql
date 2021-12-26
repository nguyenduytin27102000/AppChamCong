-- Insert data
-- Level 1:----------------------------------------
INSERT INTO Office VALUES
('OF001', 'Office A', 'Tran Phu Street', '0123456789', 'a@gmail.com', 1),
('OF002', 'Office B', 'Nguyen Thi Minh Khai Street', '0456789123', 'b@gmail.com', 1),
('OF003', 'Office C', 'Hung Vuong Street', '0789123456', 'c@gmail.com', 1)
 
INSERT INTO TypeWorkSchedule VALUES
('TWS001', 'Type 001', 1),
('TWS002', 'Type 002', 1),
('TWS003', 'Type 003', 1)

INSERT INTO CheckinPolicy VALUES
('CP001', 'Checkin Policy 1', 1),
('CP002', 'Checkin Policy 2', 1),
('CP003', 'Checkin Policy 3', 1)

INSERT INTO NumberOfShift VALUES
('NOS001', 1, 1),
('NOS002', 2, 1),
('NOS003', 3, 1)

INSERT INTO WorkingArea VALUES
('WA001', 'Office', N'Office in Ha Noi', 1, 1),
('WA002', 'Design', N'Sai Gon Designer', 1, 1),
('WA003', 'IT', N'IT Nha Trang', 1, 1)

INSERT INTO TypePosition VALUES
('TP001', 'Fixed', 'Ha Noi', 1),
('TP002', 'Long Term', 'Ha Noi', 1),
('TP003', 'Flex', 'Ha Noi', 1)

INSERT INTO Position VALUES
('P001', 'CTO', 'WA001', 'TP001', 500000, 2500000, 1),
('P002', 'CEO', 'WA002', 'TP002', 2000000, 10000000, 1),
('P003', 'QA', 'WA003', 'TP003', 5000000, 25000000, 1)

INSERT INTO SalaryPolicy VALUES
('SP001', 'Salary Partime', 'Sai Gon', 1, 1),
('SP002', 'Salary Fulltime', 'Ha noi', 1, 1),
('SP003', 'Salary Senior', 'Nha Trang', 1, 1)

INSERT INTO TypePersonnel VALUES
('TP001', 'Fulltime', '', 1, 1),
('TP002', 'Partime', '', 1, 1),
('TP003', 'Flex', '', 1, 1)

-- WARNING. PLS DON'T CHANGE DATA IN THIS TABLE .. TÍN NGUYỄN
INSERT INTO TimeOffRequestState VALUES 
('001','Pending Approval',1),
('002','Cancelled',1),
('003','Approved',1)
-- Read WARNING ABOVE

INSERT INTO TypePolicy VALUES
('TP001',N'Fixed',1),
('TP002',N'Flex',1),
('TP003',N'Temp',1)

-- Level 2:-------------------------------------------------

INSERT INTO WorkSchedule VALUES
('WS001', 'Work Schedule for Sai Gon', 'TWS001', 'CP001', 'NOS001', 1, 4, 15, 15,'2021-01-01 12:00:00','2025-01-01 12:00:00',N'$2 fine for being late',1,1),
('WS002', 'Work Schedule for Ha Noi', 'TWS002', 'CP002', 'NOS002', 1, 8, 15, 15,'2021-01-01 12:00:00','2025-01-01 12:00:00',N'$2 fine for being late',1,1),
('WS003', 'Work Schedule  for Nha Trang', 'TWS003', 'CP003', 'NOS003', 1, 12, 15, 15,'2021-01-01 12:00:00','2025-01-01 12:00:00',N'$2 fine for being late',1,1)

INSERT INTO Personnel VALUES
('PS001',N'Lê Bích',N'Liễu','lieu@email.com','OF001','WS001','WA001','P001','SP001','TP001','Manager',20000000,10000000,'2010-01-01 12:00:00','2010-02-01 12:00:00','1988-01-01 12:00:00','0876524352',0,N'12 Cao Bằng',1),
('PS002',N'Võ Thu',N'Ngân','ngan@email.com','OF002','WS002','WA002','P002','SP002','TP002','Manager',20000000,15000000,'2010-02-01 12:00:00','2010-03-01 12:00:00','1990-01-01 12:00:00','0876231352',0,N'99 Hải Phòng',1),
('PS003',N'Hoàng Mai',N'Thủy','thuy@email.com','OF001','WS001','WA001','P001','SP001','TP001','Manager',15000000,10000000,'2011-01-01 12:00:00','2011-02-01 12:00:00','1992-01-01 12:00:00','082841352',0,N'12 Sài Gòn',1)

-- Level 3: --------------------------------------------------------------------
INSERT INTO Checkin VALUES
('CK001','PS001','2021-12-23 8:15:00 AM',1),
('CK002','PS001','2021-12-23 13:16:00 PM',1),
('CK003','PS001','2021-12-25 8:00:00 AM',1),
('CK004','PS002','2021-12-22 8:20:00 AM',1),
('CK005','PS002','2021-12-22 13:20:00 PM',1),
('CK006','PS003','2021-12-11 8:15:00 AM',1),
('CK007','PS003','2021-12-11 13:12:00 PM',1)

INSERT INTO TimeOffPolicy VALUES 
('OP001','Time Off Policy 1','TP001',4,4,'Sai Gon',1),
('OP002','Time Off Policy 2 ','TP002',4,4,'Sai Gon',1),
('OP003','Time Off Policy 3','TP002',4,4,'Sai Gon',1)

-- End:---------------------------------