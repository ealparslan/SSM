

/****** Object:  UserDefinedFunction [dbo].[getSoldAmountRequested]    Script Date: 10/25/2015 2:33:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[getSoldAmountRequested](@orderId float)
RETURNS float
AS
BEGIN
    DECLARE @r float
    select @r =   sum(totalSold) FROM (
  SELECT  (co.[SetPrice]*ol.[SoldBoxQuantity]) AS totalSold
  FROM [dbo].[OrderLists] AS ol, [dbo].[COGS] AS co
  where ol.[OrderId] = @orderId AND co.[ProductId] = ol.[ProductId]
  ) t
    RETURN @r
END



GO

/****** Object:  UserDefinedFunction [dbo].[getRequestedAmountRequested]    Script Date: 10/25/2015 2:33:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[getRequestedAmountRequested](@orderId float)
RETURNS float
AS
BEGIN
    DECLARE @r float
    select @r =   sum(totalRequested) FROM (
  SELECT  (co.[SetPrice]*ol.[RequestedBoxQuantity]) AS totalRequested
  FROM [dbo].[OrderLists] AS ol, [dbo].[COGS] AS co
  where ol.[OrderId] = @orderId AND co.[ProductId] = ol.[ProductId]
  ) t
    RETURN @r
END



GO


/****** Object:  Trigger [dbo].[ShipmentDeliveredCancel]    Script Date: 10/25/2015 2:33:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[ShipmentDeliveredCancel]
  ON [dbo].[Shipments]
  FOR UPDATE AS 

  IF UPDATE(IsDelivered)
  BEGIN
  DELETE FROM [dbo].[DeliveryLists] WHERE [DeliveryId] =  (SELECT Id FROM [dbo].[Deliveries] WHERE [ShipmentId] =  (SELECT Id FROM inserted WHERE IsDelivered = 0))
  DELETE FROM [dbo].[Deliveries] WHERE [ShipmentId] =  (SELECT Id FROM inserted WHERE IsDelivered = 0)
  END


GO


/****** Object:  Trigger [dbo].[ShipmentDelivered]    Script Date: 10/25/2015 2:33:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




create TRIGGER [dbo].[ShipmentDelivered]
  ON [dbo].[Shipments]
  FOR UPDATE AS 

  IF UPDATE(IsDelivered)
  BEGIN
	INSERT INTO [dbo].[Deliveries] ([Date],[ShipmentId],[BarcodesPrinted]) 
		SELECT GETDATE(),Id, 'false' as [BarcodesPrinted] FROM inserted WHERE IsDelivered = 1

	INSERT INTO [dbo].[DeliveryLists] ([ProductId],[BoxQuantity],[PartCapOfBox],[DeliveryId],[BarcodesPrinted]) 
		SELECT s.[ProductId],s.[BoxQuantity],s.[BoxCapacity],d.[Id],'false' as [BarcodesPrinted] FROM [dbo].[ShipmentLists] s, [dbo].[Deliveries] d
			WHERE s.ShipmentId = (SELECT Id FROM inserted WHERE IsDelivered = 1)
					AND s.ShipmentId = d.ShipmentId
  END


GO
