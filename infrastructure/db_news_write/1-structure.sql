DROP DATABASE IF EXISTS bn;

CREATE DATABASE bn;

\connect bn;

CREATE TABLE "News" (
    "Id" bigserial PRIMARY KEY,
    "Title" varchar(200) NOT NULL,
    "Description" varchar(1000) NOT NULL,
    "Timestamp" timestamp NOT NULL,
    "Author" varchar(200) NULL
);