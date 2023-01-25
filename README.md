# Informationen
Ein Web API für eine imaginäre Skiservice-Firma (Jetstream Service), diese Firma hat bereits eine Online Präsenz, braucht aber noch ein Web API.  
Dieses Web API brauchen Sie für die Aufnahme von Registrationen, welche dann in einer MongoDB Datenbank gespeichert werden.  
Das Web API muss auch eine Authentifikation bieten, welche Admins erlaubt Registrationen zu modifizieren und auszulesen.  

## Durchsetzung

Dieses Projekt habe ich mit C#, und einer MongoDB Datenbank durchgesetzt, um auf diese Datenbank zuzugreifen habe ich den C# MongoDB Driver verwendet.  
Für die Authentifikation von Admins habe ich ein JWT Token, welches einen Tag gültig ist, verwendet.  
Zuletzt habe ich für die Durchsetzung des Web APIs Services/Controller und Dependency Injection (DI) verwendet.
