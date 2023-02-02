# Add MongoDB Tools bin Folder to Enviroment Path Variables

# Set Variables
Write-Host "MongoDB Backup Script"
$database = Read-Host -Prompt "Enter the name of the database you want to backup"
if (!$database)
{ Write-Host "Invalid name, exiting programm"
  exit }

$date = Get-Date -Format "yyyy-MM-ddTHH-mm-ss"
$backup = $Env:HOMEPATH + "\mongobackup\mongo_backup_" + $date

# Backup
mongodump --db $database --out $backup

Write-Host "Database backup completed, backup location: $backup\$database"