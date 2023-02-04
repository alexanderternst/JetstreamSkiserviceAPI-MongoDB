---
marp: true
---

# Präsentation Jetstream SkiService
## Alexander Ernst

---

# Inhaltsverzeichnis

- Ausgangslage/Anforderungen
- Zeitplanung/PSP
- Vorgehensweise - IPERKA
- Zusatzfeature
- Tools
- Live Demo
- Reflexion/Fazit

---

# Ausgangslage/Anforderungen

* Die Firma Jetstream-Service führt als KMU in der Wintersaison Skiservicearbeiten durch.
* Die bis anhin eingesetzte relationale Datenbank genügt den damit verbundenen Ansprüchen an Datenverteilung und Skalierung nicht mehr. Sie wollen auf eine NoSQL Datenbank wechseln.

---

# Zeitplanung/PSP

![width:800px](https://github.com/alexanderternst/JetstreamSkiserviceAPI-MongoDB/blob/master/Dokumentation/bilder/ProjektplanungWBS.png?raw=true)

---

# Zeitplanung/PSP

![height:600px](https://github.com/alexanderternst/JetstreamSkiserviceAPI-MongoDB/blob/master/Dokumentation/bilder/ProjektplanungGANTT.png?raw=true)

--- 

# Vorgehensweise - IPERKA

- **Informieren:** Ausgangslage, Technologien
- **Planen:** Aufbau Datenbank/Web API, Zeitplanung
- **Entscheiden:** Tools, Aufbau
- **Realisieren:** Datenbank/Web API realisieren
- **Kontrollieren:** Mit Postman/WPF testen
- **Auswerten:** Reflexion/Fazit

---

# Zusatzfeature

- Zugriff auf Registrationen nach Status/Aktualisieren von nur Status
- User nach 3 falschen Loginversuchen sperren
- Backup/Restore Skripte

---

# Tools

| Tool | Beschreibung |
| --- | --- |
| GitHub | Versionierungstool |
| Visual Studio 2022 | Entwicklungsumgebung |
| Postman | API-Testtool |
| WPF Applikation | Benutzer-Testtool |


---

# Live Demo

![width:650px](https://media.istockphoto.com/id/1328399434/photo/live-demo-symbol-concept-words-live-demo-on-wooden-blocks-on-a-beautiful-orange-background.jpg?s=612x612&w=0&k=20&c=xrEz6Zdkz2htzivAG-JrwhWTW0v2emTz6PZ_aFIHzPw=)

---

# Reflexion/Fazit

- Hauptanforderungen erfüllt (API, Authentifikation, Zusatzfeature)
- API ist lauffähig
- Statistische Auswertung ist noch nicht implementiert
- Viel neues über MongoDB und C# MongoDB Driver gelernt