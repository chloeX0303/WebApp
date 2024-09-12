SET IDENTITY_INSERT [dbo].[Subject] ON
INSERT INTO [dbo].[Subject] ([SubjectID], [SubjectName], [DepartmentID], [ImageName]) VALUES (1, N'Art', NULL, N'')
INSERT INTO [dbo].[Subject] ([SubjectID], [SubjectName], [DepartmentID], [ImageName]) VALUES (2, N'Health PhysicalEducationsss', NULL, N'')
INSERT INTO [dbo].[Subject] ([SubjectID], [SubjectName], [DepartmentID], [ImageName]) VALUES (3, N'Science', NULL, N'hans-reniers-lQGJCMY5qcM-unsplash2432235242.jpg')
INSERT INTO [dbo].[Subject] ([SubjectID], [SubjectName], [DepartmentID], [ImageName]) VALUES (4, N'English', NULL, N'laura-ohlman-qRtcb9wHG40-unsplash2439300765.jpg')
INSERT INTO [dbo].[Subject] ([SubjectID], [SubjectName], [DepartmentID], [ImageName]) VALUES (5, N'Mathematics', NULL, N'clayton-robbins-ihqB-c8C7Bc-unsplash2440031296.jpg')
INSERT INTO dbo.Subject (
	SubjectID,
	SubjectName,
	DepartmentID,
	ImageName)
VALUES (
	6,
	'Social Science',
	2,
	'social-science.jpg')

SET IDENTITY_INSERT [dbo].[Subject] OFF
