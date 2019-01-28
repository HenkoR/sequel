USE [master]
GO
CREATE LOGIN [FiwaLekhulani] WITH PASSWORD='fiwa1234!' MUST_CHANGE, DEFAULT_DATABASE=[sql101.Fiwa.Lekhulani], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
use [sql101.Fiwa.Lekhulani]

GO
use [master]

GO
USE [sql101.Fiwa.Lekhulani]
GO
CREATE USER [FiwaLekhulani] FOR LOGIN [FiwaLekhulani]
GO
USE [sql101.Fiwa.Lekhulani]
GO
ALTER ROLE [db_owner] ADD MEMBER [FiwaLekhulani]
GO
