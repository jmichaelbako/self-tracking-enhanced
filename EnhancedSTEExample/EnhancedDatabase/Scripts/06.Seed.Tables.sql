SET IDENTITY_INSERT Category ON

INSERT INTO Category (CategoryID, CategoryName, CategoryDesc)
SELECT 1, 'Sports', 'Sports goods and apparel' UNION
SELECT 2, 'Clothing', 'Otherwise you would be naked' UNION
SELECT 3, 'Shoes', 'They keep your feet safe' UNION
SELECT 4, 'Accessories', 'Because clothes aren''t enough'

SET IDENTITY_INSERT Category OFF

SET IDENTITY_INSERT Product ON

INSERT INTO Product (ProductID, SKU, ProductName, ProductDesc)
SELECT 1, '19A810K', 'Soccer Jersey', 'A very nice jersey' UNION
SELECT 2, '15809AJ', 'Soccer Shoes', 'Some shoes to go with a jersey' UNION
SELECT 3, 'AG8900F', 'Soccer Shorts', 'Would be quite embarassing to play without' UNION
SELECT 4, '109LKAJ', 'Soccer Socks', 'To keep your feet comfortable' UNION
SELECT 5, '299ASDF', 'Soccer Shinguards', 'Protecting your shins is obviously more important than protecting your head'

SET IDENTITY_INSERT Product OFF

INSERT INTO ProductCategory (ProductID, CategoryID)
SELECT 1, 1 UNION
SELECT 1, 2 UNION
SELECT 2, 1 UNION
SELECT 2, 3 UNION
SELECT 3, 1 UNION
SELECT 3, 2 UNION
SELECT 4, 1 UNION
SELECT 4, 2 UNION
SELECT 5, 1 UNION
SELECT 5, 4
