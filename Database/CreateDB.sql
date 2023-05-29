CREATE TABLE Products (
    ProductId int identity  PRIMARY KEY,
    NameOfProduct nvarchar(255) not null,
    Cost decimal(18,2)
);

CREATE TABLE Storages (
    StorageId int identity  PRIMARY KEY,
    NameOfStoraget nvarchar(255) not null,
    KindOfStorage nvarchar(255) not null
);

CREATE TABLE StatesOfStorages (
    StateOfStorageId int identity,
	ProductId int FOREIGN KEY REFERENCES Products(ProductId),
	StorageId int FOREIGN KEY REFERENCES Storages(StorageId),
	Quantity int
);


select * from Products;
select * from Storages;
select * from StatesOfStorages;


insert into Products
values ('Apple', '7.8');
insert into Products
values ('Banana', '12');
insert into Products
values ('Orange', '8.5');
insert into Products
values ('Brocoli', '10');
insert into Products
values ('Cabbage', '6.9');
insert into Products
values ('Carot', '11');
insert into Products
values ('Cucamber', '11');
insert into Products
values ('Mushrooms', '45');
insert into Products
values ('Onion', '45');
insert into Products
values ('Tomato', '10.5');

insert into Storages
values ('Maxi Fruit', 'Fruit');
insert into Storages
values ('Maxi Vegetable', 'Vegetable');
insert into Storages
values ('Aroma Fruit', 'Fruit');
insert into Storages
values ('Aroma Vegetable', 'Vegetable');
insert into Storages
values ('Univerexport Fruit', 'Fruit');
insert into Storages
values ('Univerexport Vegetable', 'Vegetable');
insert into Storages
values ('Idea Fruit', 'Fruit');
insert into Storages
values ('Idea Vegetable', 'Vegetable');
insert into Storages
values ('Roda Fruit', 'Fruit');
insert into Storages
values ('Roda Vegetable', 'Vegetable');

insert into StatesOfStorages
values (1, 1, 4);
insert into StatesOfStorages
values (2, 3, 7);
insert into StatesOfStorages
values (3, 5, 4);
insert into StatesOfStorages
values (1, 9, 5);
insert into StatesOfStorages
values (2, 7, 8);
insert into StatesOfStorages
values (3, 3, 9);
insert into StatesOfStorages
values (4, 2, 9);
insert into StatesOfStorages
values (4, 8, 8);
insert into StatesOfStorages
values (4, 10, 5);
insert into StatesOfStorages
values (5, 2, 7);
insert into StatesOfStorages
values (5, 4, 3);
insert into StatesOfStorages
values (5, 10, 4);
insert into StatesOfStorages
values (6, 4, 11);
insert into StatesOfStorages
values (6, 6, 8);
insert into StatesOfStorages
values (6, 8, 9);
insert into StatesOfStorages
values (7, 4, 7);
insert into StatesOfStorages
values (7, 6, 4);
insert into StatesOfStorages
values (7, 8, 10);
insert into StatesOfStorages
values (7, 10, 7);
insert into StatesOfStorages
values (8, 2, 7);
insert into StatesOfStorages
values (8, 6, 5);
insert into StatesOfStorages
values (8, 10, 12);
insert into StatesOfStorages
values (9, 4, 14);
insert into StatesOfStorages
values (9, 6, 11);
insert into StatesOfStorages
values (9, 8, 8);
insert into StatesOfStorages
values (10, 2, 12);
insert into StatesOfStorages
values (10, 6, 4);
insert into StatesOfStorages
values (10, 8, 7);
insert into StatesOfStorages
values (10, 10, 11);

