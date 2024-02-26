CREATE TABLE Artist(
		ID INT  IDENTITY(1,1) PRIMARY KEY,
		FirstName varchar(20),
		LastName varchar(20),
		BirthDate date,
		DeathDate date default Null,
		Commission int,
		Street varchar(max),
		City varchar(20),
		StateAb varchar(5),
		StateID int ,
		ZipCode varchar(20),

		foreign key(StateID) references State
);



CREATE TABLE ArtWork(
		ID int,
		ArtID int IDENTITY(1,1) PRIMARY KEY,
		Title varchar(30),
		CreationDate Date,
		AcquisitionDate Date,
		Price bigint,
		Form varchar(20)

		FOREIGN KEY(ID)  REFERENCES Artist
);

CREATE TABLE State(
		StateID int identity(1,1) PRIMARY key,
		StateAb varchar(5),
		StateName varchar(30)

);



INSERT INTO State values('TX','Texas');

INSERT INTO State values('OK','Oklahoma'),('NM','New Mexico'),('LA','Louisiana'),('KS','kansas');


select * from Artist;

INSERT INTO Artist values('Abed','Abdi','01-jan-00',NULL,10,'309 Hcounty Road','Abbott','TX',1,'76621-0057');

INSERT INTO Artist values('Ismail','Gulg','03-jan-90',NULL,11,'405 E Mesquite Street','Abbott','TX',1,'76621-0057');

INSERT INTO Artist values('Shakir','Ali','04-feb-95',NULL,12,'5000 Spectrum Street','Addison','TX',1,'75001-6880'), ('Abdur','Rahman','05-feb-70',NULL,10,'1000 Country Road','Bradley','OK',2,'73011-0121');

INSERT INTO Artist values('Tatsuo','Miyajima','07-Jul-99',NULL,11,'Bella Ranch Drive','Choctaw','OK',2,'73020-0017');, 

INSERT INTO ArtWork values('1','Refugee',)


select * from ArtWork;

2) select FirstName + ' ' + LastName  as FullName,
		BirthDate,Street,City,StateName,ZipCode,Title,Price,Form 
   from Artist
   INNER JOIN ArtWork on Artist.ID= ArtWork.ID INNER JOIN State ON Artist.StateID=State.StateID;

<--SELECT FirstName + ' ' + LastName  as FullName,
	<--	BirthDate,Street,City,StateName,ZipCode,Title,Price,Form from Artist,ArtWork,State where Artist.ID= ArtWork.ID AND Artist.StateID=State.StateID;

 3) SELECT *  from ArtWork inner join Artist on Artist.id= ArtWork.ID where Datepart(year,AcquisitionDate) BETWEEN 2015 AND 2020;

 4) SELECT FirstName+' '+LastName as FullName, Title As ArtWork, Price from Artist INNER JOIN ArtWork ON Artist.ID= ArtWork.ID where Price>= 30000 ORDER BY Price;

5) SELECT top 5 Title,Price,FirstName+' '+LastName as FullName,BirthDate ,Street,City, StateAb from ArtWork INNER join Artist on Artist.id= ArtWork.ID 
	order by Price DESC;

6) select Title, Form, FirstName+' '+LastName as FullName,Price,BirthDate ,Street,City, StateAb  from Artist Left join ArtWork on Artist.id= ArtWork.ID where form='painting' ORDER BY Price;

7) SELECT StateName,FirstName+' '+LastName as FullName from State left join Artist on State.StateID= Artist.StateID  ORDER BY StateName;

8) SELECT FirstName+' '+LastName as FullName,Street+' '+City+' '+A.StateAb+' '+ZipCode as Address from Artist A Inner join State S on A.StateID=S.StateID where StateName='Oklahoma';

9) <-- SELECT  FirstName+' '+LastName as FullName from Artist A LEFT join ArtWork AW on A.ID= AW.ID where AW.ID= (SELECT COUNT(AW.ID) FROM ArtWork Group By A.ID having count(AW.ID)=2);

	<--SELECT * FROM Artist A,ArtWork AW where AW.ID= (SELECT COUNT(id) FROM ArtWork Group By ID having count(id)=2);

	SELECT * FROM ArtWork where ID IN(SELECT COUNT(id) FROM ArtWork Group By ID having count(ID)>=2);

	SELECT COUNT()

10)<-- SELECT FirstName+' '+LastName as FullName,Title,Price from Artist,ArtWork,State where State.StateName='Texas' AND (Price BETWEEN 10000 AND 12000);

	SELECT  FirstName+' '+LastName as FullName,Title,Price,StateName from Artist,ArtWork LEFT JOIN State ON ID = ArtWork.ID WHERE State.StateName='Texas';

11) SELECT FirstName+' '+LastName as FullName,Street, City, StateAb, ZipCode from Artist where LEFT(LastName,1) NOT IN('A','E','I','O','U');

12) SELECT Title as MaxTitle ,Price as MaxPrice, Form as MaxForm from ArtWork where Price =(SELECT MAX(Price) from ArtWork)
	UNION
	SELECT Title as MinTitle ,Price as MinPrice, Form as MinForm from ArtWork where Price =(SELECT MIN(Price) from ArtWork);



13) SELECT Sum(Price) AS Sum, AVG(Price) AS Avg, Max(Price) AS Max,MIN(Price) as MIN from ArtWork,State GROUP BY StateName HAVING StateName='Texas';

14) SELECT Title, Price from ArtWork  where Price = (SELECT MAX(Price) from ArtWork)
	UNION
	SELECT Title, Price from ArtWork  where Price = (SELECT MIN(Price) from ArtWork);

15) select FirstName+' '+LastName as FullName, BirthDate, Street,City, State.StateName,ZipCode from Artist left join State on Artist.StateID= State.StateID where BirthDate= (SELECT MIN(BirthDate) from Artist);


SELECT Sum(Price) AS Sum, AVG(Price) AS Avg, Max(Price) AS Max,MIN(Price) as MIN from ArtWork,State where StateName='Texas';