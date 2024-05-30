SET IDENTITY_INSERT dbo.Department on

INSERT INTO dbo.Department (
	DepartmentID,
	DepartmentName,
	SubjectID
	)
VALUES (
	1,
	'Art',
	1
	)

SET IDENTITY_INSERT dbo.Department off
