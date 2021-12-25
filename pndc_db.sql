CREATE TABLE cricketers
(
Jersey_Number int primary key identity(1,1),
Name varchar(50),
Age int,
Player_Role varchar(50),
Contract_Category varchar(10)
)


insert into cricketers values('Muhammad Rizwan',29,'Wicketkeeper Batsmen','A')
insert into cricketers values('Shaheen Afridi',21,'Fast Bowler','A')