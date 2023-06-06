select * from dbo.Product;
select * from dbo.Storage;
select * from dbo.StateOfStorage;
select NameOfProduct from dbo.Product;
select NameOfStorage from dbo.Storage;
select NameOfProduct, Cost from dbo.Product;
select NameOfStorage, KindOfStorage from dbo.Storage;
select * from dbo.Product where Cost>10;
select * from dbo.Product where Cost>10 and Cost<30;
select * from dbo.Storage where KindOfStorage='Fruit';

select s.StorageId, s.NameOfStorage, s.KindOfStorage, p.ProductId, p.NameOfProduct, p.Cost, ss.Quantity
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId;

select s.NameOfStorage, p.NameOfProduct, p.Cost, ss.Quantity
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId;

select s.NameOfStorage, p.NameOfProduct, p.Cost, ss.Quantity
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where NameOfStorage='Aroma Fruit';

select s.NameOfStorage, p.NameOfProduct, p.Cost, ss.Quantity, (p.Cost * ss.Quantity) as ValueOfProduct
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId;

select s.NameOfStorage, sum (p.Cost * ss.Quantity) as TotalCost
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where s.NameOfStorage='Aroma Fruit'
group by s.NameOfStorage;

select s.NameOfStorage, avg (p.Cost * ss.Quantity) as AverageValue
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where s.NameOfStorage='Aroma Fruit'
group by s.NameOfStorage;

select s.NameOfStorage, min (p.Cost * ss.Quantity) as MinValue
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where s.NameOfStorage='Aroma Fruit'
group by s.NameOfStorage;

select s.NameOfStorage, max (p.Cost * ss.Quantity) as MaxValue
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where s.NameOfStorage='Aroma Fruit'
group by s.NameOfStorage;

select s.NameOfStorage, p.NameOfProduct, p.Cost, ss.Quantity
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where NameOfStorage='Aroma Vegetable'
order by ss.Quantity;

select s.NameOfStorage, p.NameOfProduct, p.Cost, ss.Quantity
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where NameOfStorage='Aroma Vegetable'
order by ss.Quantity desc;

select count(NameOfProduct) as Count from dbo.Product where NameOfProduct='Apple';
select count(NameOfProduct) as Count from dbo.Product where Cost>10 and Cost<30;

select sum(ss.Quantity) as Fruit
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where KindOfStorage='Fruit';

select sum(ss.Quantity) as Vegetable
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where KindOfStorage='Vegetable';

select sum(p.Cost * ss.Quantity) as TotalCostOfFruit
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where KindOfStorage='Fruit';

select sum(p.Cost * ss.Quantity) as TotalCostOfVegetable
from dbo.Product p inner join dbo.StateOfStorage ss on p.ProductId=ss.ProductId
inner join dbo.Storage s on s.StorageId=ss.StorageId
where KindOfStorage='Vegetable';





