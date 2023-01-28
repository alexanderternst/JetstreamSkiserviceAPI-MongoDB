# Add MongoDB Tools bin Folder to Enviroment Path Variables
# Backup
mongodump --db SkiServiceDB --out C:\tools
# Restore
mongorestore --db SkiServiceDB C:\tools\SkiServiceDB