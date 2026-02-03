CREATE TABLE Sales_Raw(
    OrderID INT,
    OrderDate VARCHAR(20),
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50),
    ProductNames VARCHAR(200),   -- Multiple products comma-separated
    Quantities VARCHAR(100),     -- Multiple quantities comma-separated 
    UnitPrices VARCHAR(100),     -- Multiple prices comma-separated
    SalesPerson VARCHAR(100)
);

INSERT INTO Sales_Raw VALUES
(101, '2024-01-05', 'Ravi Kumar', '9876543210', 'Chennai', 'Laptop,Mouse', '1,2', '55000,500', 'Anitha'),
(102, '2024-01-06', 'Priya Sharma', '9123456789', 'Bangalore', 'Keyboard,Mouse', '1,1', '1500,500', 'Anitha'),
(103, '2024-01-10', 'Ravi Kumar', '9876543210', 'Chennai', 'Laptop', '1', '54000', 'Suresh'),
(104, '2024-02-01', 'John Peter', '9988776655', 'Hyderabad', 'Monitor,Mouse', '1,1', '12000,500', 'Anitha'),
(105, '2024-02-10', 'Priya Sharma', '9123456789', 'Bangalore', 'Laptop,Keyboard', '1,1', '56000,1500', 'Suresh');


-- Q1. Normalized tables for sales database
CREATE TABLE CustomerMaster (
	CustomerID INT IDENTITY PRIMARY KEY,
	CustomerName NVARCHAR(20) NOT NULL,
	Phone NVARCHAR(10),
	City NVARCHAR(20)
);

CREATE TABLE SalesPersonMaster (
	SalesPersonID INT IDENTITY PRIMARY KEY,
	SalesPersonName NVARCHAR(20) NOT NULL,
);

CREATE TABLE ProductMaster (
	ProductID INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR(50) NOT NULL
);

CREATE TABLE CustomerOrderMaster (
	OrderID INT PRIMARY KEY,
	CustomerID INT,
	SalesPersonID INT,
	OrderDate DATETIME NOT NULL,
	FOREIGN KEY (CustomerID) REFERENCES CustomerMaster(CustomerID),
	FOREIGN KEY (SalesPersonID) REFERENCES SalesPersonMaster(SalesPersonID)
);

CREATE TABLE OrderDetails (
	OrderDetailID INT IDENTITY PRIMARY KEY,
	OrderID INT,
	ProductID INT,
	Quantity INT NOT NULL,
	UnitPrice INT NOT NULL,
	FOREIGN KEY (OrderID) REFERENCES CustomerOrderMaster(OrderID),
	FOREIGN KEY (ProductID) REFERENCES ProductMaster(ProductID)
);

INSERT INTO CustomerMaster (CustomerName, Phone, City)
VALUES
('Ravi Kumar', '9876543210', 'Chennai'),
('Priya Sharma', '9123456789', 'Bangalore'),
('John Peter', '9988776655', 'Hyderabad');


INSERT INTO SalesPersonMaster(SalesPersonName)
VALUES
('Anitha'),
('Suresh');

INSERT INTO ProductMaster(ProductName)
VALUES
('Laptop'),
('Mouse'),
('Keyboard'),
('Monitor');

INSERT INTO CustomerOrderMaster(OrderID, OrderDate, CustomerID, SalesPersonID)
VALUES
(101, '2024-01-05', 1, 1),
(102, '2024-01-06', 2, 1),
(103, '2024-01-10', 1, 2),
(104, '2024-02-01', 3, 1),
(105, '2024-02-10', 2, 2),
(107, '2026-01-15', 3, 2),
(108, '2026-01-26', 1, 1);

INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
VALUES
-- Order 101
(101, 1, 1, 55000),
(101, 2, 2, 500),

-- Order 102
(102, 3, 1, 1500),
(102, 2, 1, 500),

-- Order 103
(103, 1, 1, 54000),

-- Order 104
(104, 4, 1, 12000),
(104, 2, 1, 500),

-- Order 105
(105, 1, 1, 56000),
(105, 3, 1, 1500),

-- Order 107
(107, 2, 3, 500),
(107, 4, 1, 12500),
(107, 1, 1, 57000),

-- Order 108
(108, 3, 2, 1500),
(108, 2, 1, 500);

-- Q2. Query to find the third highest total sales from OrderDetails
SELECT OrderID, TotalSales
FROM
(
    SELECT
        OrderID,
        SUM(Quantity * UnitPrice) AS TotalSales
    FROM OrderDetails
    GROUP BY OrderID
) t
ORDER BY TotalSales DESC
OFFSET 2 ROWS FETCH NEXT 1 ROW ONLY;

-- Q3. Query to find the total sales by each salesperson where total sales are greater than 60000
SELECT
    sp.SalesPersonName,
    SUM(od.Quantity * od.UnitPrice) AS TotalSales
FROM SalesPersonMaster sp
JOIN CustomerOrderMaster o
    ON sp.SalesPersonID = o.SalesPersonID
JOIN OrderDetails od
    ON o.OrderID = od.OrderID
GROUP BY sp.SalesPersonName
HAVING SUM(od.Quantity * od.UnitPrice) > 60000;

-- Q4. Query to find customers whose total spending exceeds the average customer spending
SELECT
    c.CustomerName,
    SUM(od.Quantity * od.UnitPrice) AS TotalSpent
FROM CustomerMaster c
JOIN CustomerOrderMaster o
    ON c.CustomerID = o.CustomerID
JOIN OrderDetails od
    ON o.OrderID = od.OrderID
GROUP BY c.CustomerName
HAVING SUM(od.Quantity * od.UnitPrice) >
(
    SELECT AVG(CustomerTotal)
    FROM
    (
        SELECT
            SUM(od2.Quantity * od2.UnitPrice) AS CustomerTotal
        FROM CustomerOrderMaster o2
        JOIN OrderDetails od2
            ON o2.OrderID = od2.OrderID
        GROUP BY o2.CustomerID
    ) avg_table
);

-- Q5. Query to display the customer names in uppercase along with the month number and order date for all orders placed in January 2026.
SELECT
    UPPER(c.CustomerName) AS CustomerName,
    MONTH(o.OrderDate) AS OrderMonth,
    o.OrderDate
FROM CustomerMaster c
JOIN CustomerOrderMaster o
    ON c.CustomerID = o.CustomerID
WHERE
    YEAR(o.OrderDate) = 2026
    AND MONTH(o.OrderDate) = 1;
