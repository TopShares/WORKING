--表里的列字段
DECLARE @colName varchar(500) --声明@colName变量
DECLARE @tableName varchar(64) --声明表名
set @tableName='VW_ET_Shipment' --赋表名
set @colName='' --赋初值
SELECT @colName=@colName+COLUMN_NAME+',' 
FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@tableName
print subString(@colName,1,len(@colName)-1) --打印字段时去掉最后一个逗号






--库里的表数据行数
SELECT a.name,b.rows FROM sysobjects a
INNER JOIN sysindexes b ON a.id=b.id 
WHERE b.indid IN(0,1) AND a.Type='u'
ORDER BY b.rows desc