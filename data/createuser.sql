USE [master]
GO
CREATE LOGIN [NombusoSibiya] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Nombuso.Sibiya], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Nombuso.Sibiya]

GO
use [master]

GO
USE [sql101.Nombuso.Sibiya]
GO
CREATE USER [NombusoSibiya] FOR LOGIN [NombusoSibiya]
GO
USE [sql101.Nombuso.Sibiya]
GO
ALTER ROLE [db_owner] ADD MEMBER [NombusoSibiya]
GO
