## Structured Query Language (SQL)
### _Homework_

1.	What is SQL? What is DML? What is DDL? Recite the most important SQL commands.

    -   SQL (Structured Query Language)
    is a standard interactive and programming language for getting information from and updating a database. Although SQL is both an ANSI and an ISO standard, many database products support SQL with proprietary extensions to the standard language. Queries take the form of a command language that lets you select, insert, update, find out the location of data, and so forth.There is also a programming interface.

    -   DML (Data Manipulation Language)
    is a subset of SQL that deals with manipulation of data in tables (SELECT, INSERT, UPDATE, DELETE)

    -   DDL (Data Definition Language)
    is a subset of SQL that deals with manipulation of the DB schema - relations and structure of tables (CREATE, DROP, ALTER), users and user permissions (GRANT, REVOKE)

1.	What is Transact-SQL (T-SQL)?
    
    T-SQL is an extension to the standart SQL language. It is the standart SQL language used in MS SQL Serve. It supports constructions used in the high-level procedural programming languages - if statements, loops, exceptions. It is usually used for writing stored procedure, functions, triggers etc.

1.	Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.

    -   did it :)

1.	Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

```sql
USE TelerikAcademy

SELECT *
FROM Departments
```

1.	Write a SQL query to find all department names.

```sql
USE TelerikAcademy

SELECT Name
FROM Departments
```

1.	Write a SQL query to find the salary of each employee.

```sql
USE TelerikAcademy

SELECT Salary
FROM Employees
```

1.	Write a SQL to find the full name of each employee.

```sql
USE TelerikAcademy

SELECT ISNULL(FirstName, '') + ' ' + ISNULL(MiddleName, '') + ' ' + ISNULL(LastName, '')
FROM Employees
```

1.	Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

```sql
USE TelerikAcademy

SELECT FirstName + '.' + LastName + '@telerik.com'
FROM Employees
```

1.	Write a SQL query to find all different employee salaries.

```sql
USE TelerikAcademy

SELECT DISTINCT Salary
FROM Employees
```

1.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

```sql
USE TelerikAcademy

SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'
```

1.	Write a SQL query to find the names of all employees whose first name starts with "SA".

```sql
USE TelerikAcademy

SELECT FirstName
FROM Employees
WHERE FirstName LIKE 'SA%'
```

1.	Write a SQL query to find the names of all employees whose last name contains "ei".

```sql
USE TelerikAcademy

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

```

1.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

```sql
USE TelerikAcademy

SELECT Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

```

1.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

```sql
USE TelerikAcademy

SELECT FirstName, LastName
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

```

1.	Write a SQL query to find all employees that do not have manager.

```sql
USE TelerikAcademy

SELECT FirstName, LastName, ManagerID
FROM Employees
WHERE ManagerID IS Null

```

1.	Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

```sql
USE TelerikAcademy

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC
```

1.	Write a SQL query to find the top 5 best paid employees.

```sql
USE TelerikAcademy

SELECT TOP 5 FirstName, LastName, Salary
FROM Employees
ORDER BY Salary DESC
```

1.	Write a SQL query to find all employees along with their address. Use inner join with `ON` clause.

```sql
USE TelerikAcademy

SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e INNER JOIN Addresses a
    ON e.AddressID = a.AddressID
```

1.	Write a SQL query to find all employees and their address. Use equijoins (conditions in the `WHERE` clause).

```sql
USE TelerikAcademy

SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID
```

1.	Write a SQL query to find all employees along with their manager.

```sql
USE TelerikAcademy

SELECT e.FirstName, e.LastName, e.ManagerID, a.EmployeeID AS FoundManagerId, a.FirstName AS ManagerName
FROM Employees e, Employees a
WHERE e.ManagerID = a.EmployeeID
```

1.	Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: `Employees e`, `Employees m` and `Addresses a`.

```sql
USE TelerikAcademy

SELECT e.FirstName, e.LastName, a.AddressText, m.FirstName + ' ' + m.LastName AS ManagerName
FROM Employees e
    INNER JOIN Employees m
        ON e.ManagerID = m.EmployeeID
    INNER JOIN Addresses a
        ON e.AddressID = a.AddressID
```

1.	Write a SQL query to find all departments and all town names as a single list. Use `UNION`.

```sql
USE TelerikAcademy

SELECT d.Name AS DepartmentsAndTowns
    FROM Departments d
UNION
SELECT t.Name AS DepartmentsAndTowns
    FROM Towns t
```

1.	Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

RIGHT OUTER JOIN

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, m.FirstName + ' ' + m.LastName AS ManagerName
FROM Employees m
    RIGHT OUTER JOIN Employees e
        ON m.EmployeeID = e.ManagerID
    INNER JOIN Addresses a
        ON a.AddressID = e.AddressID
```

LEFT OUTER JOIN

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, m.FirstName + ' ' + m.LastName AS ManagerName
FROM Employees e
    LEFT OUTER JOIN Employees m
        ON m.EmployeeID = e.ManagerID
    INNER JOIN Addresses a
        ON a.AddressID = e.AddressID
```

1.	Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, d.Name AS DepartmentName, e.HireDate
FROM Employees e
    INNER JOIN Departments d
        ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance')
    AND (year(e.HireDate) BETWEEN 1995 AND 2005)
```
