USE Registration

select * from dbo.Registrations;
GO

/** CREATE VIEW/ALTER VIEW **/
ALTER VIEW orders AS
SELECT 
	Name AS name, 
	Email AS email, 
	Phone AS phone, 
	Create_date AS create_date, 
	Pickup_date AS pickup_date, 
	Status_name AS status, 
	Priority_name AS priority, 
	Service_name AS service, 
	Comment AS comment
FROM dbo.Registrations
INNER JOIN dbo.Priority
ON Registrations.Priority_id = Priority.Priority_id
INNER JOIN dbo.Service
ON Registrations.Service_id = Service.Service_id
INNER JOIN dbo.Status
ON Registrations.Status_id = Status.Status_id;
GO

/* Export table to a json */
select * from orders
FOR JSON PATH,
 INCLUDE_NULL_VALUES
GO

/* Export JSON data to a file */
/* Hierfür xp_cmdshell aktiviert sein
	1. SQL Server Management Studio
	2. Server -> Facets -> Surface Area Configuration auswählen -> XPCmdShellEnabled Property auf true setzen
*/
DECLARE @sql varchar(1000)
SET @sql = 'bcp "SELECT * FROM orders' + 
    'FOR JSON PATH, INCLUDE_NULL_VALUES" ' +
    'queryout  "c:\test\data.json" ' + 
    '-c -S MACWIN2 -d WideWorldImporters -T'
EXEC sys.XP_CMDSHELL @sql
GO

-- In PowerShell:
-- mongoimport --db SkiServiceDB --collection registrations --file SQLdata.json --jsonArray
