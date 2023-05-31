CREATE TABLE dbo.Product (
    ProductId int identity  PRIMARY KEY,
    NameOfProduct nvarchar(255) not null,
    Cost decimal(18,2)
);

CREATE TABLE dbo.Storage (
    StorageId int identity  PRIMARY KEY,
    NameOfStorage nvarchar(255) not null,
    KindOfStorage nvarchar(255) not null
);

CREATE TABLE dbo.StateOfStorage (
    StateOfStorageId int identity,
	ProductId int FOREIGN KEY REFERENCES Product(ProductId),
	StorageId int FOREIGN KEY REFERENCES Storage(StorageId),
	Quantity int
);