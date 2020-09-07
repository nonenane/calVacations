USE [dbase1]
GO
/****** Object:  StoredProcedure [Vacation].[getListKadrForDep]    Script Date: 07.09.2020 10:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 2019-11-28
-- Description:	Получение списка сотрудников с неоплаченным отпуском за период
-- =============================================
CREATE PROCEDURE [Vacation].[getReportNotPayVacation]		
	@dateStart date = '2020-01-01', 
	@dateEnd date = '2020-10-01'
AS
BEGIN
	SET NOCOUNT ON;




select
	a.FIO,
	a.DataStartVacation,
	a.CountVacation,
	a.isCompensatory,
	a.Comment
from (
select 
	ISNULL(trim(k.lastname)+' ','')+ISNULL(trim(k.firstname)+' ','')+ISNULL(trim(k.secondname),'') as FIO,
	cv.DataStartVacation,
	cv.CountVacation,
	cv.isCompensatory,
	cv.Comment,
	DATEADD(day,isnull(cv.CountVacation,0),cv.DataStartVacation) as dateFilter
from 
	Vacation.j_ContentVacation cv 
		left join dbo.s_kadr k on k.id = cv.id_kadr
where 
	cv.isPaid = 0) as a
where @dateStart<=a.dateFilter and a.dateFilter<=@dateEnd
	
END
