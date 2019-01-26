USE [master]
GO
CREATE LOGIN [scott] WITH PASSWORD=N'rabbit123!@# MUST_CHANGE, DEFAULT_DATABASE=[sql101.buhle.mthembu], CHECK_EXPIRATION=ON, CHECK_POLICY=ON

use [sql101.buhle.mthembu]

GO
use [master]

GO
USE [sql101.buhle.mthembu]
GO
CREATE USER [zeenhle] FOR LOGIN [scott]
GO
USE [sql101.buhle.mthembu]
GO
ALTER ROLE [scott] ADD MEMBER [zeenhle]
GO
