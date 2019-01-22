USE [master]
GO
CREATE LOGIN [NtokozoMotsumi] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Ntokozo.Motsumi], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Ntokozo.Motsumi]

GO
use [master]

GO
USE [sql101.firstname.Motsumi]
GO
CREATE USER [NtokozoMotsumi] FOR LOGIN [NtokozoMotsumi]
GO
USE [sql101.Ntokozo.Motsumi]
GO
ALTER ROLE [db_owner] ADD MEMBER [NtokozoMotsumi]
GO
