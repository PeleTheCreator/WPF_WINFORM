CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    name VARCHAR(50),
    email VARCHAR(100),
    country VARCHAR(50)
);

INSERT INTO customers (customer_id, name, email, country) VALUES
(1, 'Alice', 'alice@email.com', 'USA'),
(2, 'Bob', 'bob@email.com', 'Canada'),
(3, 'Charlie', 'charlie@email.com', 'USA'),
(4, 'Diana', 'diana@email.com', 'UK'),
(5, 'Ethan', 'ethan@email.com', 'USA');


CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);


CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    price DECIMAL(10,2),
    category_id INT,
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO products (product_id, product_name, price, category_id) VALUES
(1, 'Laptop', 1000, 1),
(2, 'Keyboard', 50, 3),
(3, 'Mouse', 25, 3),
(4, 'Office Chair', 120, 2),
(5, 'Desk', 200, 2);


CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);



INSERT INTO orders (order_id, customer_id, order_date) VALUES
(101, 1, '2024-01-10'),
(102, 2, '2024-01-12'),
(103, 1, '2024-02-05'),
(104, 3, '2024-02-08'),
(105, 5, '2024-02-14');


CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);


INSERT INTO order_items (order_item_id, order_id, product_id, quantity) VALUES
(1, 101, 1, 1),   -- Laptop
(2, 101, 2, 2),   -- Keyboard
(3, 102, 4, 1),   -- Office Chair
(4, 103, 5, 1),   -- Desk
(5, 104, 2, 3),   -- Keyboard
(6, 105, 3, 2);   -- Mouse



CREATE TABLE payments (
    payment_id INT PRIMARY KEY,
    order_id INT,
    amount DECIMAL(10,2),
    status VARCHAR(20),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

INSERT INTO payments (payment_id, order_id, amount, status) VALUES
(900, 101, 1100, 'Paid'),
(901, 102, 120, 'Paid'),
(902, 103, 200, 'Pending'),
(903, 104, 150, 'Paid'),
(904, 105, 50, 'Paid');
