CREATE TABLE Role
(
    RoleId uuid PRIMARY KEY,
    Name   VARCHAR(255) NOT NULL
);

CREATE TABLE "user"
(
    UserId       uuid PRIMARY KEY,
    Username     VARCHAR(255) NOT NULL,
    FirstName    VARCHAR(255) NOT NULL,
    LastName     VARCHAR(255) NOT NULL,
    Email        VARCHAR(255) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    IsActive     BOOLEAN,
    RoleId       uuid NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Role (RoleId)
);

CREATE TABLE Company
(
    CompanyId    uuid PRIMARY KEY,
    Name         VARCHAR(255) NOT NULL,
    Description  TEXT,
    Address      VARCHAR(255) NOT NULL,
    EmailAddress VARCHAR(255) NOT NULL,
    PhoneNumber  VARCHAR(255) NOT NULL,
    CreationDate timestamp,
    IsActive     BOOLEAN,
    OwnerId      uuid,
    FOREIGN KEY (OwnerId) REFERENCES "user" (UserId)
);

CREATE TABLE Status
(
    StatusId uuid PRIMARY KEY,
    Name     VARCHAR(255) NOT NULL
);

CREATE TABLE JobCategory
(
    CategoryId uuid PRIMARY KEY,
    Name       VARCHAR(255) NOT NULL
);

CREATE TABLE Job
(
    JobId               uuid PRIMARY KEY,
    CompanyId           uuid NOT NULL,
    Name                VARCHAR(255) NOT NULL,
    Description         TEXT NOT NULL,
    CategoryId          uuid NOT NULL,
    Location            VARCHAR(255) NOT NULL,
    StatusId            uuid NOT NULL,
    CreationDate        TIMESTAMP NOT NULL,
    ApplicationDeadline TIMESTAMP,
    IsActive            boolean,
    FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId),
    FOREIGN KEY (CategoryId) REFERENCES JobCategory (CategoryId),
    FOREIGN KEY (StatusId) REFERENCES Status (StatusId)
);

CREATE TABLE Application
(
    ApplicationId   uuid PRIMARY KEY,
    JobId           uuid NOT NULL,
    UserId          uuid NOT NULL,
    StatusId        uuid NOT NULL,
    ApplicationDate DATE NOT NULL,
    FOREIGN KEY (JobId) REFERENCES Job (JobId),
    FOREIGN KEY (UserId) REFERENCES "user" (UserId),
    FOREIGN KEY (StatusId) REFERENCES Status (StatusId)
);
