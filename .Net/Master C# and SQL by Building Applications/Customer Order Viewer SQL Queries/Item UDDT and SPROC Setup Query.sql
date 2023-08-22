USE CustomerOrderViewer;
GO

ALTER TABLE [dbo].[Item]
ADD CreateDate DATETIME NOT NULL DEFAULT(GETDATE()),
    CreateId VARCHAR(50) NOT NULL DEFAULT('System'),
    UpdateDate DATETIME NOT NULL DEFAULT(GETDATE()),
    UpdateId VARCHAR(50) NOT NULL DEFAULT('System'),
    ActiveInd BIT NOT NULL DEFAULT(CONVERT(BIT,1))
GO

CREATE TYPE [dbo].[ItemType] AS TABLE
(
    ItemId INT NOT NULL,
    [Description] VARCHAR(50) NOT NULL,
    Price DECIMAL(4,2) NOT NULL
);
GO

CREATE PROCEDURE [dbo].[Item_Delete]
    @ItemId INT,
    @UserId VARCHAR(50)
AS
    UPDATE Item
    SET
        ActiveInd = CONVERT(BIT, 0),
        UpdateId = @UserId,
        UpdateDate = GETDATE()
    WHERE
        ItemId = @ItemId AND
        ActiveInd = CONVERT(BIT, 1);
GO

CREATE PROCEDURE [dbo].[Item_Upsert] 
    @ItemType ItemType READONLY,
    @UserId VARCHAR(50)
AS
    MERGE INTO Item TARGET
    USING
    (
        SELECT
            ItemId,
            [Description],
            Price,
            @UserId [UpdateId],
            GETDATE() [UpdateDate],
            @UserId [CreateId],
            GETDATE() [CreateDate]
        FROM
            @ItemType
    )AS SOURCE
    ON
    (
        TARGET.ItemId = COALESCE(SOURCE.ItemId, -1)
    )
    WHEN MATCHED THEN
        UPDATE SET
            TARGET.[Description] = SOURCE.[Description],
            TARGET.Price = SOURCE.Price,
            TARGET.UpdateId = SOURCE.UpdateId,
            TARGET.UpdateDate = SOURCE.UpdateDate

    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([Description], Price, CreateId, CreateDate, UpdateId, UpdateDate, ActiveInd)
        VALUES (SOURCE.[Description], SOURCE.Price, SOURCE.CreateId, SOURCE.CreateDate, SOURCE.UpdateId, SOURCE.UpdateDate, CONVERT(BIT, 1));
GO
