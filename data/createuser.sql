USE [master]
GO
CREATE LOGIN [xolanidlamini] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.xolani.dlamini], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.xolani.dlamini]

GO
use [master]

GO
USE [sql101.xolani.dlamini]
GO
CREATE USER [xolanidlamini] FOR LOGIN [xolanidlamini]
GO
USE [sql101.xolani.dlamini]
GO
ALTER ROLE [db_owner] ADD MEMBER [xolanidlamini]
GO
