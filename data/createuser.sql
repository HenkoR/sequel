USE [master]
GO
CREATE LOGIN [ItumelengMasuluke] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Itumeleng.Masuluke], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Itumeleng.Masuluke]

GO
use [master]

GO
USE [sql101.Itumeleng.Masuluke]
GO
CREATE USER [ItumelengMasuluke] FOR LOGIN [ItumelengMasuluke]
GO
USE [sql101.Itumeleng.Masuluke]
GO
ALTER ROLE [db_owner] ADD MEMBER [ItumelengMasuluke]
GO
