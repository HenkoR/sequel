USE [master]
GO
CREATE LOGIN [keoabetswemorake] WITH PASSWORD=N'rabbit123!@#' MUST_CHANGE, DEFAULT_DATABASE=[sql101.keoabetswe.morake], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.keoabetswe.morake]

GO
use [master]

GO
USE [sql101.keoabetswe.morake]
GO
CREATE USER [keoabetswemorake] FOR LOGIN [keoabetswemorake]
GO
USE [sql101.keoabetswe.morake]
GO
ALTER ROLE [db_owner] ADD MEMBER [keoabetswemorake]
GO
