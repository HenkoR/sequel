USE [master]
GO
CREATE LOGIN [LindaniMabaso] WITH PASSWORD=N'Lindany#016' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Lindani.Mabaso], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Lindani.Mabaso]

GO
use [master]

GO
USE [sql101.Lindani.Mabaso]
GO
CREATE USER [LindaniMabaso] FOR LOGIN [LindaniMabaso]
GO
USE [sql101.Lindani.Mabaso]
GO
ALTER ROLE [db_owner] ADD MEMBER [LindaniMabaso]
GO
