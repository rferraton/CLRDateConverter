# CLRDateConverter

The advantage of CLR of SQL scalar function is that CLR will be faster and allow parallelism

## Date Converters

### JDE (Julian) Date to Datetime (Gregorian)

``` sql
DECLARE @testdate int=122026
DECLARE @testtime int=213

SELECT [dbo].[SQLJulianToGregorian](@testdate,@testtime)
SELECT [dbo].[SQLJulianToGregorian](@testdate,'')
```

will return 
2022-01-26 00:02:13.000 and 2022-01-26 00:00:00.000