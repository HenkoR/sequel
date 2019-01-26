USE [master]
GO
CREATE LOGIN [KudzaiMuranga] WITH PASSWORD=N'Muranga1@' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Kudzai.Muranga], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Kudzai.Muranga]

GO
use [master]

GO
USE [sql101.Kudzai.Muranga]
GO
CREATE USER [KudzaiMuranga] FOR LOGIN [KudzaiMuranga]
GO
USE [sql101.Kudzai.Muranga]
GO
ALTER ROLE [db_owner] ADD MEMBER [KudzaiMuranga]
GO
