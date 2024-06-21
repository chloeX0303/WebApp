SET IDENTITY_INSERT [dbo].[Staff] ON
INSERT INTO [dbo].[Staff] ([StaffID], [DepartmentID], [Email], [FirstName], [LastName], [PhoneNumber], [MidName]) VALUES (8, NULL, N'Aven22@gmail.com', N'Aven', N'Stone', N'0212519718', NULL)
INSERT INTO [dbo].[Staff] ([StaffID], [DepartmentID], [Email], [FirstName], [LastName], [PhoneNumber], [MidName]) VALUES (9, NULL, N'Janet300@gmail.com', N'Janet', N'Spare', N'0212519222', NULL)
INSERT INTO dbo.Staff (
	StaffID,
	DepartmentID,
	Email,
	FirstName,
	LastName,
	PhoneNumber,
	MidName)
VALUES (
	10,
	NULL,
	'JanetCare1@gmail.com',
	'Janet',
	'Care',
	'0213519223',
	'Main')
SET IDENTITY_INSERT [dbo].[Staff] OFF
