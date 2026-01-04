

--##SELECT
select 'name'
select * from [sales].[customers]
select * from sales.customers where state = 'CA'
select * from sales.customers where state = 'CA' order by first_name 
select * from sales.customers where state = 'CA' order by first_name desc
select * from sales.customers where state = 'CA' order by first_name asc
select  city, count(*) from sales.customers  where state = 'CA' group by city order by city desc;
select  city, count(phone) from sales.customers  where state = 'CA' group by city;
select  city, count(*) from sales.customers  where state = 'CA' group by city order by city ;
select city, count(*) from sales.customers where state = 'CA' group by city having count(*) > 10 order by city

--##ORDER BY
select first_name, last_name from sales.customers order by first_name
select first_name, last_name from sales.customers order by first_name asc
select first_name, last_name from sales.customers order by first_name desc
select city,first_name, last_name from sales.customers order by city,first_name 
select city,first_name, last_name from sales.customers order by city desc ,first_name desc 
select city,first_name, last_name from sales.customers order by state
select city,first_name, last_name from sales.customers order by len(first_name) 
select * from sales.customers order by 2

--##OFFSET FETCH
select product_name, list_price from production.products order by list_price, product_name;
select product_name, list_price from production.products order by list_price, product_name offset 5 rows fetch next 5 rows only;
select product_name, list_price from production.products order by list_price, product_name offset 5 row fetch next 2 rows only
select product_name, list_price from production.products order by list_price desc, product_name offset 0 row fetch next 10 rows only

--##SELECT TOP
select top 10 product_name, list_price from production.products order by list_price desc
select top 1 percent product_name, list_price from production.products order by list_price desc
select top 3 product_name, list_price from production.products order by list_price desc
select top 3 with ties product_name, list_price from production.products order by list_price desc
select * from production.products order by list_price desc offset 2 row fetch next 3 row only

--##DISTINCT
select city from sales.customers order by city;
select distinct city from sales.customers order by city;
select city,state from sales.customers order by city, state;
select distinct city , state from sales.customers order by city, state;
select city , state, count(city) from sales.customers group by city, state order by city, state;

--##WHERE
select product_id, product_name, category_id, model_year, list_price from production.products 
select product_id, product_name, category_id, model_year, list_price from production.products where category_id = 1 
select product_id, product_name, category_id, model_year, list_price from production.products where category_id = 1 and model_year = '2016'
select product_id, product_name, category_id, model_year, list_price from production.products where list_price < 300 and model_year = '2016'
select product_id, product_name, category_id, model_year, list_price from production.products where category_id = 1 or model_year = '2016'
select product_id, product_name, category_id, model_year, list_price from production.products where list_price between 300 and 320
select product_id, product_name, category_id, model_year, list_price from production.products where list_price IN (299.99, 369.99, 489.99)
select product_id, product_name, category_id, model_year, list_price from production.products where product_name like '%Cruiser%'

--#NULL
select customer_id, first_name, last_name, phone from sales.customers where phone = null
select customer_id, first_name, last_name, phone from sales.customers where phone is null
select customer_id, first_name, last_name, phone from sales.customers where phone is not null

--#AND - OR
select product_id, product_name, brand_id, category_id, model_year, list_price from production.products where (brand_id = 1 or brand_id = 2) and  list_price > 1000 order by brand_id desc
select product_id, product_name, brand_id, category_id, model_year, list_price from production.products where brand_id in (1,2) and  list_price > 1000 order by brand_id desc

--##IN
select product_id, product_name, brand_id, category_id, model_year, list_price from production.products where list_price in (999.99, 749.99)
select product_id, product_name, brand_id, category_id, model_year, list_price from production.products where list_price not in (999.99, 749.99)

select product_id, product_name, brand_id, category_id, model_year, list_price from production.products where product_id in (select product_id from production.stocks where store_id = 1 and quantity >= 30)

--##BETWEEN
select product_id, product_name, brand_id, category_id, model_year, list_price from production.products where list_price between 149.99 and 199.99
select product_id, product_name, brand_id, category_id, model_year, list_price from production.products where list_price not between 149.99 and 199.99
SELECT order_id,customer_id,order_date, order_status FROM sales.orders where order_date between '20170115' and '20170117'



--##LIKE

--##ALIAS
select product_id as pid, product_name, brand_id, category_id, model_year, list_price from production.products 
select product_id  pid, product_name, brand_id, category_id, model_year, list_price from production.products 
select p.product_id, product_name, brand_id, category_id, model_year, list_price from production.products as p
select production.products.product_id, product_name, brand_id, category_id, model_year, list_price from production.products 

select product_id as pid, product_name, brand_id, category_id, model_year, list_price from production.products order by pid

--##JOINS
--CREATE SCHEMA hr;

CREATE TABLE hr.candidates(
    id INT PRIMARY KEY IDENTITY,
    fullname VARCHAR(100) NOT NULL
);

CREATE TABLE hr.employees(
    id INT PRIMARY KEY IDENTITY,
    fullname VARCHAR(100) NOT NULL
);

INSERT INTO 
    hr.candidates(fullname)
VALUES
    ('John Doe'),
    ('Lily Bush'),
    ('Peter Drucker'),
    ('Jane Doe');


INSERT INTO 
    hr.employees(fullname)
VALUES
    ('John Doe'),
    ('Jane Doe'),
    ('Michael Scott'),
    ('Jack Sparrow');

select c.id candidateId, c.fullname candidatename, e.id employeeId, e.fullname employeename from hr.candidates c inner join hr.employees e on c.fullname = e.fullname
select c.id candidateId, c.fullname candidatename, e.id employeeId, e.fullname employeename from hr.candidates c left join hr.employees e on c.fullname = e.fullname
select c.id candidateId, c.fullname candidatename, e.id employeeId, e.fullname employeename from hr.candidates c left join hr.employees e on c.fullname = e.fullname
select c.id candidateId, c.fullname candidatename, e.id employeeId, e.fullname employeename from hr.candidates c right join hr.employees e on c.fullname = e.fullname
select c.id candidateId, c.fullname candidatename, e.id employeeId, e.fullname employeename from hr.candidates c full join hr.employees e on c.fullname = e.fullname

--##CROSS JOIN
select product_id, product_name,store_id, 0 as quantity from
production.products CROSS JOIN sales.stores order by product_name,
store_id

--SELF JOIN
select s.last_name staffname, m.last_name managername from sales.staffs s inner join sales.staffs m on s.staff_id = m.manager_id order by managername

select s.last_name staffname, m.last_name managername from sales.staffs s left join sales.staffs m on s.staff_id = m.manager_id  where m.last_name is null order by managername


select * from sales.customers
select  c1.city, c1.last_name, c2.last_name from sales.customers c1 inner join sales.customers c2 on c1.customer_id > c2.customer_id and c1.city = c2.city order by city


--##Group By
select  * from sales.orders
select  customer_id, year(order_date) from sales.orders where customer_id in (1,2) group by customer_id, year(order_date)
select distinct customer_id, year(order_date) from sales.orders where customer_id in (1,2)
select  customer_id, year(order_date), count(order_id) from sales.orders where customer_id in (1,2) group by customer_id, year(order_date)
select city, count(customer_id) from sales.customers group by city order by city
select city, state, count(customer_id) from sales.customers group by city, state order by city, state

--minimum and maximum list prices of all products with the model 2018 by brand:
select * from  production.products p
select * from production.products p inner join production.brands b on  p.brand_id = b.brand_id
select * from production.products p inner join production.brands b on  p.brand_id = b.brand_id where model_year = 2018 order by product_name

select brand_name, min(list_price) minprice, max(list_price) maxprice, avg(list_price) averageprice, sum(list_price) sumoftheproducts from production.products p inner join production.brands b on  p.brand_id = b.brand_id where model_year = 2018 group by brand_name order by brand_name

--## Having
select brand_name, min(list_price) minprice, max(list_price) maxprice, avg(list_price) averageprice, sum(list_price) sumoftheproducts from production.products p inner join production.brands b on  p.brand_id = b.brand_id where model_year = 2018 group by brand_name having max(list_price) <= 300 order by brand_name


select * from [production].[products]

--## GroupSET
Create Table sales.sales_summary(
  brand varchar(255) not null,
  category varchar(255) not null,
  model_year smallint not null,
  sales decimal(10, 2) not null
);

SELECT
    b.brand_name AS brand,
    c.category_name AS category,
    p.model_year,
    round(
        SUM (
            quantity * i.list_price * (1 - discount)
        ),
        0
    ) sales INTO sales.sales_summary
FROM
    sales.order_items i
INNER JOIN production.products p ON p.product_id = i.product_id
INNER JOIN production.brands b ON b.brand_id = p.brand_id
INNER JOIN production.categories c ON c.category_id = p.category_id
GROUP BY
    b.brand_name,
    c.category_name,
    p.model_year
ORDER BY
    b.brand_name,
    c.category_name,
    p.model_year;

    select * from [sales].[sales_summary] order by brand, category, model_year
    
    select brand, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by brand, category order by  brand, category;

    select brand, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by brand order by  brand

    select category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by category order by  category
    select count(*) totalnumber, sum(sales) salaes from sales.sales_summary



select brand, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by brand, category 
union all
select brand, null, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by brand 
union all
select null, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by category 
union all
select null, null, count(*) totalnumber, sum(sales) salaes from sales.sales_summary


select brand, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by grouping sets
(
 (brand, category),
 (brand),
 (category),
 ()
)
order by brand, category desc

--## CUBE - generate 2^N groupset
select brand, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by cube(brand, category)
order by brand, category 

select brand, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by brand, cube(category)
order by brand, category 


--#ROLL UP
select brand, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by rollup(brand, category)
order by brand, category desc

select brand, category, count(*) totalnumber, sum(sales) salaes from sales.sales_summary group by brand, rollup(category)
order by brand, category desc


--##INSERT
create table sales.promotions
(
 promotion_id int identity(1,1) primary key,
 promotion_name varchar(255) not null,
 discount numeric(3,2) default 0,
 start_date date not null,
 expired_date date not null
);

select * from   sales.promotions;

insert sales.promotions(promotion_name, discount, start_date, expired_date ) 
values('2018 Summer Promotion', 0.15, '20180601', '20180901');

SET IDENTITY_INSERT sales.promotions ON;

insert sales.promotions(promotion_id,promotion_name, discount, start_date, expired_date )
values(10, '2018 Fall Promotion', 0.15, '20181001', '20181101');
SET IDENTITY_INSERT sales.promotions OFF;


insert sales.promotions(promotion_name, discount, start_date, expired_date ) output inserted.promotion_id
values('2020 Fall Promotion', 0.15, '20201001', '20201101');


insert into sales.promotions(promotion_name, discount, start_date, expired_date)
output inserted.promotion_id,
inserted.promotion_name,
inserted.discount,
inserted.start_date,
inserted.expired_Date
values
(
    '2018 Winter Promotion',
     0.2,
    '20181201',
    '20190101'
);


insert into sales.promotions
(
 promotion_name,
 discount,
 start_date,
 expired_date
) output inserted.promotion_id
values
 (
        '2019 Summer Promotion',
        0.15,
        '20190601',
        '20190901'
    ),
    (
        '2019 Fall Promotion',
        0.20,
        '20191001',
        '20191101'
    ),
    (
        '2019 Winter Promotion',
        0.25,
        '20191201',
        '20200101'
    );

--##INSERT INTO
create table sales.addresses
(
   address_id int identity primary key,
   street varchar (255) not null,
   city varchar(50),
   state varchar(25),
   zip_code  varchar(5)
);

insert into sales.addresses(street, city, state, zip_code)
select street, city, state, zip_code from sales.customers order by first_name, last_name

insert into sales.addresses(street, city, state, zip_code)
select street, city, state, zip_code from sales.stores  where city in ('Santa Cruz', 'Baldwin')

TRUNCATE TABLE sales.addresses;

select * from sales.addresses

insert into sales.addresses(street, city, state, zip_code)
select top(10) street, city, state, zip_code  from sales.customers
--vs
insert top(10) into sales.addresses(street, city, state, zip_code)
select  street, city, state, zip_code  from sales.customers


insert top(10) percent into sales.addresses(street, city, state, zip_code)
select  street, city, state, zip_code  from sales.customers


--##Update
create table sales.taxes
(
 tax_id int identity(1,1) primary key,
 state varchar(50) not null unique,
 state_tax_rate dec(3,2),
 avg_local_tax_rate dec(3,2),
 combined_rate as state_tax_rate + avg_local_tax_rate,
 max_local_tax_rate dec(3,2),
 updated_at datetime
);


update sales.taxes
set updated_at = getdate();

select * from sales.taxes


update sales.taxes 
set max_local_tax_rate += 0.02,
    avg_local_tax_rate += 0.01
where max_local_tax_rate = 0.01

select * from sales.taxes where max_local_tax_rate = 0.03

--##UPDATEJOIN
begin
    drop table if exists sales.targets;

    create table sales.targets(
        target_id int primary key,
        percentage decimal(4,2) not null default 0
    );

    INSERT INTO 
        sales.targets(target_id, percentage)
    VALUES
        (1,0.2),
        (2,0.3),
        (3,0.5),
        (4,0.6),
        (5,0.8);

    create table sales.commissions
    (
        staff_id int primary key,
        target_id int,
        base_amount dec(10,2) not null default 0,
        commission dec(10, 2) not null default 0,
        foreign key(target_id) references sales.targets(target_id),
        foreign key(staff_id) references sales.staffs(staff_id)
    );

    INSERT INTO 
        sales.commissions(staff_id, base_amount, target_id)
    VALUES
        (1,100000,2),
        (2,120000,1),
        (3,80000,3),
        (4,900000,4),
        (5,950000,5);

    select * from sales.commissions c inner join sales.targets t on c.target_id = t.target_id;
    -- update inner join
    update sales.commissions 
    set sales.commissions.commission = c.base_amount * t.percentage
    from sales.commissions c inner join sales.targets t on c.target_id = t.target_id;

    --update left join
    insert into sales.commissions(staff_id, base_amount, target_id)
    values (6,100000,NULL), (7,120000,NULL);

    select * from sales.commissions c left join sales.targets t on c.target_id = t.target_id;


    update sales.commissions 
    set sales.commissions.commission = c.base_amount * coalesce(t.percentage, 0.1)
    from sales.commissions c left join sales.targets t on c.target_id = t.target_id;
end

--## DELETE
begin
  select * from production.products
  select * into production.history from production.products --create new table
   select * from production.history
   delete top(21) from production.history
   delete top(5) percent from production.history
    delete from production.history where model_year = 2017
    delete from production.history 
    --vs
    truncate table production.history 
end


--## MERGE
begin 
--MERGE target_table USING source_table
--ON merge_condition
--WHEN MATCHED
--    THEN update_statement
--WHEN NOT MATCHED
--    THEN insert_statement
--WHEN NOT MATCHED BY SOURCE
--    THEN DELETE;

CREATE TABLE sales.category (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(255) NOT NULL,
    amount DECIMAL(10 , 2 )
);

INSERT INTO sales.category(category_id, category_name, amount)
VALUES(1,'Children Bicycles',15000),
    (2,'Comfort Bicycles',25000),
    (3,'Cruisers Bicycles',13000),
    (4,'Cyclocross Bicycles',10000);


CREATE TABLE sales.category_staging (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(255) NOT NULL,
    amount DECIMAL(10 , 2 )
);


INSERT INTO sales.category_staging(category_id, category_name, amount)
VALUES(1,'Children Bicycles',15000),
    (3,'Cruisers Bicycles',13000),
    (4,'Cyclocross Bicycles',20000),
    (5,'Electric Bikes',10000),
    (6,'Mountain Bikes',10000);

merge sales.category t
      using sales.category_staging s
      on t.category_id = s.category_id
when matched
     then update set
          t.category_name = s.category_name,
          t.amount = s.amount
when not matched by target
      then insert(category_id,category_name,amount)
           values(s.category_id,s.category_name,s.amount)
when not matched by source
      then delete;

select * from sales.category_staging
select * from sales.category
end

--## Transaction
begin
create table invoice
(
  id int identity primary key,
  customer_id int not null,
  total dec(10,2) not null default 0 check (total >= 0)
);

create table invoice_items
(
 id int,
 inovice_id int not null,
 item_name varchar(100) not null,
 amount dec(10,2),
 tax dec(4,2) not null check(tax>=0),
 primary key (id,inovice_id)
);

declare @invoice table
(
 id int
);
declare @invoice_id int;

insert into invoice(customer_id, total)
output inserted.id into @invoice
values (100, 0);
 
select @invoice_id = id from @invoice;

select @invoice_id;

insert into invoice_items (id, invoice_id, item_name, amount, tax)
values (10, @invoice_id, 'Keyboard', 70, 0.08),
       (20, @invoice_id, 'Mouse', 50, 0.08);

update invoices
set total = (
    select * from invoice_items where inovice_id = @invoice_id;
)

end