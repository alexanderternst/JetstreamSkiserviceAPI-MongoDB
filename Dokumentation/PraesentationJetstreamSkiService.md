---
marp: true
#theme: uncover_class: invert
---

# Präsentation Jetstream Ski Service
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
* Die bis anhin eingesetzte relationale Datenbank genügt den damit verbundenen Ansprüchen an Datenverteilung und Skalierung nicht mehr. Sie wollen auf NoSQL wechseln.

---

# Zeitplanung/PSP

![width:650px](/bilder/ProjektplanungWBS.png)

---

# Zeitplanung/PSP

![height:500px](/bilder/ProjektplanungGANTT.png)

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

- Zugriff von Status auf Registrationen
- User nach 3 falschen Loginversuchen sperren
- Backup/Restore

---

# Tools

| Tool | Beschreibung |
| --- | --- |
| GitHub | Versionierungstool |
| Visual Studio | Entwicklungsumgebung |
| Postman | API-Testtool |
| WPF | Testing |

---

# Live Demo

![width:600px](https://media.istockphoto.com/id/1328399434/photo/live-demo-symbol-concept-words-live-demo-on-wooden-blocks-on-a-beautiful-orange-background.jpg?s=612x612&w=0&k=20&c=xrEz6Zdkz2htzivAG-JrwhWTW0v2emTz6PZ_aFIHzPw=)

---

# Reflexion/Fazit

- Hauptanforderungen erfülltn (API, Authentifikation, Zusatzfeature)
- API ist lauffähig
- Mapper sind noch nicht implementiert
- Viel über MongoDB und etwas neues an C# gelernt