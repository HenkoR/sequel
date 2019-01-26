USE [master]
GO
CREATE LOGIN [BathandeNdaba] WITH PASSWORD=N'ba23tuman!1' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Bathande.Ndaba], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Bathande.Ndaba]

GO
use [master]

GO
USE [sql101.Bathande.Ndaba]
GO
CREATE USER [BathandeNdaba] FOR LOGIN [BathandeNdaba]
GO
USE [sql101.Bathande.Ndaba]
GO
ALTER ROLE [db_owner] ADD MEMBER [BathandeNdaba]
GO
