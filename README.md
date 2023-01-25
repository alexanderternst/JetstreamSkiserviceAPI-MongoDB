# Informationen
Ein Web API für eine imaginäre Skiservice-Firma (Jetstream Service), diese Firma hat bereits eine Online Präsenz, braucht aber noch ein Web API.  
Dieses Web API brauchen Sie für die Aufnahme von Registrationen, welche dann in einer MongoDB Datenbank gespeichert werden.  
Das Web API muss auch eine Authentifikation bieten, welche Admins erlaubt Registrationen zu modifizieren und auszulesen.  

## Durchsetzung

Dieses Projekt habe ich mit C# durchgesetzt, und eine MongoDB Datenbank verwendet, um auf diese zuzugreifen habe ich den C# MongoDB Driver verwendet.  
Zuletzt habe ich für die Durchsetzung des Web APIs Services/Controller und Dependency Injection (DI) verwendet.  
Für die Authentifikation von Admins habe ich ein JWT Token, welches einen Tag gültig ist, verwendet.
