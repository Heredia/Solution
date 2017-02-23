--------------------------------------------------------------------------------------
-- Seconds to "HHHH:mm:ss"
--------------------------------------------------------------------------------------
CREATE FUNCTION SecondsToTimeFormat
(
	@seconds BIGINT
)
RETURNS VARCHAR(50)
AS BEGIN
	RETURN
	(
				RIGHT('000'	+ CAST(@seconds	/ 3600			AS VARCHAR(50)), 4)
		+ ':' +	RIGHT('0'	+ CAST((@seconds % 3600) / 60	AS VARCHAR(2)),	2)
		+ ':' +	RIGHT('0'	+ CAST(@seconds	% 3600 % 60		AS VARCHAR(2)), 2)
	)
END
--------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------
-- "HHHH:mm:ss" to Seconds
--------------------------------------------------------------------------------------
CREATE FUNCTION TimeFormatToSeconds
(
	@timeFormat VARCHAR(50)
)
RETURNS BIGINT
AS BEGIN
	DECLARE @seconds BIGINT
	SET @seconds = 0;

	;WITH cte_timeFormat(timeFormat) AS
	(
		SELECT REPLACE(@timeFormat, ':', '.')
	)

	SELECT @seconds =
		3600 *	PARSENAME(timeFormat, 3)
		+ 60 *	PARSENAME(timeFormat, 2)
		+		PARSENAME(timeFormat, 1)
	FROM cte_timeFormat

	RETURN (@seconds)
END
--------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------
-- Tests
--------------------------------------------------------------------------------------
DECLARE @table TABLE(id INT, hora VARCHAR(20))

INSERT INTO @table VALUES(1, '000:01:10')
INSERT INTO @table VALUES(1, '000:02:40')
INSERT INTO @table VALUES(1, '000:03:20')

INSERT INTO @table VALUES(2, '000:01:10')
INSERT INTO @table VALUES(2, '000:00:50')
INSERT INTO @table VALUES(2, '000:59:34')

SELECT id, dbo.SecondsToTimeFormat(SUM(dbo.TimeFormatToSeconds(hora))) FROM @table GROUP BY id
--------------------------------------------------------------------------------------
SELECT dbo.TimeFormatToSeconds('002:59:46')
SELECT dbo.SecondsToTimeFormat(10786)
--------------------------------------------------------------------------------------