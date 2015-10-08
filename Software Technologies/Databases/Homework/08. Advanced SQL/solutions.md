## 05. Advanced SQL
### _Homework_

1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
	*	Use a nested `SELECT` statement.

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, e.Salary
FROM Employees e
WHERE e.Salary = 
    (SELECT MIN(es.Salary)
    FROM Employees es)
```
1.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, e.Salary
FROM Employees e
WHERE e.Salary <= 
    (SELECT MIN(es.Salary)
    FROM Employees es) * 1.1
```
1.	Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
	*	Use a nested `SELECT` statement.

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + ISNULL(e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, e.Salary, d.Name AS Department
FROM Employees e
INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
    (SELECT MIN(es.Salary)
    FROM Employees es
    WHERE es.DepartmentID = e.DepartmentID)
```
1.	Write a SQL query to find the average salary in the department #1.

```sql
USE TelerikAcademy

SELECT AVG(Salary) AS AverageSalaryDep#1
FROM Employees
WHERE DepartmentID = 1
```
1.	Write a SQL query to find the average salary  in the "Sales" department.

```sql
USE TelerikAcademy

SELECT AVG(Salary) AS AverageSalarySalesDep
FROM Employees e
    INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
```
1.	Write a SQL query to find the number of employees in the "Sales" department.

```sql
USE TelerikAcademy

SELECT COUNT(e.EmployeeID) AS SalesEmployeesCount
FROM Employees e
    INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'

```
1.	Write a SQL query to find the number of all employees that have manager.

```sql
USE TelerikAcademy

SELECT COUNT(e.EmployeeID)
FROM Employees e
WHERE e.ManagerID IS NOT Null
```
1.	Write a SQL query to find the number of all employees that have no manager.

```sql
USE TelerikAcademy

SELECT COUNT(e.EmployeeID)
FROM Employees e
WHERE e.ManagerID IS Null
```
1.	Write a SQL query to find all departments and the average salary for each of them.

```sql
USE TelerikAcademy

SELECT d.Name AS Department, AVG(e.Salary) AS AverageSalary
FROM Employees e
    INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
```
1.	Write a SQL query to find the count of all employees in each department and for each town.

```sql
USE TelerikAcademy
    
SELECT d.Name AS Department, t.Name AS Town, COUNT(e.EmployeeID) AS EmployeesCount
FROM Employees e
    INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
    INNER JOIN Addresses a
    ON a.AddressID = e.AddressID
    INNER JOIN Towns t
    ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
```
1.	Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

```sql
USE TelerikAcademy

SELECT COUNT(e.ManagerID) AS ManagedEmployeesCount, m.FirstName + ' ' + m.LastName AS ManagerName
FROM Employees e
    INNER JOIN Employees m
    ON e.ManagerID = m.EmployeeID
GROUP BY e.ManagerID, m.FirstName, m.LastName
HAVING COUNT(e.ManagerID) = 5
```
1.	Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS ManagerName
FROM Employees e
    LEFT OUTER JOIN Employees m
    ON e.ManagerID = m.EmployeeID
```
1.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in `LEN(str)` function.

```sql
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName
FROM Employees e
WHERE LEN(e.LastName) = 5
```
1.	Write a SQL query to display the current date and time in the following format "`day.month.year hour:minutes:seconds:milliseconds`".

```sql
SELECT FORMAT(GETDATE(), 'dd.mm.yyyy HH:mm:ss:fff')
```
	*	Search in Google to find how to format dates in SQL Server.
1.	Write a SQL statement to create a table `Users`. Users should have username, password, full name and last login time.

```sql
USE TelerikAcademy

CREATE TABLE Users (
    UserId int IDENTITY PRIMARY KEY,
    Username varchar(30) NOT NULL UNIQUE,
    Pass nvarchar(100) CHECK (LEN(Pass) > 5) NOT NULL,
    FullName varchar(200),
    LastLogin datetime2
)
GO
```
	*	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
	*	Define the primary key column as identity to facilitate inserting records.
	*	Define unique constraint to avoid repeating usernames.
	*	Define a check constraint to ensure the password is at least 5 characters long.
1.	Write a SQL statement to create a view that displays the users from the `Users` table that have been in the system today.

```sql
CREATE VIEW DailyUsers AS
SELECT Username, LastLogin
FROM Users
WHERE LastLogin >= CONVERT(date, GETDATE())
```
	*	Test if the view works correctly.
1.	Write a SQL statement to create a table `Groups`. Groups should have unique name (use unique constraint).

```sql
USE TelerikAcademy
CREATE TABLE Groups (
    GroupId int IDENTITY,
    Name varchar(50) NOT NULL UNIQUE,
    CONSTRAINT PK_Groups PRIMARY KEY(GroupId)
)
GO
```
	*	Define primary key and identity column.
1.	Write a SQL statement to add a column `GroupID` to the table `Users`.

```sql
USE TelerikAcademy
ALTER TABLE Users
ADD GroupId int
GO
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
    FOREIGN KEY (GroupId)
    REFERENCES Groups(GroupId)
GO
```
	*	Fill some data in this new column and as well in the `Groups table.
	*	Write a SQL statement to add a foreign key constraint between tables `Users` and `Groups` tables.
1.	Write SQL statements to insert several records in the `Users` and `Groups` tables.

```sql
INSERT INTO Groups VALUES
    ('autogroup1'),
    ('autogroup2'),

INSERT INTO Users VALUES
    ('autouser1', 'autouser1pass', 'autouser1full', null, 1)
```
1.	Write SQL statements to update some of the records in the `Users` and `Groups` tables.

```sql
USE TelerikAcademy
UPDATE Users
    SET Username = Username + ' modified'
    WHERE LEFT(Username, 4) = 'user'
GO
UPDATE Groups
    SET Name = Name + ' modified'
    WHERE LEFT(Name, 4) = 'Auto'
```
1.	Write SQL statements to delete some of the records from the `Users` and `Groups` tables.

```sql
USE TelerikAcademy
DELETE
    FROM Users
    WHERE GroupId = 2

DELETE
    FROM Groups
    WHERE GroupId = 2
```
1.	Write SQL statements to insert in the `Users` table the names of all employees from the `Employees` table.

```sql
USE TelerikAcademy
INSERT INTO Users (Username, Pass, FullName)
    (
        SELECT 
            LOWER(LEFT(FirstName, 1) + '.' + LastName),
            LOWER(LEFT(FirstName, 1) + '.' + LastName),
            CONCAT(FirstName, ' ', LastName)
        FROM Employees
    )
GO
```
	*	Combine the first and last names as a full name.
	*	For username use the first letter of the first name + the last name (in lowercase).
	*	Use the same for the password, and `NULL` for last login time.
1.	Write a SQL statement that changes the password to `NULL` for all users that have not been in the system since 10.03.2010.

```sql
USE TelerikAcademy
UPDATE Users
    SET Pass = NULL
    WHERE LastLogin <= CONVERT(date, '2010/03/10')
GO
```
1.	Write a SQL statement that deletes all users without passwords (`NULL` password).

```sql
USE TelerikAcademy

DELETE
    FROM USERS
    WHERE Pass IS NULL
```
1.	Write a SQL query to display the average employee salary by department and job title.

```sql
USE TelerikAcademy

SELECT d.Name DepartmentName, e.JobTitle, AVG(e.Salary) AverageSalary
FROM Employees e
    INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
```
1.	Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

```sql
USE TelerikAcademy

SELECT d.Name DepartmentName, e.JobTitle, MIN(e.Salary) MinSalary, MIN(e.FirstName) ShortestEmployeeName
FROM Employees e
    INNER JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
```
1.	Write a SQL query to display the town where maximal number of employees work.

```sql
USE TelerikAcademy

SELECT TOP 1 t.Name Town, COUNT(*) AS EmployeeCount
FROM Employees e
    INNER JOIN Addresses a
        ON e.AddressID = a.AddressID
    INNER JOIN Towns t
        ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY EmployeeCount DESC
    
```
1.	Write a SQL query to display the number of managers from each town.

```sql
USE TelerikAcademy

SELECT t.Name Town, COUNT(DISTINCT m.EmployeeId) AS ManagersCount
FROM Employees e
    INNER JOIN Employees m
        ON e.ManagerID = m.EmployeeID
    INNER JOIN Addresses a
        ON m.AddressID = a.AddressID
    INNER JOIN Towns t
        ON a.TownID = t.TownID
GROUP BY t.Name
```

1.	Start a database transaction, delete all employees from the '`Sales`' department along with all dependent records from the pother tables.

```sql
BEGIN TRAN

    ALTER TABLE Departments
        DROP CONSTRAINT FK_Departments_Employees
    GO

    DELETE * 
        FROM Employees e
        JOIN Departments d
            ON e.DepartmentId = d.DepartmentId
        WHERE d.Name = 'Sales'

ROLLBACK TRAN
```
	*	At the end rollback the transaction.
1.	Start a database transaction and drop the table `EmployeesProjects`.

```sql
BEGIN TRAN

    DROP TABLE EmployeesProjects

ROLLBACK TRAN
```
	*	Now how you could restore back the lost table data?
1.	Find how to use temporary tables in SQL Server.

```sql
    SELECT * 
        INTO #TempEmployeesProjects
        FROM EmployeesProjects

    DROP TABLE EmployeesProjects

    SELECT * 
        INTO EmployeesProjects
        FROM #TempEmployeesProjects

    DROP TABLE #TempEmployeesProjects
```
	*	Using temporary tables backup all records from `EmployeesProjects` and restore them back after dropping and re-creating the table.
