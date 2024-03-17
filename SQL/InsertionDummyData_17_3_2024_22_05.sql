-- Role tablica
INSERT INTO Role (RoleId, Name) VALUES
('1f6b5b1a-86db-4f60-b659-1e31f5ae6c22', 'Admin'),
('2d7f88b6-9a22-45ac-9149-4236c8c29c98', 'Employee');

-- "user" tablica
INSERT INTO "user" (UserId, Username, FirstName, LastName, Email, PasswordHash, IsActive, RoleId) VALUES
('d6d7df5f-d4c8-42e5-9c1d-f5b1a047af2b', 'john_doe', 'John', 'Doe', 'john@example.com', 'hashedpassword', true, '1f6b5b1a-86db-4f60-b659-1e31f5ae6c22'),
('f482d376-3f27-4924-a05b-dfc7d94f4903', 'jane_smith', 'Jane', 'Smith', 'jane@example.com', 'hashedpassword', true, '2d7f88b6-9a22-45ac-9149-4236c8c29c98');

-- Company tablica
INSERT INTO Company (CompanyId, Name, Description, Address, EmailAddress, PhoneNumber, CreationDate, IsActive, OwnerId) VALUES
('a058636e-6f79-4f17-8e5c-df0897e44551', 'Acme Corp', 'Lorem ipsum dolor sit amet.', '123 Main St', 'info@acme.com', '123-456-7890', NOW(), true, 'd6d7df5f-d4c8-42e5-9c1d-f5b1a047af2b'),
('e15f6f4a-c135-4b6b-a8b0-9c5d088c5f4f', 'Tech Solutions LLC', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.', '456 Elm St', 'info@techsolutions.com', '555-555-5555', NOW(), true, 'f482d376-3f27-4924-a05b-dfc7d94f4903');

-- Status tablica
INSERT INTO Status (StatusId, Name) VALUES
('b362dbf1-4fd9-4c2d-b5c4-3fb5606e1b5b', 'Pending'),
('1c2fb2f4-8c8e-4620-bff5-bb0f77da142d', 'Approved'),
('343a4884-91db-4955-a205-1014ab72a31f', 'Rejected');

-- JobCategory tablica
INSERT INTO JobCategory (CategoryId, Name) VALUES
('f47d79d2-9b85-4d1a-ba6f-8ec4e172b1bc', 'Software Development'),
('c4a6e015-f8d1-4c8e-bfd0-78c8a6864c2c', 'Marketing');

-- Job tablica
INSERT INTO Job (JobId, CompanyId, Name, Description, CategoryId, Location, StatusId, CreationDate, ApplicationDeadline, IsActive) VALUES
('64e81c7d-0a25-4094-9484-1ef5a87e3620', 'a058636e-6f79-4f17-8e5c-df0897e44551', 'Software Engineer', 'Lorem ipsum dolor sit amet.', 'f47d79d2-9b85-4d1a-ba6f-8ec4e172b1bc', 'New York', 'b362dbf1-4fd9-4c2d-b5c4-3fb5606e1b5b', NOW(), NOW() + INTERVAL '30 days', true),
('efad25df-1287-4e3e-9019-6832242aa0b4', 'e15f6f4a-c135-4b6b-a8b0-9c5d088c5f4f', 'Marketing Specialist', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.', 'c4a6e015-f8d1-4c8e-bfd0-78c8a6864c2c', 'Los Angeles', 'b362dbf1-4fd9-4c2d-b5c4-3fb5606e1b5b', NOW(), NOW() + INTERVAL '45 days', true);

-- Application tablica
INSERT INTO Application (ApplicationId, JobId, UserId, StatusId, ApplicationDate) VALUES
('33f3f458-7c11-47cf-bb39-62ee2cf1cb6b', '64e81c7d-0a25-4094-9484-1ef5a87e3620', 'f482d376-3f27-4924-a05b-dfc7d94f4903', 'b362dbf1-4fd9-4c2d-b5c4-3fb5606e1b5b', NOW());
