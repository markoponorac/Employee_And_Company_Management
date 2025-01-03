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

### Podešavanja aplikacije

Svi korisnici u meniju imaju stavku _Podešavanja_ te se klikom na nju prikazuje dio za podešavanja. Podešavanja su organizovana u tri dijela od kojih će dva dijela koja su identična za sve korisnike biti prikazana u sledeće dvije sekcije a treći dio koji se razlikuje u zavisnosti od tipa naloga će biti obrađen u sekcijama posvećenim tim nalozima.

#### Opšta podešavanja

Svi korisnici imaju mogućnost da personalizuju aplikaciju prema svojim potrebama. Korisnici imaju mogućnost izbora jedne od četiri različite definisane teme u aplikaciji. Izbor teme se vrši klikom na dugme. Pored toga korisnici mogu i da izaberu jedan od dva definisana jezika: srpski i engleski. Sva izabrana podešavanja se čuvaju za svakog korisnika tako da se prilikom sledeceg pristupa svakog korisnika primjenjuju izabrana podešavanja. Sama forma za opšta podešavanja je prikazana na sledećoj slici:

![image](https://github.com/user-attachments/assets/66877d7b-3bdd-4c52-85df-20fa80dd1aca)

Primjer izgleda aplikacije u zavisnosti od izabrane teme:

* Plava tema:

![image](https://github.com/user-attachments/assets/a7acabe6-ab4a-4c88-9d30-8b68500c830d)

* Zelena tema:

![image](https://github.com/user-attachments/assets/625fb09c-8400-4166-85f7-5519980a6c17)

* Narandžasta tema:

![image](https://github.com/user-attachments/assets/1188b39e-375c-4554-a9d8-47e540497924)

* Ljubičasta tema:

![image](https://github.com/user-attachments/assets/6a04ff13-e59b-4219-9c08-35fb159be91e)

### Promjena lozinke

Svi korisnici aplikacije imaju mogućnost promjene svoje lozinke. Korisnici su dužni unijeti staru lozinku, radi potvrde autentičnosti, novu lozinku koju žele da postave te potvrditi novu lozinku kako bi bili sigurni da su unijeli lozinku koju žele. Nova lozinka se postavlja klikom na dugme _Sačuvaj lozinku_, nakon čega se korisnik obavještava o uspješnoj promijeni lozinke.



![image](https://github.com/user-attachments/assets/b675021d-d2a9-4a89-8d7c-b4183f2ddb6f)

U slučaju da je korisnik unio netačnu staru lozinku ili ako se ne poklapaju nove lozinke ili ako je nova i stara lozinka ista ili ako nova lozinka ima manje od osam karaktera, prikazuje se odgovarajuće obavještenje o neuspješnoj promjeni lozinke.

## Administratorski nalog

### Podešavanja administratorskog naloga

Administrator ima mogućnost da izvrši podešavanja svoj profila što uključuje promjenu imena i prezimena administratora. Izmjenjeni podaci se čuvaju klikom na dugme _Sačuvaj_, nakon čega se korisnik obavještava o uspješnoj promjeni podataka. 

![image](https://github.com/user-attachments/assets/49b36d8a-c14b-4a59-9d04-7c5fc008ec9c)

U slučaju da administrator ne unese oba podatka, prikazuje se odgovarajuće obavještenje o neuspješnoj promjeni podataka.

![image](https://github.com/user-attachments/assets/eb4c341f-2bbb-4036-9edc-d034a0e27982)

### Rad sa zaposlenima

Nakon prijave na sistem, administratoru se prikazuje prozor aplikacije koji se sastoji iz dva dijela, vertikalni meni za izbor odgovarajuće stranice i sam sadržaj stranice. Klikom na odgovarajuću stavku menija prikazuje se sadržaj vezan za tu stavku.

Nakon prijave na sistem, administratoru se prvo prikzuje dio za rad sa zaposlenima. Ova stranica se sastoji od tri taba koji omogućavaju pregled zaposlenih u zavisnosti od statusa njihovog profila (aktivni, blokirani i obrisani).

![image](https://github.com/user-attachments/assets/dc36f011-afec-40f8-a7bb-8bfe24e79c34)

Pored pregleda podataka administrator ima mogućnost pretrage zaposlenih po imenu, prezimenu ili korisničkom imenu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji aplikacije, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

![image](https://github.com/user-attachments/assets/4b056e84-ab7d-4644-b9ea-cd259a57ef40)

Administrator ima mogućnost manipulacije zaposlenima što uključuje blokiranje, aktiviranje, brisanje naloga zaposlenih kao i pregled detalja o zaposlenom.

Blokiranje naloga se vrši klikom na dugme _Blokiraj_ pri čemu se prikazuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/d6cf994e-f04e-4ffe-8cfa-432663ef151a)

Samo u slučaju da administrator klikne na dugme _Da_ dati zaposleni će biti blokiran.

U tabu za prikaz blokiranih zaposlenih se prikazuju svi nalozi zaposlenih koji su blokirani gdje administrator ima mogućnost aktivacije ili brisanja naloga.

![image](https://github.com/user-attachments/assets/f923b8ce-c9fc-4a81-a60b-a630c762bf10)

Aktiviranje naloga se vrši klikom na dugme _Aktiviraj_ pri čemu se prikazuje poruka za potvrdu aktivacije.

![image](https://github.com/user-attachments/assets/e6ca2fe1-17ee-4a80-80ec-f71ab959c39c)

Samo u slučaju da administrator klikne na dugme _Da_ dati zaposleni će biti ponovo aktiviran.

Brisanje naloga se vrši klikom na dugme _Obriši_ pri čemu se prikazuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/43aaead1-09a4-4b96-9b61-d3f25bc61a0a)

Samo u slučaju da administrator klikne na dugme _Da_ dati zaposleni će biti obrisan.

U tabu za prikaz obrisanih zaposlenih se prikazuju svi nalozi zaposlenih koji su obrisani gdje administrator ima mogućnost pregleda detalja o zaposlenom.

![image](https://github.com/user-attachments/assets/8eacb06b-95f2-43c1-879a-9aabe1823219)

Prikaz detalja o zaposlenom se vrši klikom na dugme _Detalji_ posle čega se otvara prozor za prikaz detalja o izabranom zaposlenom.

![image](https://github.com/user-attachments/assets/2289e946-10ad-4332-853d-8276f2be1fa4)

![Screenshot 2025-01-03 190424](https://github.com/user-attachments/assets/0448d459-a04e-49c0-ba8c-9921d0a3ac18)
