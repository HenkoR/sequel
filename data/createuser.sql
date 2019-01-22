USE [master]
GO
CREATE LOGIN [kaveshankarunakaram] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.kaveshan.karunakaram], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.kaveshan.karunakaram]

GO
use [master]

GO
USE [sql101.kaveshan.karunakaram]
GO
CREATE USER [kaveshankarunakaram] FOR LOGIN [kaveshankarunakaram]
GO
USE [sql101.kaveshan.karunakaram]
GO
ALTER ROLE [db_owner] ADD MEMBER [kaveshankarunakaram]
GO
