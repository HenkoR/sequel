USE [master]
GO
CREATE LOGIN [mbongisenincube] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.mbongiseni.ncube], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.mbongiseni.ncube]

GO
use [master]

GO
USE [sql101.mbongiseni.ncube]
GO
CREATE USER [mbongisenincube] FOR LOGIN [mbongisenincube]
GO
USE [sql101.mbongiseni.ncube]
GO
ALTER ROLE [db_owner] ADD MEMBER [mbongisenincube]
GO
