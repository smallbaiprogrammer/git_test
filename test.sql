select Name as 'Employee' from Employee where Salary > (select MIN(Salary) FROM Employee WHERE MANAGEID NOT NULL);
SELECT DEPARTMENT.NAME as 'Department' ,
 e1.NAME as 'name',
 Salary 
FROM 
    DEPARTMENT d 
    JOIN Employee e1 
    ON d.ID = e1.DEPARTMENTID 
where 3 >(select
         count(distinct e2.Salary) 
         from 
               Employee e2 
        where e2.Salary > e1.Salary 
        and e1.DepartmentId = e2.DepartmentId)
; 