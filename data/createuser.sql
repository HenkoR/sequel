USE [master]
GO
CREATE LOGIN [tafaravurayayi] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.tafara.vurayayi], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.tafara.vurayayi]

GO
use [master]

GO
USE [sql101.tafara.vurayayi]
GO
CREATE USER [tafaravurayayi] FOR LOGIN [tafaravurayayi]
GO
USE [sql101.tafara.vurayayi]
GO
ALTER ROLE [db_owner] ADD MEMBER [tafaravurayayi]
GO
