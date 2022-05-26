USE db_RestAspNETUdemy

CREATE TABLE Person
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Address varchar(100) not null,
	First_Name varchar(100) not null,
	Last_Name varchar(100) not null,
	Gender varchar(6) not null
)

SELECT * FROM Person

INSERT INTO Person VALUES ('Araçariguama', 'Benício', 'Finardi', 'Male')

