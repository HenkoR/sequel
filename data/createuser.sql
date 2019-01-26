USE [master]
GO
CREATE LOGIN [JosephLeGrand] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Joseph.LeGrand], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Joseph.LeGrand]

GO
use [master]

GO
USE [sql101.Joseph.LeGrand]
GO
CREATE USER [JosephLeGrand] FOR LOGIN [JosephLeGrand]
GO
USE [sql101.Joseph.LeGrand]
GO
ALTER ROLE [db_owner] ADD MEMBER [JosephLeGrand]
GO
