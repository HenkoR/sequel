USE [master]
GO
CREATE LOGIN [mpinanemohale] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.mpinane.mohale], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.mpinane.mohale]

GO
use [master]

GO
USE [sql101.mpinane.mohale]
GO
CREATE USER [mpinanemohale] FOR LOGIN [mpinanemohale]
GO
USE [sql101.mpinane.mohale]
GO
ALTER ROLE [db_owner] ADD MEMBER [mpinanemohale]
GO
