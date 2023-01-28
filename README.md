# Informationen
Ein Web API für eine imaginäre Skiservice-Firma (Jetstream Service), diese Firma hat bereits eine Online Präsenz, braucht aber noch ein Web API.  
Dieses Web API braucht die Firma für die Aufnahme von Registrationen, welche dann in einer MongoDB Datenbank gespeichert werden.  
Das Web API muss auch eine Authentifikation bieten, welche Admins erlaubt Registrationen zu modifizieren und auszulesen.  

## Durchsetzung

Dieses Projekt habe ich mit C#, und einer MongoDB Datenbank durchgesetzt, um auf diese Datenbank zuzugreifen habe ich den C# MongoDB Driver verwendet.  
Für die Authentifikation von Admins habe ich ein JWT Token, welches einen Tag gültig ist, verwendet.  
Zuletzt habe ich für die Durchsetzung des Web APIs Services/Controller und Dependency Injection (DI) verwendet.

## Technologien/Software
Dieses Projekt wurde auf **.NET 6.0** erstellt und folgende NuGet Packete (mit Versionen) wurden/kamen installiert:  
- Microsoft.AspNetCore.Authentication.JwtBearer, Version=6.0.13
- MongoDB.Driver, Version=2.18.0
- Serilog.AspNetCore, Version=6.1.0
- Swashbuckle.AspNetCore, Version=6.5.0  

Visual Studio ist bei erstellung dieses Projektes auf **Version 17.4.33122.133**  
Auf dem Rechner mit dem das Projekt erstellt wurde läuft eine Version von Microsoft Windows 11
