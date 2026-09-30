select prh.Id
	, prh.CurrAccCode
	, prh.PayrollPeriodId
	, GrossSalary = (
		select isnull(sum(l.AmountLoc), 0)
		from TrPayrollLines l
		where l.PayrollHeaderId = prh.Id
		  and l.PayrollItemType in (1, 2, 3)
	)
	, NetSalary = (
		select isnull(sum(case 
			when l.PayrollItemType in (1, 2, 3) then l.AmountLoc 
			when l.PayrollItemType in (4, 5, 6) then -l.AmountLoc 
			else 0 end), 0)
		from TrPayrollLines l
		where l.PayrollHeaderId = prh.Id
	)
	, CurrAccBalance = dbo.CurrAccBalance(prh.CurrAccCode, isnull(cast(eomonth(datefromparts(prp.PeriodYear, prp.PeriodMonth, 1)) as datetime) + cast('23:59:59' as datetime), getdate()))
	, PayrollLineId = prl.Id
	, prl.PayrollItemType
	, PayrollItemTypeName = case prl.PayrollItemType
		when 1 then 'Maaş'
		when 2 then 'Bonus'
		when 3 then 'Əlavə İş'
		when 4 then 'Vergi'
		when 5 then 'Sığorta'
		when 6 then 'Tutulma'
		else 'Digər'
	  end
	, LineDescription = prl.Description
	, prl.Amount
	, prl.CurrencyCode
	, prl.ExchangeRate
	, prl.AmountLoc
	, cari.CurrAccDesc
	, cari.FirstName
	, cari.LastName
	, cari.PhoneNum
	, EmployeeName = isnull(nullif(cari.CurrAccDesc, ''), rtrim(isnull(cari.FirstName, '') + ' ' + isnull(cari.LastName, '')))
	, prp.PeriodYear
	, prp.PeriodMonth
	, PeriodName = right('0000' + cast(prp.PeriodYear as varchar(4)), 4) + '-' + right('00' + cast(prp.PeriodMonth as varchar(2)), 2)

	from TrPayrollLines prl
	inner join TrPayrollHeaders prh on prl.PayrollHeaderId = prh.Id
	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id
	left join DcCurrAccs cari on cari.CurrAccCode = prh.CurrAccCode

	where prh.Id = @PayrollHeaderId
	order by prl.PayrollItemType
