# Architecture Decision Record

## 1. Warstwowa architektura

| **Sekcja** | **Treść** |
|-----------|-----------|
| **Kontekst** | Zadanie wymagało oddzielenia logiki biznesowej od API oraz łatwego mockowania danych. Projekt nie będzie rozwijany, ale architektura ma pokazać dobre praktyki. |
| **Decyzja** | Zastosowano cztery warstwy: <br>• **Api** – kontrolery i kontrakty <br>• **Application** – przypadki użycia <br>• **Domain** – model domenowy i reguły biznesowe <br>• **Infrastructure** – repozytoria i findery in‑memory |
| **Uzasadnienie** | • jasny podział odpowiedzialności <br>• izolacja logiki biznesowej <br>• łatwość testowania <br>• zachowanie zasady zależności (Domain nie zależy od Infrastructure) |
| **Konsekwencje** | • czytelna struktura <br>• większa złożoność i koszt początkowy jak na małe zadanie |

---

## 2. Model zadań – dziedziczenie vs. model płaski

| **Sekcja** | **Treść** |
|-----------|-----------|
| **Kontekst** | Zadania mają różne pola zależnie od typu (Implementacja, Utrzymanie, Wdrożenie). Rozważano: <br>**A)** jedna klasa + CustomFields <br>**B)** dziedziczenie. <br>Dodatkowo analizowano nazewnictwo (Task vs Issue). |
| **Decyzja** | • Wybrano **dziedziczenie** w domenie. <br>• CustomFields stosowane tylko w API. <br>• Nazwa encji: **Issue** |
| **Uzasadnienie** | • Domenowy model musi być bezpieczny typowo. <br>• CustomFields utrudniałyby walidację i testy. <br>• Dziedziczenie pozwala umieścić logikę specyficzną dla typu w odpowiedniej klasie. <br>• „Task” jest zarezerwowane w .NET i kojarzy się z async. „Issue” jest neutralne i zgodne z praktyką (np. YouTrack). |
| **Konsekwencje** | • czysta i spójna domena <br>• silne typowanie, brak pól opcjonalnych <br>• łatwiejsza walidacja i testowanie <br>• więcej klas i bardziej rozbudowany model <br>• konieczność mapowania polimorficznego <br>• dodanie nowego typu = nowa klasa |

---

## 3. Zasady przypisywania zadań do użytkownika

| **Sekcja** | **Treść** |
|-----------|-----------|
| **Kontekst** | Zasady przypisywania są złożone: <br>• procent trudnych zadań <br>• procent łatwych <br>• zakres liczby zadań <br>• ograniczenia zależne od roli użytkownika |
| **Decyzja** | Wydzielono polityki do **IIssueAssignmentPolicy** z implementacjami: <br>• DeveloperIssueAssignmentPolicy <br>• DevOpsIssueAssignmentPolicy <br>Wspólna logika w klasie bazowej. |
| **Uzasadnienie** | • agregat User pozostaje prosty <br>• polityki są łatwe do testowania i modyfikacji <br>• logika biznesowa skupiona w jednym miejscu |
| **Konsekwencje** | • czysty agregat <br>• łatwe rozszerzanie o kolejne role i reguły |

---

## 4. Separacja zapisu i odczytu

| **Sekcja** | **Treść** |
|-----------|-----------|
| **Kontekst** | Odczyt i zapis mają różne wymagania. API potrzebuje lekkich modeli, domena pełnych agregatów. |
| **Decyzja** | • Commandy modyfikują domenę <br>• Query zwracają DTO <br>• Repozytoria zwracają agregaty domenowe <br>• Findery zwracają read‑modele |
| **Uzasadnienie** | • separacja odpowiedzialności <br>• uproszczenie kodu <br>• brak przeciekania domeny do API |
| **Konsekwencje** | • czytelny podział logiki <br>• pewna nadmiarowość kodu |

---

## 5. Mock danych zamiast bazy

| **Sekcja** | **Treść** |
|-----------|-----------|
| **Kontekst** | Zadanie wymaga działania na mockach danych. Projekt nie będzie rozwijany, więc pełna baza nie jest potrzebna. |
| **Decyzja** | Przygotowano statyczne dane i zasymulowano bazę jako **InMemoryDatabase**. |
| **Uzasadnienie** | • prostota <br>• szybkie uruchomienie <br>• brak konieczności tworzenia modeli persystencji |
| **Konsekwencje** | • minimalna infrastruktura <br>• brak trwałości danych (akceptowalne w zadaniu) 
