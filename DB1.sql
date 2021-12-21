CREATE DATABASE DB1
USE DB1 
go
CREATE TABLE  abc( /*2*/
PersonnelId int not null,
FirstName Nvarchar(100) not null,
Email varchar(100) not null,
Pass varchar(100) not null,
);
alter table abc
add constraint PK_Personnel primary key(PersonnelId)
