USE [master]
GO
CREATE LOGIN [LisaQuluba] WITH PASSWORD=N'LisaQ11@sql' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Lisa.Quluba], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Lisa.Quluba]

GO
use [master]

GO
USE [sql101.Lisa.Quluba]
GO
CREATE USER [LisaQuluba] FOR LOGIN [LisaQuluba]
GO
USE [sql101.Lisa.Quluba]
GO
ALTER ROLE [db_owner] ADD MEMBER [LisaQuluba]
GO
