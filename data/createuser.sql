USE [master]
GO
CREATE LOGIN [castellogovender] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.castello.govender], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.castello.govender]

GO
use [master]

GO
USE [sql101.castello.govender]
GO
CREATE USER [castellogovender] FOR LOGIN [castellogovender]
GO
USE [sql101.castello.govender]
GO
ALTER ROLE [db_owner] ADD MEMBER [castellogovender]
GO
