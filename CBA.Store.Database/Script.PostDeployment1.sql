/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS(SELECT * FROM Product)
BEGIN
	 INSERT INTO Product
	 VALUES ('Green Apples', 'Fresh green apples', 2.10),
		('Pineapple', 'QLD pineapple', 4.80),
		('Oranges', 'Fresh oranges', 1.75),
		('Peaches', 'Lovely peaches', 3.60);
END;