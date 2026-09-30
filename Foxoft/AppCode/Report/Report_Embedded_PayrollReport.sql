select prh.Id
	, prh.CurrAccCode
	, prh.PayrollPeriodId
	, prh.GrossSalary
	, prh.NetSalary
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
