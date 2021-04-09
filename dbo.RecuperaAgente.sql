CREATE PROCEDURE [dbo].[RecuperaAgente]
	@codiceArea varchar(5)
	
AS
	SELECT dbo.Agenti.CF, dbo.Agenti.Nome, dbo.Agenti.Cognome, dbo.Agenti.AnniServizio
FROM   dbo.Agenti INNER JOIN
             dbo.Assegnazione ON dbo.Agenti.IdAgente = dbo.Assegnazione.IdAgente INNER JOIN
             dbo.AreeMetropolitane ON dbo.Assegnazione.IdArea = dbo.AreeMetropolitane.IdArea
WHERE CodiceArea = @codiceArea
GROUP BY dbo.Agenti.CF, dbo.Agenti.Nome, dbo.Agenti.Cognome, dbo.Agenti.AnniServizio
RETURN 0