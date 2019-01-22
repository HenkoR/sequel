USE [master]
GO
CREATE LOGIN [GiftLanga] WITH PASSWORD=N'G4tDB__Xcs' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Gift.Langa], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Gift.Langa]

GO
use [master]

GO
USE [sql101.Gift.Langa]
GO
CREATE USER [GiftLanga] FOR LOGIN [GiftLanga]
GO
USE [sql101.Gift.Langa]
GO
ALTER ROLE [db_owner] ADD MEMBER [GiftLanga]
GO
