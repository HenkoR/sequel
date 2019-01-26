USE [master]
GO
CREATE LOGIN [simtembilesoginga] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.simtembile.soginga], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.simtembile.soginga]

GO
use [master]

GO
USE [sql101.simtembile.soginga]
GO
CREATE USER [simtembilesoginga] FOR LOGIN [simtembilesoginga]
GO
USE [sql101.simtembile.soginga]
GO
ALTER ROLE [db_owner] ADD MEMBER [simtembilesoginga]
GO
