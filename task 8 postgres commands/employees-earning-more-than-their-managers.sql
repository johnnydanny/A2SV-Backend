# Write your MySQL query statement below
SELECT name AS EMPLOYEE FROM EMPLOYEE as e1

WHERE salary > (
                    SELECT salary  FROM EMPLOYEE as e2
                    WHERE e2.id = e1.managerId 
                )