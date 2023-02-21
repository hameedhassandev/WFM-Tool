USE WfmDb

INSERT INTO dbo.Department (Name)
VALUES ('Data Entry'),
       ('Operation Service')


INSERT INTO dbo.ExceptionType (ExceptionName)
VALUES ('Sick'),
       ('Annual'),
	   ('Work'),
	   ('Day Off'),
	   ('Emergency')

INSERT INTO dbo.ExceptionStatus (Status)
VALUES ('Approved'),
       ('Rejected'),
	   ('Waiting for wfm'),
	   ('Pending'),
	   ('Canceled by creator'),
	   ('Dispute')
	   
	   
SELECT * FROM dbo.Department
SELECT * FROM dbo.AspNetUsers
SELECT * FROM dbo.AspNetUserRoles
SELECT * FROM dbo.AspNetRoles
SELECT * FROM dbo.ExceptionComment
SELECT * FROM dbo.ExceptionType
SELECT * FROM dbo.ExceptionStatus
SELECT * FROM dbo.Exceptions


