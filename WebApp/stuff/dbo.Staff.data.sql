SET IDENTITY_INSERT dbo.Staff on

INSERT INTO dbo.Staff (
	StaffID,
	DepartmentID,
	Email,
	FirstName,
	LastName,
	PhoneNumber,
	ProfileID
	)
VALUES (
	1,
	1,
	'SerenaIves11@gmail.com',
	'Serena',
	'Ives',
	0213499876,
	1
	)
SET IDENTITY_INSERT dbo.Staff off