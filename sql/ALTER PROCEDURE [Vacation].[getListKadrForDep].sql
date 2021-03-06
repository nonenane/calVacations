USE [dbase1]
GO
/****** Object:  StoredProcedure [Vacation].[getListKadrForDep]    Script Date: 07.09.2020 10:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2019-11-28
-- Description:	Получение списка сотрудников по отделу
-- =============================================
ALTER PROCEDURE [Vacation].[getListKadrForDep]	
	@id_dep int,
	@id_prog int
AS
BEGIN
	SET NOCOUNT ON;

DECLARE @countDay int  = 10;
	select @countDay =  cast(value as int)  from dbo.prog_config where id_prog = @id_prog and id_value = 'sous'


select 
	k.id,
	ISNULL(trim(k.lastname)+' ','')+ISNULL(trim(k.firstname)+' ','')+ISNULL(trim(k.secondname),'') as FIO,
	trim(p.cName) as namePost,
	trim(d.name) as nameDep,
	k.dateEmploy,
	k.dateUnemploy,
	f.FirstVacationDays,
	f.StartCalculation,
	k.id_WorkStatus,
	k.id_PersonnelType as kadrPersonnelType,
	lp.id_PersonnelType as personalPersonnelType
from 
	dbo.s_kadr k
		left join dbo.s_Posts p on p.id = k.id_posts
		left join dbo.departments d on d.id = k.id_departments
		left join Vacation.s_FirstVacationData f on f.id_kadr = k.id
		left join Personnel.LastPersonnelType lp on lp.id_kadr = k.id
where 
	(k.id_WorkStatus = 4 OR  (k.id_WorkStatus = 5 AND DATEDIFF(day,k.dateUnemploy,getdate())<@countDay)) 
	--and d.isOffice = 1 
	and( d.isOffice = 1 or (k.id_PersonnelType = 2 and d.isOffice = 0) )
	and (@id_dep=0 or k.id_departments = @id_dep)
order by  
	k.lastname asc
	
END
