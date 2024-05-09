SET IDENTITY_INSERT dbo.Student on

INSERT INTO dbo.Student (
	StudentID,
	FirstName,
	LastName,
	Email)
VALUES (
	1,
	'Kirby',
	'Are',
	'Kirby33@gmail.com')


SET IDENTITY_INSERT dbo.Student off