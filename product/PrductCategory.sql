INSERT INTO Categories (Name, IsActive)
VALUES ('Electronics', 1);

INSERT INTO Categories (Name, IsActive)
VALUES ('Books', 1);

INSERT INTO Categories (Name, IsActive)
VALUES ('Clothing', 1);


INSERT INTO Products (Name, IsActive, CategoryId)
VALUES ('iPhone', 1, 1);

INSERT INTO Products (Name, IsActive, CategoryId)
VALUES ('Laptop', 1, 1);

INSERT INTO Products (Name, IsActive, CategoryId)
VALUES ('C# Programming Book', 1, 2);

INSERT INTO Products (Name, IsActive, CategoryId)
VALUES ('T-Shirt', 1, 3);

Select * from Products;
select * from Categories;