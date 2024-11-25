create table Users
(
UserID int primary key,
[Name] nvarchar(50),
[Password] nvarchar(50),
Email nvarchar(50)unique,
[Role] nvarchar(50)
)

create Table Tasks
(
UserID int
foreign key (UserID) references Users (UserID),
TaskID int primary key,
Title nvarchar(50),
[Description] nvarchar(50),
[Status] nvarchar(50),
DueDate datetime null,
)

Create table P_I_tasks
(
UserID int
foreign key (UserID) references Users (UserID),
TaskID int
foreign key (TaskID) references Tasks (TaskID),
Title nvarchar(50),
[Description] nvarchar(50),
[Status] nvarchar(50),
DueDate datetime null,
)

create table C_Tasks
(
UserID int
foreign key (UserID) references Users (UserID),
TaskID int
foreign key (TaskID) references Tasks (TaskID),
Title nvarchar(50),
[Description] nvarchar(50),
[Status] nvarchar(50),
DueDate datetime null,
)

insert into users
Values
(1 , 'Eman Agha    ' , 'Eman123   ' , 'Emanaliagha2011@yahoo.com' , 'Manager '),
(2 , 'Ahmed Salah  ' , 'Ahmed123  ' , 'Abohaidy2005@gmail.com   ' , 'Employee'),
(3 , 'Haidy Ahmed  ' , 'Haidy123  ' , 'Dandelion2005@gmail.com  ' , 'Manager '),
(4 , 'Mohamed Ahmed' , 'Mohamed123' , 'souking7274@gmail.com    ' , 'Employee'),
(5 , 'Sandy Ahmed  ' , 'Sandy123  ' , 'Sandysand2013@gmail.com  ' , 'Manager ')

insert into Tasks
Values
(1 , 1 , 'Organizing ' , 'Organizing the papers' , 'Completed  ' , null),
(2 , 2 , 'Selling    ' , 'Selling products     ' , 'In Progress' , null),
(3 , 3 , 'winning    ' , 'Signing a contract   ' , 'In Progress' , null),
(4 , 4 , 'Cleaning   ' , 'Cleaning the building' , 'Completed  ' , null),
(5 , 5 , 'Programming' , 'Programming an app   ' , 'Pending    ' , null)

insert into P_I_tasks
values
(2 , 2 , 'Selling    ' , 'Selling products     ' , 'In Progress' , null),
(3 , 3 , 'winning    ' , 'Signing a contract   ' , 'In Progress' , null),
(5 , 5 , 'Programming' , 'Programming an app   ' , 'Pending    ' , null)

insert into C_Tasks
values
(1 , 1 , 'Organizing ' , 'Organizing the papers' , 'Completed  ' , null),
(4 , 4 , 'Cleaning   ' , 'Cleaning the building' , 'Completed  ' , null)