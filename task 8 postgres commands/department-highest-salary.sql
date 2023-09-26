# Write your MySQL query statement below
SELECT dept.name AS Department, emp.name AS Employee, emp.salary AS Salary
FROM Department dept, Employee emp
WHERE emp.departmentId = dept.id
AND emp.salary = (SELECT MAX(Salary) FROM Employee emp WHERE emp.departmentId = dept.id)