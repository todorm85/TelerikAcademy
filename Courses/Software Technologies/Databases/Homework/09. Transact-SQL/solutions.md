## 06. Transact SQL
### _Homework_

1.	Create a database with two tables: `Persons(Id(PK), FirstName, LastName, SSN)` and `Accounts(Id(PK), PersonId(FK), Balance)`.
	*	Insert few records for testing.
	*	Write a stored procedure that selects the full names of all persons.

```sql
USE BankAccounts

-- Create tables
CREATE TABLE People (
    PersonId int IDENTITY,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50),
    SSN nvarchar(50) NOT NULL,
    CONSTRAINT PK_PEOPLE PRIMARY KEY(PersonId)
)

GO

CREATE TABLE Accounts (
    AccountId int IDENTITY,
    PersonId int NOT NULL,
    Balance money NOT NULL,
    CONSTRAINT PK_ACCOUNTS PRIMARY KEY(AccountId),
    CONSTRAINT FK_ACCOUNTS_PEOPLE 
        FOREIGN KEY (PersonId)
        REFERENCES People(PersonId)
)

GO
-- Insert data in tables
DECLARE @index int = 10

WHILE(@index>0)
BEGIN
    INSERT INTO People VALUES (
        ('Person'+CAST(@index AS varchar)+' FirstName'),
        ('Person'+CAST(@index AS varchar)+' LastName'),
        ('Person'+CAST(@index AS varchar)+' SSN'))
    SET @index = @index-1
END

GO

DECLARE @index int = 11

WHILE(@index>1)
BEGIN
    INSERT INTO Accounts VALUES (
        (@index),
        (@index * 1000))
    SET @index = @index-1
END

GO
-- Create procedure to select person full name
CREATE PROC dbo.usp_SelectPersonFullName
AS
  SELECT CONCAT(FirstName, ISNULL(' ' + LastName, '')) AS FullName
  FROM People

GO
```

1.	Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

```sql
USE BankAccounts
GO

CREATE PROC dbo.usp_DisplayPeopleByBalance(
    @minBalance money = 0)
AS
    SELECT CONCAT(p.FirstName, ISNULL(' ' + p.LastName, '')) AS FullName, a.Balance
    FROM People p
    INNER JOIN Accounts a
        ON p.PersonId = a.PersonId
    WHERE a.Balance > @minBalance
GO
```

1.	Create a function that accepts as parameters – sum, yearly interest rate and number of months.
	*	It should calculate and return the new sum.
	*	Write a `SELECT` to test whether the function works as expected.

```sql
USE BankAccounts
GO

CREATE FUNCTION ufn_CalcInterest(
@sum money,
@interestRate money,
@monthsCount int)
  RETURNS money
AS
BEGIN
  RETURN @sum * @monthsCount * (@interestRate/100)
END
GO

SELECT Balance, dbo.ufn_CalcInterest(Balance, 3.5, 12) AS YearInterest
FROM Accounts
```

1.	Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
	*	It should take the `AccountId` and the interest rate as parameters.

```sql
USE BankAccounts
GO

CREATE PROC dbo.usp_AddMonthlyInterest(
    @accountId int)
AS
    UPDATE Accounts
    SET Balance = Balance + dbo.ufn_CalcInterest(Balance, 3, 1)
    WHERE AccountId = @accountId
GO
```

1.	Add two more stored procedures `WithdrawMoney(AccountId, money)` and `DepositMoney(AccountId, money)` that operate in transactions.

```sql
USE BankAccounts
GO

CREATE PROC dbo.usp_WithdrawMoney(
    @accountId int,
    @money money)
AS
    UPDATE Accounts
    SET Balance = Balance - @money
    WHERE AccountId = @accountId
GO

CREATE PROC dbo.usp_DepositMoney(
    @accountId int,
    @money money)
AS
    UPDATE Accounts
    SET Balance = Balance + @money
    WHERE AccountId = @accountId
GO
```

1.	Create another table – `Logs(LogID, AccountID, OldSum, NewSum)`.
	*	Add a trigger to the `Accounts` table that enters a new entry into the `Logs` table every time the sum on an account changes.

```sql
USE BankAccounts
GO
USE BankAccounts
GO
CREATE TABLE Logs (
    LogId int IDENTITY,
    AccountId int NOT NULL,
    OldSum money,
    NewSum money,
    CONSTRAINT PK_LOGS PRIMARY KEY(LogId),
    CONSTRAINT FK_LOGS_ACCOUNTS
        FOREIGN KEY (AccountId)
        REFERENCES Accounts(AccountId)
)

CREATE TRIGGER tr_AccountsBalanceUpdateLogs ON Accounts FOR UPDATE
AS
    DECLARE @oldBalance money
    SELECT @oldBalance = Balance FROM deleted

    INSERT INTO Logs (AccountId, OldSum, NewSum)
        SELECT AccountId, @oldBalance, Balance
        FROM inserted
GO
```

1.	Define a function in the database `TelerikAcademy` that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
	*	_Example_: '`oistmiahf`' will return '`Sofia`', '`Smith`', … but not '`Rob`' and '`Guy`'.

```sql
USE TelerikAcademy
GO

CREATE FUNCTION ufn_CheckIfWordIsFromSetOfLetters(@word nvarchar(50), @letterSet nvarchar(50)) RETURNS INT
AS
BEGIN
    DECLARE @index INT
    SET @index = LEN(@word)
    DECLARE @letter nvarchar(1)
    SET @letterSet = LOWER(@letterSet)
    DECLARE @result INT = 1

    IF (@index = 0)
    BEGIN
        SET @result = 0
    END

    WHILE (@index >= 1)
    BEGIN
        SET @letter = LOWER(SUBSTRING(@word, @index, 1))
        IF ( CHARINDEX(@letter, @letterSet) <= 0 )
        BEGIN
            SET @result = -5
        END

        SET @index = @index - 1
    END

    RETURN @result
END

GO

SELECT e.FirstName AS Names
FROM Employees e
WHERE dbo.ufn_CheckIfWordIsFromSetOfLetters(e.FirstName, 'redmond') > 0

UNION

SELECT e.LastName
FROM Employees e
WHERE dbo.ufn_CheckIfWordIsFromSetOfLetters(e.LastName, 'redmond') > 0

UNION

SELECT t.Name
FROM Towns t
WHERE dbo.ufn_CheckIfWordIsFromSetOfLetters(t.Name, 'redmond') > 0
```

1.	Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.



1.	*Write a T-SQL script that shows for each town a list of all employees that live in it.
	*	_Sample output_:	
```sql
Sofia -> Martin Kulov, George Denchev
Ottawa -> Jose Saraiva
…
```

1.	Define a .NET aggregate function `StrConcat` that takes as input a sequence of strings and return a single string that consists of the input strings separated by '`,`'.
	*	For example the following SQL statement should return a single string:

```sql
SELECT StrConcat(FirstName + ' ' + LastName)
FROM Employees
```