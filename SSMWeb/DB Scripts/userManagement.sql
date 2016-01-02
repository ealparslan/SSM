INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ('1','admin')
INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ('2','shipper')
INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ('3','stocker')

GO

INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES ('41383118-0a78-4d54-ba27-000fd747e120','1') -- CHANGE USER ID
INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES ('41383118-0a78-4d54-ba27-000fd747e120','2')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES ('41383118-0a78-4d54-ba27-000fd747e120','3')
GO
