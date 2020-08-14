IF DB_ID('Clinic') IS NULL
    create database Clinic;
GO	
use Clinic
--Deleting tables and views, if they exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblClinicPatient')
	drop table tblClinicPatient;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblClinicDoctor')
	drop table tblClinicDoctor;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblClinicManager')
	drop table tblClinicManager;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblClinicMaintenance')
	drop table tblClinicMaintenance;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblClinicAdministrator')
	drop table tblClinicAdministrator;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUser')
	drop table tblUser;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblClinic')
	drop table tblClinic;
IF EXISTS(select * FROM sys.views where name = 'vwClinicPatient')
	drop view vwClinicPatient;
IF EXISTS(select * FROM sys.views where name = 'vwClinicDoctor')
	drop view vwClinicDoctor;
IF EXISTS(select * FROM sys.views where name = 'vwClinicManager')
	drop view vwClinicManager;
IF EXISTS(select * FROM sys.views where name = 'vwClinicMaintenance')
	drop view vwClinicMaintenance;
IF EXISTS(select * FROM sys.views where name = 'vwClinicAdministrator')
	drop view vwClinicAdministrator;
IF EXISTS(select * FROM sys.views where name = 'vwUser')
	drop view vwUser;
IF EXISTS(select * FROM sys.views where name = 'vwClinic')
	drop view vwClinic;
GO
--Creating tables
create table tblClinic(
ClinicId int identity(1,1) PRIMARY KEY,
Name varchar(60) NOT NULL,
DateOfConstruction date NOT NULL,
Owner varchar(60) NOT NULL,
Address varchar(255) NOT NULL,
NumberOfFloors int NOT NULL, 
NumberOfRoomsPerFloor int NOT NULL, 
Terrace bit NOT NULL,
Yard bit NOT NULL,
NumberOfAccessPointsForAmbulanceCars int NOT NULL,
NumberOfAccessPointsForInvalids int NOT NULL
);
create table tblUser(
UserId int identity(1,1) PRIMARY KEY,
NameAndSurname varchar(100) NOT NULL,
IdentityCardNumber varchar(9) UNIQUE NOT NULL,
Gender char NOT NULL,
DateOfBirth date NOT NULL,
Citizenship varchar(100) NOT NULL,
Username varchar(40) UNIQUE NOT NULL,
Password varchar(40) NOT NULL
);
create table tblClinicAdministrator(
AdministratorId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL
);
create table tblClinicMaintenance(
MaintenanceId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
PermissionToExpandClinic bit NOT NULL,
ResponsibleForAccessibilityOfInvalids bit NOT NULL
);
create table tblClinicManager(
ManagerId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
Floor int NOT NULL,
MaximumNumberOfSupervisedDoctors int NOT NULL,
MinimumNumberOfSupervisedRooms int NOT NULL,
NumberOfOmissions int NOT NULL
);
create table tblClinicDoctor(
DoctorId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
UniqueNumber varchar(5) UNIQUE NOT NULL,
BankAccountNumber varchar(18) UNIQUE NOT NULL,
Department varchar(30) NOT NULL,
Shift varchar(30) NOT NULL,
ResponsibleForPatientAdmission bit NOT NULL,
SuperiorManager int FOREIGN KEY REFERENCES tblClinicManager(ManagerId)
);
create table tblClinicPatient(
PatientId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
HealthInsuranceCardNumber varchar(11) UNIQUE NOT NULL,
ExpirationDateOfHealthInsurance date NOT NULL,
UniqueNumberOfSelectedDoctor varchar(5) REFERENCES tblClinicDoctor(UniqueNumber) NOT NULL
);
GO
create view vwClinic as
select *
from tblClinic;
GO
create view vwUser as
select *
from tblUser;
GO
create view vwClinicAdministrator as
select u.*, a.AdministratorId
from tblClinicAdministrator a
INNER JOIN tblUser u
ON a.UserId = u.UserId;
GO 
create view vwClinicMaintenance as
select u.*, m.MaintenanceId, m.PermissionToExpandClinic, m.ResponsibleForAccessibilityOfInvalids
from tblClinicMaintenance m
INNER JOIN tblUser u
ON m.UserId = u.UserId;
GO 
create view vwClinicManager as
select u.*, m.Floor, m.ManagerId, m.MaximumNumberOfSupervisedDoctors, m.MinimumNumberOfSupervisedRooms,
m.NumberOfOmissions
from tblClinicManager m
INNER JOIN tblUser u
ON m.UserId = u.UserId;
GO
create view vwClinicDoctor as
select u.*, d.BankAccountNumber, d.Department, d.DoctorId, d.ResponsibleForPatientAdmission, d.Shift, d.SuperiorManager,
d.UniqueNumber
from tblClinicDoctor d
INNER JOIN tblUser u
ON d.UserId = u.UserId;
GO
create view vwClinicPatient as
select u.*, p.ExpirationDateOfHealthInsurance, p.HealthInsuranceCardNumber, p.PatientId, p.UniqueNumberOfSelectedDoctor
from tblClinicPatient p
INNER JOIN tblUser u
ON p.UserId = u.UserId;





