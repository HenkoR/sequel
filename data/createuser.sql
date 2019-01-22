USE [master]
GO
CREATE LOGIN [thanditshabalala] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.thandi.tshabalala], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.thandi.tshabalala]

GO
use [master]

GO
USE [sql101.thandi.tshabalala]
GO
CREATE USER [thanditshabalala] FOR LOGIN [thanditshabalala]
GO
USE [sql101.thandi.tshabalala]
GO
ALTER ROLE [db_owner] ADD MEMBER [thanditshabalala]
GO
