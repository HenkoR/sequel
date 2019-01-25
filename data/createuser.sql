USE [master]
GO
CREATE LOGIN [darrenadams] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.darren.adams], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.darren.adams]

GO
use [master]

GO
USE [sql101.darren.adams]
GO
CREATE USER [darrenadams] FOR LOGIN [darrenadams]
GO
USE [sql101.darren.adams]
GO
ALTER ROLE [db_owner] ADD MEMBER [darrenadams]
GO
