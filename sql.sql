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
select location ,count(id) as number from country order by number desc limit 3 ;

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
