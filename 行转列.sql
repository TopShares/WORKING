
--行转列
/*
姓名       课程       分数

---------- ---------- -----------

张三       语文        74

张三       数学        83

张三       物理        93

李四       语文        74

李四       数学        84

李四       物理        94
*/

SELECT * FROM table pivot( MAX(分数) FOR 课程 IN (语文,数学,物理))a

/*
姓名       语文        数学        物理

---------- ----------- ----------- -----------

李四        74          84          94

张三        74          83          93
*/
*


PIVOT函数将列[WEEK]的行值转换为列，并使用聚合函数Count(TotalPrice)来统计每一个Week列在转换前有多少行数据，语句如下所示：

select *
from ShoppingCart as C 
PIVOT(count(TotalPrice) FOR [PackNum] IN([*20],[*20H],[*40],[*40H])) AS T 


select * from table1
pivot (一个函数，sum/max/min/count都可以（列显示的值） FOR  XX要显示成列名的那一列  IN ([对应的是XX里的值],[],[],……))
