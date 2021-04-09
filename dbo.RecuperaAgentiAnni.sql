CREATE PROCEDURE [dbo].[RecuperaAgentiAnni]
	@anniServizio int
AS
	SELECT * from Agenti where AnniServizio = @anniServizio
RETURN 0