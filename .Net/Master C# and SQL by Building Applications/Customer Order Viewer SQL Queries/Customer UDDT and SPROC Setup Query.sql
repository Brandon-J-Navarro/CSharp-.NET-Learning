USE CustomerOrderViewer;
GO

ALTER TABLE [dbo].[Customer]
ADD CreateDate DATETIME NOT NULL DEFAULT(GETDATE()),
    CreateId VARCHAR(50) NOT NULL DEFAULT('System'),
    UpdateDate DATETIME NOT NULL DEFAULT(GETDATE()),
    UpdateId VARCHAR(50) NOT NULL DEFAULT('System'),
    ActiveInd BIT NOT NULL DEFAULT(CONVERT(BIT,1))
GO

CREATE TYPE [dbo].[CustomerType] AS TABLE
(
    CustomerId INT NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NULL,
    LastName VARCHAR(50) NOT NULL,
    Age INT NOT NULL
);
GO

CREATE PROCEDURE [dbo].[Customer_Delete]
    @CustomerId INT,
    @UserId VARCHAR(50)
AS
    UPDATE Customer
    SET
        ActiveInd = CONVERT(BIT, 0),
        UpdateId = @UserId,
        UpdateDate = GETDATE()
    WHERE
        CustomerId = @CustomerId AND
        ActiveInd = CONVERT(BIT, 1);
GO

CREATE PROCEDURE [dbo].[Customer_Upsert] 
    @CustomerType CustomerType READONLY,
    @UserId VARCHAR(50)
AS
    MERGE INTO Customer TARGET
    USING
    (
        SELECT
            CustomerId,
            FirstName,
            MiddleName,
            LastName,
            Age,
            @UserId [UpdateId],
            GETDATE() [UpdateDate],
            @UserId [CreateId],
            GETDATE() [CreateDate]
        FROM
            @CustomerType
    )AS SOURCE
    ON
    (
        TARGET.CustomerId = COALESCE(SOURCE.CustomerId, -1)
    )
    WHEN MATCHED THEN
        UPDATE SET
            TARGET.FirstName = SOURCE.FirstName,
            TARGET.MiddleName = SOURCE.MiddleName,
            TARGET.LastName = SOURCE.LastName,
            TARGET.Age = SOURCE.Age,
            TARGET.UpdateId = SOURCE.UpdateId,
            TARGET.UpdateDate = SOURCE.UpdateDate

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (FirstName, MiddleName, LastName, Age, CreateId, CreateDate, UpdateId, UpdateDate, ActiveInd)
        VALUES (SOURCE.FirstName, SOURCE.MiddleName, SOURCE.LastName, SOURCE.Age, SOURCE.CreateId, SOURCE.CreateDate, SOURCE.UpdateId, SOURCE.UpdateDate, CONVERT(BIT, 1));
GO
