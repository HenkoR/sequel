USE [master]
GO
CREATE LOGIN [chubamoganedi] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.chuba.moganedi], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.chuba.moganedi]

GO
use [master]

GO
USE [sql101.chuba.moganedi]
GO
CREATE USER [chubamoganedi] FOR LOGIN [chubamoganedi]
GO
USE [sql101.chuba.moganedi]
GO
ALTER ROLE [db_owner] ADD MEMBER [chubamoganedi]
GO
