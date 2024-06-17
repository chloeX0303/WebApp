CREATE TABLE [dbo].[Staff] (
    [StaffID]      INT            IDENTITY (1, 1) NOT NULL,
    [DepartmentID] INT            NULL,
    [Email]        NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [FirstName]    NVARCHAR (25)  NOT NULL,
    [LastName]     NVARCHAR (25)  NOT NULL,
    [PhoneNumber]  NVARCHAR (14)  NOT NULL,
    [MidName]      NVARCHAR (25)  DEFAULT (N'') NULL,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([StaffID] ASC),
    CONSTRAINT [FK_Staff_Department_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Department] ([DepartmentID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Staff_DepartmentID]
    ON [dbo].[Staff]([DepartmentID] ASC);

