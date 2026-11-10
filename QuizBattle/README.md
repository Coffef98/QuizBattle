# 🐢 MagicTurtels QuizBattle

Ett frågesportspel i C# där 2–4 spelare tävlar om att samla flest poäng.

## Spelets funktioner

- 2–4 spelare med unika namn.
- 1–10 rundor per spel.
- Frågor i olika kategorier och svårighetsgrader.
- Flervalsfrågor och sant/falskt-frågor.
- Seriebonus för flera rätta svar i rad.
- Topplista med de 10 bästa resultaten.

## Poängsystem

| Svårighetsgrad | Poäng |
|---|---:|
| Lätt | 10 |
| Medel | 20 |
| Svår | 30 |

Fel svar ger 0 poäng och nollställer spelarens seriebonus.

Seriebonusen ökar med 5 poäng per rätt svar i följd efter det första, upp till maximalt 20 bonuspoäng.

## Så startar du spelet

1. Klona eller ladda ner projektet från GitHub.
2. Öppna projektet i Visual Studio.
3. Bygg projektet.
4. Starta programmet.
5. Välj **1. Spela** i huvudmenyn.

## Topplista

Resultaten sparas i `data/highscores.json`.

Varje resultat innehåller spelarens namn, poäng, antal rätta svar och datum.

Topplistan sorteras efter högst poäng. Vid lika poäng visas spelaren med flest rätta svar först.

## Projektstruktur

- `Program.cs` – programmets startpunkt.
- `GameManager.cs` – spelmotor och vinnarlogik.
- `player.cs` – spelarnas poäng och statistik.
- `ConsoleUI.cs` – menyer och användarinmatning.
- `HighscoreManager.cs` – läser, sparar och sorterar resultat.
- `HighscoreEntry.cs` – modell för sparade resultat.
- `data/questions.json` – frågorna.
- `data/highscores.json` – topplistan.

## Gruppens ansvar

**Person 1:** Kärnlogik och spelmotor.

**Person 2:** Frågesystem, arv och JSON-inläsning.

**Person 3:** Menyer, interaktion och validering.

**Person 4:** Topplista, filhantering, Git och dokumentation.

## Teknik

- C#
- .NET
- JSON
- Git och GitHub