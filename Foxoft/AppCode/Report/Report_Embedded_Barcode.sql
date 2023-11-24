



SELECT  t1.*, t2.number + 1 RepeatNumber
FROM    DcProducts t1
JOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < 1




