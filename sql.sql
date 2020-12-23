# 数据库相关内容
# 今天之前彻底搞定 mysql 熟练度的问题
# 明天彻底复习关于mysql的一切
# 周三晚上之前掌握关于mysql 的 anything 
每天一道SQL算法题一道 数据结构算法题

周末之前搞定所有的计算机网络和操作系统的相关知识

2020完全搞定应该搞定的知识
彻底搞定关于Java的所有知识 for  one week time 
还有数据结构和算法

At new year,you should study new something.

当然这些知识一个也不能落下

每次面试之前，关于每一类的面试题至少写一个

采用一个spring写一个程序论坛网站 或者一个电商平台 

下周开始复习Java基础知识和掌握REDIS，写一个自己的开源项目
然后掌握spring
# 查找人数最多的三个城市 
country 
id name location
select location ,count(id) as number from country order by number desc limit 0,3 ;
SELECT location ,count()

# 找出每一科成绩最高的人
study 
id name object sorce
select name,object,max(sorce) as '最高分' from study group by object;

CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  RETURN (
      # Write your MySQL query statement below.
      select Salary 
      from Employee
      group by Salary ,
      order by Salary desc,
      limit N,1; 
  );
END

select Department.name as Department,Employee.name as Employee,max(Salary) as  from Employee,Department group by DepartmentID
SELECT 
    Department.NAME AS 'DEPARTMENT',
    Employee.NAME AS 'EMPLOYEE',
    Salary
FROM EMPLOYEE
        JOIN 
    Department ON Employee.DepartmentID = Department.id
WHERE
    (Employee.DepartmentID,Salary) IN 
    (SELECT
        DEPARTMENTID,MAX(Salary)
        FROM Employee
        group BY DEPARTMENTID
    )
;

SELECT 
    DEPARTMENT.NAME AS 'DEPARTMENT',
    Employee.NAME AS 'EMPLOYEE',
    Salary
FroM 
    Employee
        JOIN
    Department ON Employee.DepartmentID = Department.id
WHERE
    (EMPLOYEE.DEPARTMENTID,Salary) IN
    (   SELECT
            DEPARTMENTID,MAX(Salary)
        FROM 
            Employee
        group BY DEPARTMENTID
    )
;
SELECT
    Department.name AS 'Department',
    Employee.name AS 'Employee',
    Salary
FROM
    Employee
        JOIN
    Department ON Employee.DepartmentId = Department.Id
WHERE
    (Employee.DepartmentId , Salary) IN
    (   SELECT
            DepartmentId, MAX(Salary)
        FROM
            Employee
        GROUP BY DepartmentId
	)
;


select Person.FirstName ,
     Person.LastName ,
      Address.city,
      Address.state 
      from Person 
        join Address in 
        Person.PersonId = Address.PersonId
;

# 关于 MySQL 的 知识今天全部搞定

# mysql 数据库的主从同步
# mysql 一台主服务器，多台从服务器，主服务器修改日志的二进制文件，从服务器通过日志的二进制文件来进行相应的操作
MVCC 乐观锁的实现 实现了 读-写 写-读 非阻塞 只有在写-写的时候才会进行阻塞
当事务更新数据的时候，不会直接覆盖以前的数据，而是生成一个新的版本的数据，因此每一条数据都会有多个版本进行储存
这种方式其实与JAVA的CopyOnWriteHashmap 类似 这个版本一般是事务结束的时间戳 或者是 随事务增长的id
@https://yq.aliyun.com/articles/283418
# 关于Mysql 的 知识上午看 
主从同步
主从同步就是主数据库发生变化的时候，从数据库也会跟着变化
在master 数据库中的，主从同步事件会被写进二进制日志中，在从数据库(slave) 会读取主从同步事件，然后对从数据库进行相应的操作
主从同步事件会有三种形式
statement # 将对数据库操作的SQL 语句写于 binlog 中
row 会将每一条数据的变化写入 Binlog 中
mixed 二者混合写入Binlog 中 
在主服务器上进行的操作
当master 上的数据发生改变的时候，该事件变化会按照顺序被写入binlog中，binlog dump线程待到
从服务器连接到主服务时，主服务器线程会为slave开启binlog dump 线程，
当master的binlog 变化时，该线程会通知slave，然后将binlog 内容发送给slave

从服务器上的操作
当主从同步开启的时候，从服务器上会创建两个线程
I/O 线程 将服务器中的binlog 发送到从服务器上并保持到relay log 中
SQL 线程 读取relay log 并且根据内容进行相应操作


mysql 
@ https://blog.csdn.net/ThinkWon/article/details/104778621
主从复制
@https://zhuanlan.zhihu.com/p/89796383
# 下午练习
# 晚上总结一下

# CLASS ID NAME OBJECT SORCE 
SELECT MAX(SORCE) AS 'MAX SORCE' FROM CLASS GROUP BY OBJECT; 

SELECT DEPARTMENT.NAME AS 'DEPARTMENT' , EMPLOYEE.NAME AS 'EMPLOYEE' ,Salary
FROM DEPARTMENT JOIN EMPLOYEE ON DEPARTMENT.ID = EMPLOYEE.DEPARTMENTID
WHERE (DEPARTMENT.id, Salary) IN (SELECT DEPARTMENTID , MAX(Salary) FROM EMPLOYEE GROUP BY DEPARTMENTID)
; 
# 


# 关于 spring 框架 
@ https://www.w3cschool.cn/wkspring/ 