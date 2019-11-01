USE [TCRateAndFeedbackDB]
GO

CREATE TABLE [dbo].[tbl_UserReviewType] (
	[lng_rating_id] [tinyint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[str_rating_name] [varchar](30) NOT NULL
)
GO

CREATE TABLE [dbo].[tbl_UserReview] (
	[lng_review_id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[str_username] [varchar](50) NOT NULL,
	[int_rating_id] [tinyint] NOT NULL FOREIGN KEY REFERENCES [tbl_UserReviewType] (lng_rating_id),
	[str_comment] [varchar](250) NULL,
	[dtm_time_submitted] [smalldatetime] DEFAULT GETDATE() NOT NULL
)
GO

INSERT INTO [tbl_UserReviewType]
	([str_rating_name]) 
VALUES
	('Excellent'),
	('Moderate'),
	('Needs Improvement')
GO

INSERT INTO [tbl_UserReview] 
	([str_username],
	 [int_rating_id],
	 [str_comment]) 
VALUES
	('Test User', 2, 'Test Users comment'),
	('Test User2', 3, 'Test User2s comment')
GO
