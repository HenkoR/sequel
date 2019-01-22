USE [master]
GO
CREATE LOGIN [tshenolomatome] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.tshenolo.matome], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.tshenolo.matome]

GO
use [master]

GO
USE [sql101.tshenolo.matome]
GO
CREATE USER [tshenolomatome] FOR LOGIN [tshenolomatome]
GO
USE [sql101.tshenolo.matome]
GO
ALTER ROLE [db_owner] ADD MEMBER [tshenolomatome]
GO
