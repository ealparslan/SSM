INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ('1','admin')
INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ('2','shipper')
INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ('3','stocker')

GO

INSERT INTO [dbo].[AspNetUsers] ([Id],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[AccessFailedCount],[UserName])
     VALUES
           ('325f23f2-7047-4df5-9479-bd59c46481e0'
           ,'admin@ssmbare.com'
           ,0
           ,'ALwY9TUHQ3R4pmBM1Ton6jiOzDbaI3CvCmyY+CaDhnYEmKR/dW1VUzq2pE7mRad/bw=='
           ,'2b3b6aaf-74ce-49f7-8347-b083b8931f8e'
           ,0
           ,0
           ,1
           ,0
           ,'admin@ssmbare.com')
GO

INSERT INTO [dbo].[AspNetUsers] ([Id],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[AccessFailedCount],[UserName])
     VALUES
           ('e8e0d57a-0aad-4992-9e8e-78472e1845c2'
           ,'shipper@ssmbare.com'
           ,0
           ,'AGt/6qJjyBKnp1a4CpuOQTwXOBkb3CChvfcAO7K7eYV/Kcukt3HlwNQ2ZodUKQU/Jg=='
           ,'b5cf8c91-246f-4502-9164-df1ca20bd265'
           ,0
           ,0
           ,1
           ,0
           ,'shipper@ssmbare.com')
GO

INSERT INTO [dbo].[AspNetUsers] ([Id],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[AccessFailedCount],[UserName])
     VALUES
           ('d5bb2c14-fec1-4c07-81bf-40523c2a3b79'
           ,'stocker@ssmbare.com'
           ,0
           ,'ACl05wPcLfEdkV6/DxBu4KjCJfMP+exEqhZ0V8dS8agz333getZYT1agYI4HVam8lQ=='
           ,'f428efb6-ae59-409f-8e91-ca0fd2a12a91'
           ,0
           ,0
           ,1
           ,0
           ,'stocker@ssmbare.com')
GO

INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES ('325f23f2-7047-4df5-9479-bd59c46481e0','1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES ('e8e0d57a-0aad-4992-9e8e-78472e1845c2','2') 
INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES ('d5bb2c14-fec1-4c07-81bf-40523c2a3b79','3') 


