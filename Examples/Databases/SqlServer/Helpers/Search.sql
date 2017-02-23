--------------------------------------------------------------------------
-- Search
--------------------------------------------------------------------------
DECLARE	@Search VARCHAR(MAX)
SET @Search = ''
--------------------------------------------------------------------------
SELECT DISTINCT
	  O.TYPE_DESC								AS 'Type'
	 ,SCHEMA_NAME(O.SCHEMA_ID) + '.' + O.name	AS 'Name'
 FROM SYS.SQL_MODULES							AS M
 JOIN SYS.OBJECTS								AS O
   ON M.OBJECT_ID								 = O.OBJECT_ID
WHERE M.DEFINITION								LIKE '%' + @Search + '%'
ORDER BY 1, 2
--------------------------------------------------------------------------