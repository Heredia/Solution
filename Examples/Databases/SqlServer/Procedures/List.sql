IF EXISTS(SELECT TOP 1 * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID('[List]') AND type IN ( 'P', 'PC' ))
BEGIN
	DROP PROCEDURE dbo.[List]
END
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

CREATE PROCEDURE dbo.[List]
	@PageIndex		INT				= 1,
	@PageSize		INT				= NULL,
	@OrderProperty	VARCHAR(100)	= 'Id',
	@OrderAsc		BIT				= 1
AS BEGIN
	SET NOCOUNT ON;

	DECLARE	@InitialPage	INT	= (@PageIndex	* @PageSize) - 1;
	DECLARE @FinalPage		INT	= (@InitialPage	+ @PageSize) - 1;

	;WITH FilteredOrdered AS
	(
		SELECT
			 *
			,ROW_NUMBER() OVER (ORDER BY
				 CASE WHEN @OrderAsc	IS NULL	OR	@OrderProperty	IS NULL		THEN Id		END ASC
				,CASE WHEN @OrderAsc	= 1		AND @OrderProperty	= 'Id'		THEN Id		END ASC
				,CASE WHEN @OrderAsc	= 0		AND @OrderProperty	= 'Id'		THEN Id		END DESC
				,CASE WHEN @OrderAsc	= 1		AND @OrderProperty	= 'Name'	THEN Name	END ASC
				,CASE WHEN @OrderAsc	= 0		AND @OrderProperty	= 'Name'	THEN Name	END DESC
			) AS Line
			,COUNT(*) OVER () AS Total
		FROM [Table] (NOLOCK)
	)

	SELECT * FROM FilteredOrdered (NOLOCK)
	WHERE @PageSize IS NULL OR (Line BETWEEN @InitialPage AND @FinalPage);
END
GO