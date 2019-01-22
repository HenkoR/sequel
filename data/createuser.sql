USE [master]
GO
CREATE LOGIN [ilzelourens] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.ilze.lourens], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.ilze.lourens]

GO
use [master]

GO
USE [sql101.ilze.lourens]
GO
CREATE USER [ilzelourens] FOR LOGIN [ilzelourens]
GO
USE [sql101.ilze.lourens]
GO
ALTER ROLE [db_owner] ADD MEMBER [ilzelourens]
GO
