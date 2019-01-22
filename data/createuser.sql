USE [master]
GO
CREATE LOGIN [firstnamelastname] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.firstname.lastname], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.firstname.lastname]

GO
use [master]

GO
USE [sql101.firstname.lastname]
GO
CREATE USER [firstnamelastname] FOR LOGIN [firstnamelastname]
GO
USE [sql101.firstname.lastname]
GO
ALTER ROLE [db_owner] ADD MEMBER [firstnamelastname]
GO
