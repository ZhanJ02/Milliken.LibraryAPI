CREATE TABLE [dbo].[Movie] (
    [Name]              NVARCHAR (50) NOT NULL,
    [Genre]             TINYINT       NOT NULL,
    [DurationInMinutes] INT           NOT NULL,
    [IsAvailable]       BIT           NOT NULL
);

