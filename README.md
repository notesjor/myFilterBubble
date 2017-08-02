# myFilterBubble
Kontext-Suche (Prototyp) basierend auf dem CorpusExplorer.SDK (Framework).
Suchoptionen
- __CONTAINS__: Durchsucht Dokumente nach exakt den gegebenen Begriffen (vereinzelte Vorkommen reichen aus).
- __ALL-IN__: Dokumente müsse alle Suchbegriffe enthalten.
- __PHRASE__: Suche nach exakten Phrasen (Suchbegriffe in der gegebenen Reihenfolge).
- __SIMILARITY__: Kontextsuche (benötigt ca. 2000 Zeichen).

Wurden Dokumente mit den oben genannten Suchausdrücken gefunden, kann durch einen Klick auf SIMILAR nach ähnlichen Dokumenten gesucht werden.

Einschränkungen aktuelle ALPHA-Version:
- Referenzmodel notwendig, bitte Autor kontaktieren (siehe Link/Webseite).
- Aktuell kann nur ein Indexraum im Ordner C:\Indexed aufgebaut werden.
