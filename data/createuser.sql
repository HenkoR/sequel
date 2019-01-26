USE [master]
GO
CREATE LOGIN [dinolannaidoo] WITH PASSWORD=N'batman@27' MUST_CHANGE, DEFAULT_DATABASE=[sql101.dinolan.naidoo], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.dinolan.naidoo]

GO
use [master]

GO
USE [sql101.dinolan.naidoo]
GO
CREATE USER [dinolannaidoo] FOR LOGIN [dinolannaidoo]
GO
USE [sql101.dinolan.naidoo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dinolannaidoo]
GO
