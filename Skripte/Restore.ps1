Write-Host "Welcome to Restore mongoDB Script"

$file = Read-Host -Prompt "Enter path of the backup you want to restore (e.g. c:\mongodb\SkiService)"
$database = Read-Host -prompt "Enter the name of the database you want to restore your data to"
# Restore
mongorestore --db $database $file

Write-Host "Restore completed, database name: $database"