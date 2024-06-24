CREATE TABLE [dbo].[Book] (
    [Title]         NVARCHAR (25) NOT NULL,
    [Author]        NVARCHAR (25) NOT NULL,
    [Pages]         INT           NOT NULL,
    [YearPublished] DATE          NOT NULL,
    [IsAvailable]   BIT           NOT NULL,
    [FileSize]      FLOAT (53)    NOT NULL,
    [IsElectronic]  BIT           NOT NULL
);

