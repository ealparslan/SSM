  create TRIGGER ShipmentDelivered
  ON [dbo].[Shipments]
  FOR UPDATE AS 

  IF UPDATE(IsDelivered)
  BEGIN
	INSERT INTO [dbo].[Deliveries] ([Date],[ShipmentId]) 
		SELECT GETDATE(),Id FROM inserted WHERE IsDelivered = 1

	INSERT INTO [dbo].[DeliveryLists] ([ProductId],[BoxQuantiy],[PartCapOfBox],[DeliveryId]) 
		SELECT s.[ProductId],s.[BoxQuantity],s.[BoxCapacity],d.[Id] FROM [dbo].[ShipmentLists] s, [dbo].[Deliveries] d
			WHERE s.ShipmentId = (SELECT Id FROM inserted WHERE IsDelivered = 1)
					AND s.ShipmentId = d.ShipmentId
  END


   
	CREATE TRIGGER ShipmentDeliveredCancel
  ON [dbo].[Shipments]
  FOR UPDATE AS 

  IF UPDATE(IsDelivered)
  BEGIN
  DELETE FROM [dbo].[DeliveryLists] WHERE [DeliveryId] =  (SELECT Id FROM [dbo].[Deliveries] WHERE [ShipmentId] =  (SELECT Id FROM inserted WHERE IsDelivered = 0))
  DELETE FROM [dbo].[Deliveries] WHERE [ShipmentId] =  (SELECT Id FROM inserted WHERE IsDelivered = 0)
  END



  DELETE FROM [dbo].[DeliveryLists]
DELETE FROM [dbo].[Deliveries]
DBCC CHECKIDENT ('[SSM].[dbo].[Deliveries]',RESEED, 0)
DBCC CHECKIDENT ('[SSM].[dbo].[DeliveryLists]',RESEED, 0)