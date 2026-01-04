-- LEFT JOIN

--1. Find all customers with OR without orders
SELECT c.customer_id,c.name, o.order_id, o.order_date from [dbo].[customers] c
left join [dbo].[orders] o on c.customer_id = o.customer_id;

--2 Find customers who have no orders (very common interview question)
select c.customer_id,c.name, o.order_id, o.order_date from [dbo].[customers] c
left join [dbo].[orders] o on c.customer_id = o.customer_id where o.order_id is NULL; 

--3 Count orders per customer (including zero)
select c.name, count(o.order_id) as totalorder from [dbo].[customers] c
left join [dbo].[orders] o on c.customer_id = o.customer_id group by c.name

--exercises:

--List all customers and total number of orders they made

--Show every order and all the items included in it

--Find customers who bought Electronics products

--Find customers who never bought Accessories products


