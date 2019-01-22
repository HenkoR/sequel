USE [master]
GO
CREATE LOGIN [KyleManganyi] WITH PASSWORD=N'John2000' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Kyle.Manganyi], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Kyle.Manganyi]

GO
use [master]

GO
USE [sql101.Kyle.Manganyi]
GO
CREATE USER [KyleManganyi] FOR LOGIN [KyleManganyi]
GO
USE [sql101.Kyle.Manganyi]
GO
ALTER ROLE [db_owner] ADD MEMBER [KyleManganyi]
GO
