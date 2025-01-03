# Employee And Company Management

## Uvod

Employee And Company Management je aplikacija koja omogućava efikasno upravljanje zaposlenima i organizacionom strukturom unutar kompanija. Osmišljena je da pojednostavi svakodnevne zadatke vezane za vođenje evidencije i organizaciju, pružajući ugodno korisničko iskustvo. Riječ je o desktop aplikaciji razvijenoj u C# programskom jeziku uz korištenje WPF (Windows Presentation Foundation) razvojnog okvira. Aplikacija koristi MySQL bazu podataka za čuvanje svih podataka. Za upotrebu aplikacije potreban je desktop ili laptop računar sa Windows operativnim sistemom i minimalnim hardverskim specifikacijama.

### Korisnički nalozi

Sama aplikacija EmployeeManager je osmišljena tako da podržava tri korisničke uloge: administrator, kompanija i zaposlenoi. Svaka od ovih uloga ima specifične odgovornosti i pristup funkcionalnostima aplikacije, prilagođen njihovim potrebama.

* Administrator ima ključnu ulogu u radu sistema. Njegova odgovornost uključuje kreiranje novih kompanija u sistemu, upravljanje postojećim kompanijama kroz aktivaciju, suspendovanje ili brisanje, kao i kreiranje i administraciju korisničkih naloga za zaposlene. Pored toga, administrator je zadužen za upravljanje stručnim spremama zaposlenih, uključujući dodavanje, uređivanje i uklanjanje podataka o obrazovnim kvalifikacijama. Ove aktivnosti omogućavaju nesmetano funkcionisanje aplikacije i pružaju osnovu za rad drugih korisničkih uloga.

* Korisnici sa ulogom kompanije predstavljaju menadžment ili administrativno osoblje zaduženo za internu organizaciju i upravljanje procesima unutar kompanije. Oni koriste aplikaciju za kreiranje i zaključivanje zaposlenja, upravljanje organizacionom strukturom koja uključuje odeljenja i radna mesta, te imaju mogućnost pregleda podataka o zaposlenima i njihovim angažmanima.

* Zaposleni su korisnici aplikacije koji imaju pristup informacijama vezanim za njihovo radno angažovanje. Oni mogu pregledati istoriju svojih zaposlenja i pregledati evidenciju isplaćenih plata uz dodatne mogućnosti filtriranja i sortiranja. Njihova uloga je ograničena na lične podatke, čime se osigurava sigurnost i zaštita informacija unutar sistema.

## Korisničko upustvo

### Prijava na aplikaciju

Prilikom otvaranja aplikacije, korisniku se prikayuje početni ekran za prijavu u samu aplikaciju. Prijava je ista za sve tipove korisnika.

![image](https://github.com/user-attachments/assets/51daedf6-e418-4ce0-8df8-912532b70952)

Korisnik ima mogućnost izbora jezika za prijavu putem opcija smještenih u donjem lijevom dijelu forme.

Da bi korisnici pristupili aplikaciji, neophodno je da se prvo autentifikuju na sistem, tj. da se prijave. Za prijavu korisnici koriste odgovarajuće kredencijale u obliku korisničkog imena i lozinke. Korisnici sa ulogom kompanije i zaposleni kredencijale za prijavu dobijaju od administratora sistema, koji je zadužen za kreiranje naloga.

Nakon unosa kredencijala u odgovarajuća polja forme, korisnik treba da pritisne dugme "Login" kako bi izvršio prijavu. Ako su kredencijali ispravni, korisniku će biti prikazan prozor sa odgovarajućim funkcionalnostima koje su prilagođene tipu korisničkog naloga o čemu će biti više reči u narednim sekcijama.

Ako korisnik unese pogrešne kredencijale, biće mu prikazan odgovarajući dijalog koji ga obaveštava o neuspeloj prijavi (slika ispod).

![image](https://github.com/user-attachments/assets/a51b85e3-44d9-4bf2-9129-34911189b533)
