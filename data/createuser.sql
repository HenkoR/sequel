USE [master]
GO
CREATE LOGIN [cedricmanamela] WITH PASSWORD=N'Cedric#01' MUST_CHANGE, DEFAULT_DATABASE=[sql101.cedric.manamela], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.cedric.manamela]

GO
use [master]

GO
USE [sql101.cedric.manamela]
GO
CREATE USER [cedricmanamela] FOR LOGIN [cedricmanamela]
GO
USE [sql101.cedric.manamela]
GO
ALTER ROLE [db_owner] ADD MEMBER [cedricmanamela]
GO
