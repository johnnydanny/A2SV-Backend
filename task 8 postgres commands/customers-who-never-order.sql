# Write your MySQL query statement below

SELECT name AS Customers FROM Customers
Where id not in (SELECT customerId from Orders)