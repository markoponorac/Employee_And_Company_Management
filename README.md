# Employee And Company Management

## Uvod

Employee And Company Management je aplikacija koja omogućava efikasno upravljanje zaposlenima i organizacionom strukturom unutar kompanija. Osmišljena je da pojednostavi svakodnevne zadatke vezane za vođenje evidencije i organizaciju, pružajući ugodno korisničko iskustvo. Riječ je o desktop aplikaciji razvijenoj u C# programskom jeziku uz korištenje WPF (Windows Presentation Foundation) razvojnog okvira. Aplikacija koristi MySQL bazu podataka za čuvanje svih podataka. Za upotrebu aplikacije potreban je desktop ili laptop računar sa Windows operativnim sistemom i minimalnim hardverskim specifikacijama.

### Korisnički nalozi

Sama aplikacija Employee And Company Management je osmišljena tako da podržava tri korisničke uloge: administrator, kompanija i zaposlenoi. Svaka od ovih uloga ima specifične odgovornosti i pristup funkcionalnostima aplikacije, prilagođen njihovim potrebama.

* Administrator ima ključnu ulogu u radu sistema. Njegova odgovornost uključuje kreiranje novih kompanija u sistemu, upravljanje postojećim kompanijama kroz aktivaciju, suspendovanje ili brisanje, kao i kreiranje i administraciju korisničkih naloga za zaposlene. Pored toga, administrator je zadužen za upravljanje stručnim spremama zaposlenih. Ove aktivnosti omogućavaju nesmetano funkcionisanje aplikacije i pružaju osnovu za rad drugih korisničkih uloga.

* Korisnici sa ulogom kompanije predstavljaju menadžment ili administrativno osoblje zaduženo za internu organizaciju i upravljanje procesima unutar kompanije. Oni koriste aplikaciju za kreiranje i zaključivanje zaposlenja, upravljanje organizacionom strukturom koja uključuje odeljenja i radna mesta, te imaju mogućnost pregleda podataka o zaposlenima i njihovim angažmanima.

* Zaposleni su korisnici aplikacije koji imaju pristup informacijama vezanim za njihovo radno angažovanje. Oni mogu pregledati istoriju svojih zaposlenja i pregledati evidenciju isplaćenih plata uz dodatne mogućnosti filtriranja i sortiranja. Njihova uloga je ograničena na lične podatke, čime se osigurava sigurnost i zaštita informacija unutar sistema.

## Korisničko uputstvo

### Prijava na aplikaciju

Prilikom otvaranja aplikacije, korisniku se prikazuje početni ekran za prijavu u samu aplikaciju. Prijava je ista za sve tipove korisnika.

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

![image](https://github.com/user-attachments/assets/4591f49e-1808-4013-8671-6fa26256e351)

Primjer izgleda aplikacije u zavisnosti od izabrane teme:

* Plava tema:

![image](https://github.com/user-attachments/assets/1496597c-b039-41d7-bbf9-ab65af2e37dd)

* Zelena tema:

![image](https://github.com/user-attachments/assets/0a7c816a-d8e6-4b9c-806c-92a5468b3dd2)

* Narandžasta tema:

![image](https://github.com/user-attachments/assets/4194e110-6c0f-4007-9c5b-d2244b995e2d)

* Ljubičasta tema:

![image](https://github.com/user-attachments/assets/c2463f17-1bf9-4557-a461-74146b6641ae)

### Promjena lozinke

Svi korisnici aplikacije imaju mogućnost promjene svoje lozinke. Korisnici su dužni unijeti staru lozinku, radi potvrde autentičnosti, novu lozinku koju žele da postave te potvrditi novu lozinku kako bi bili sigurni da su unijeli lozinku koju žele. Nova lozinka se postavlja klikom na dugme _Sačuvaj lozinku_, nakon čega se korisnik obavještava o uspješnoj promijeni lozinke.

![image](https://github.com/user-attachments/assets/ab7dc16c-3127-4983-8a78-5e869d932217)

U slučaju da je korisnik unio netačnu staru lozinku ili ako se ne poklapaju nove lozinke ili ako je nova i stara lozinka ista ili ako nova lozinka ima manje od osam karaktera, prikazuje se odgovarajuće obavještenje o neuspješnoj promjeni lozinke.

## Administratorski nalog

### Podešavanja administratorskog naloga

Administrator ima mogućnost da izvrši podešavanja svog profila što uključuje promjenu imena i prezimena administratora. Izmjenjeni podaci se čuvaju klikom na dugme _Sačuvaj_, nakon čega se administrator obavještava o uspješnoj promjeni podataka. 

![image](https://github.com/user-attachments/assets/5179b457-59bd-4bf0-84f0-37a7897040b6)

U slučaju da administrator ne unese oba podatka, prikazuje se odgovarajuće obavještenje o neuspješnoj promjeni podataka.

![image](https://github.com/user-attachments/assets/eb4c341f-2bbb-4036-9edc-d034a0e27982)

### Rad sa zaposlenima

Nakon prijave na sistem, administratoru se prikazuje prozor aplikacije koji se sastoji iz dva dijela, vertikalni meni za izbor odgovarajuće stranice i sam sadržaj stranice. Klikom na odgovarajuću stavku menija prikazuje se sadržaj vezan za tu stavku.

Nakon prijave na sistem, administratoru se prvo prikzuje dio za rad sa zaposlenima. Ova stranica se sastoji od tri taba koji omogućavaju pregled zaposlenih u zavisnosti od statusa njihovog profila (aktivni, blokirani i obrisani). Podrazumjevano je otvoren tab za prikaz aktivnih kompanija.

![image](https://github.com/user-attachments/assets/41bbe368-156b-4b7a-ad16-141a035cdbc5)

Pored pregleda podataka administrator ima mogućnost pretrage zaposlenih po imenu, prezimenu ili korisničkom imenu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

![image](https://github.com/user-attachments/assets/f1230374-0646-474f-8f75-1c716dba35f1)

Administrator ima mogućnost manipulacije zaposlenima što uključuje blokiranje, aktiviranje, brisanje naloga zaposlenih kao i pregled detalja o zaposlenom te dodavanje novog zaposlenog u sistem.

#### Dodavanje novog zaposlenog

Dodavanje novog zaposlenog se vrši klikom na dugme _Dodaj zaposlenog_ nakon čega se prikazuje prozor za dodavanje novog zaposlenog.

![image](https://github.com/user-attachments/assets/cb5098e5-0514-46ee-9f6d-4ae404feb047)

Od administratora se zahtjeva da unese sve potrebne podatke te klikom na dugme _Sačuvaj_ se vrši dodavanje novog zaposlenog nakon čega se prikazuje poruka o uspješnom dodavanju zaposlenog, a u spurotnom se prikazuje odgovarajuća poruka o neuspješnom dodavanju zaposlenog.

#### Blokiranje, aktiviranje, brisanje i prikaz detalja zaposlenog

Blokiranje zaposlenog se vrši klikom na dugme _Blokiraj_ pri čemu se prikazuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/d6cf994e-f04e-4ffe-8cfa-432663ef151a)

Samo u slučaju da administrator klikne na dugme _Da_ zaposleni će biti blokiran.

U tabu za prikaz blokiranih zaposlenih se prikazuju svi nalozi zaposlenih koji su blokirani gdje administrator ima mogućnost aktivacije ili brisanja naloga.

![image](https://github.com/user-attachments/assets/f76aca5d-6ffa-418f-b98d-df9eb8ac8765)

Aktiviranje zaposlenog se vrši klikom na dugme _Aktiviraj_ pri čemu se prikazuje poruka za potvrdu aktivacije.

![image](https://github.com/user-attachments/assets/e6ca2fe1-17ee-4a80-80ec-f71ab959c39c)

Samo u slučaju da administrator klikne na dugme _Da_ zaposleni će biti aktiviran.

Brisanje zaposlenog se vrši klikom na dugme _Obriši_ pri čemu se prikazuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/43aaead1-09a4-4b96-9b61-d3f25bc61a0a)

Samo u slučaju da administrator klikne na dugme _Da_ zaposleni će biti obrisan.

U tabu za prikaz obrisanih zaposlenih se prikazuju svi nalozi zaposlenih koji su obrisani gdje administrator ima mogućnost pregleda detalja o zaposlenom. Detalje o zaposlenom administrator može da pregleda na isti način i iz pregleda aktivnih zaposlenih.

![image](https://github.com/user-attachments/assets/dda5d125-3dcb-48f6-b278-3d49a28f4885)

Prikaz detalja o zaposlenom se vrši klikom na dugme _Detalji_ posle čega se otvara prozor za prikaz detalja o izabranom zaposlenom.

![image](https://github.com/user-attachments/assets/e1580240-15ae-4485-9a53-e3c15ae79607)

### Rad sa kompanijama

Klikom na stavku menija _Kompanije_, administratoru se prikzuje dio za rad sa kompanijama. Ova stranica se sastoji od tri taba koji omogućavaju pregled kompanija u zavisnosti od njihovog status (aktivne kompanije, blokirane kompanije i obrisane kompanije). Podrazumjevano je otvoren tab za prikaz aktivnih kompanija. 

![image](https://github.com/user-attachments/assets/246aafb1-6573-43c8-88bb-e17903bb8c9d)

Pored pregleda podataka administrator ima mogućnost pretrage kompanija po nazivu ili korisničkom imenu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

![image](https://github.com/user-attachments/assets/87670fac-9b37-4b05-a537-aa5296739eee)

Administrator ima mogućnost manipulacije kompanijama što uključuje blokiranje, aktiviranje, brisanje naloga kompanija kao i pregled detalja o kompaniji te dodavanje nove kompanije u sistem.

#### Dodavanje nove kompanije

Dodavanje nove kompanije se vrši klikom na dugme _Dodaj kompaniju_ nakon čega se prikazuje prozor za dodavanje nove kompanije.

![image](https://github.com/user-attachments/assets/617fe682-c85e-42a8-9869-17eaf6219068)

Od administratora se zahtjeva da unese sve potrebne podatke te klikom na dugme _Sačuvaj_ se vrši dodavanje nove kompanije nakon čega se prikazuje poruka o uspješnom dodavanju kompanije, a u spurotnom se prikazuje odgovarajuća poruka o neuspješnom dodavanju kompanije.

#### Blokiranje, aktiviranje, brisanje i prikaz detalja kompanije

Blokiranje kompanije se vrši klikom na dugme _Blokiraj_ pri čemu se prikazuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/028121d9-d4e6-4d7d-8c2b-04931c378c58)

Samo u slučaju da administrator klikne na dugme _Da_ kompanija će biti blokirana.

U tabu za prikaz blokiranih kompanija se prikazuju svi nalozi kompanija koji su blokirani gdje administrator ima mogućnost aktivacije ili brisanja naloga.

![image](https://github.com/user-attachments/assets/811f799b-acef-4b78-934a-5a14d6919690)

Aktiviranje kompanije se vrši klikom na dugme _Aktiviraj_ pri čemu se prikazuje poruka za potvrdu aktivacije.

![image](https://github.com/user-attachments/assets/1ebd50f8-0ae1-4919-9182-cfe28d985cc4)

Samo u slučaju da administrator klikne na dugme _Da_ kompanija će biti aktivirana.

Brisanje kompanije se vrši klikom na dugme _Obriši_ pri čemu se prikazuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/e06b40ca-1ebf-479a-94f6-3330469c0f48)

Samo u slučaju da administrator klikne na dugme _Da_ kompanija će biti obrisana.

U tabu za prikaz obrisanih kompanija se prikazuju svi nalozi kompanija koji su obrisani gdje administrator ima mogućnost pregleda detalja o kompaniji. Detalje o kompaniji administrator može da pregleda na isti način i iz pregleda aktivnih kompanija.

![image](https://github.com/user-attachments/assets/59f6c003-9359-4d38-a0ea-90678f285157)

Prikaz detalja o kompaniji se vrši klikom na dugme _Detalji_ posle čega se otvara prozor za prikaz detalja o izabranoj kompaniji.

![image](https://github.com/user-attachments/assets/085d37a6-f550-4518-835c-3e7c5c35b692)

### Rad sa stručnim spremama

Klikom na stavku menija _Stručne spreme_, administratoru se prikzuje dio za rad sa stručnim spremama. Ova stranica omogućava pregled stručnih sprema te dodavanje nove stručne spreme.

![image](https://github.com/user-attachments/assets/fc16e4d0-ff0e-41dd-bf2f-737470501027)

Pored pregleda podataka administrator ima mogućnost pretrage stručnih sprema po nazivu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

![image](https://github.com/user-attachments/assets/38a60236-4e9b-41ec-a3e3-989de8744064)

#### Dodavanje nove stručne spreme

Dodavanje nove stručne spreme se vrši klikom na dugme _Dodaj stručnu spremu nakon čega se prikazuje prozor za dodavanje nove stručne spreme.

![image](https://github.com/user-attachments/assets/3872be45-d65d-4432-b167-fade8e5897ae)

Od administratora se zahtjeva da unese sve potrebne podatke te klikom na dugme _Sačuvaj_ se vrši dodavanje nove stručne spreme nakon čega se prikazuje poruka o uspješnom dodavanju kompanije, a u spurotnom se prikazuje odgovarajuća poruka o neuspješnom dodavanju stručne spreme.

## Nolog kompanije

### Podešavanja naloga kompanije

Kompanija ima mogućnost da izvrši podešavanja svog profila što uključuje promjenu adrese kompanije. Izmjenjeni podaci se čuvaju klikom na dugme _Sačuvaj_, nakon čega se korisnik obavještava o uspješnoj promjeni podataka. 

![image](https://github.com/user-attachments/assets/f012e4a7-ddc7-41ea-92a2-660cfbbd8dd5)

U slučaju da administrator ne unese podatke, prikazuje se odgovarajuće obavještenje o neuspješnoj promjeni podataka.

### Rad sa zaposlenima

Nakon prijave na sistem, korisniku sa ulogom kompanije se prikazuje prozor aplikacije koji se sastoji iz dva dijela, vertikalni meni za izbor odgovarajuće stranice i sam sadržaj stranice. Klikom na odgovarajuću stavku menija prikazuje se sadržaj vezan za tu stavku.

Nakon prijave na sistem, korisniku sa ulogom kompanije se prvo prikzuje dio za rad sa zaposlenima. Ova stranica se sastoji od dva taba koji omogućavaju pregled trenutno zposlenih radnika i bivših zaposlenih u toj kompaniji. Podrazumjevano je otvoren tab za prikaz trenutno zaposlenih radnika.

![image](https://github.com/user-attachments/assets/de93ab26-b0bc-427c-84d1-b7255434405d)

Pored pregleda podataka korisnik sa ulogom kompanije ima mogućnost pretrage zaposlenih po imenu, prezimenu ili korisničkom imenu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

Korisniku sa ulogom kompanije ima mogućnost zapošljavanja (dodavanja) novog zaposlenog, otpuštanje zaposlenog, pregled detalja te upravljanje platama zaposlenog.

U prikazu bivših zaposlenih je moguće vidjeti sve bivše zaposlene u kompaniji te vijedjeti detalje o njihovim zaposlenjima i platama koje su imali tokom zaposlenja.

#### Dodavanje novog zaposlenog

Dodavanje novog zaposlenog se vrši klikom na dugme _Dodaj zaposlenog_ nakon čega se prikazuje prozor za dodavanje novog zaposlenog.

![image](https://github.com/user-attachments/assets/26e1daa7-0100-49b2-bcc5-4d78572b5001)

U ovom przoru se prikazuju svi radnici koji mogu biti zaposleni te klikom na dugme zaposli otvara se prozor za zapošljavanje konkretnog radnika. Pored pregleda podataka moguće je vršiti pretragu zaposlenih po imenu ili prezimenu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

![image](https://github.com/user-attachments/assets/98ae1a52-cffb-49e6-8beb-2439196af518)

Od korisnika se zahtjeva unos svih potrebnih podataka, te se klikom na dugme _Sačuvaj_ vrši zapošljavanje radnika pri čemu korisnik dobija obavještenje o uspješnom zapošljavanju radnika. Ukoliko postoji problem pri zapošljavanju radnika prikazuje se odgovarajuće obavještenje.

#### Otpuštanje zaposlenog

Otpuštanje zaposlenog se vrši klikom na dugme _Otpusti zaposlenog_ pri čemu se otvara prozor za unos datuma otpuštanja.

![image](https://github.com/user-attachments/assets/687e6d26-eda3-48e1-aa01-09c9bf32080a)

Naokn unosa datuma klikom na dugme _Otpusti zaposlenog_ se prikazuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/6eacf155-52d4-439d-a7e0-850b6885a03d)

Samo ako korisnik klikne na dugme _Da_ zaposleni će biti otpušten.

#### Pregled detalja zaposlenog

Klikom na dugme _Detalji_ se otvara prozor sa prikazom osnovnoh podataka o zaposlenom i o njegovim zaposlenjima u okviru date kompanije. 

![image](https://github.com/user-attachments/assets/b576e2b3-7dda-43be-b0fa-30e1e8b2b71e)

#### Upravljanje platama zaposlenog

Klikom na dugme _Plate_ se otvara prozor u kome su prikazane sve plate datog radnika za izabrano zaposlenje gdje je moguće dodati platu za zaposlenog.

![image](https://github.com/user-attachments/assets/046e30ea-5f73-46a7-9e7d-3ec2658be08b)

Klikom na dugme _Dodaj platu_ se otvara prozor za dodavanje nove plate.

![image](https://github.com/user-attachments/assets/25d6dc3d-e332-4c69-ad91-f752e4e8e253)

Od korisnika se zahtjeva da unese sve potrebne podatke te klikom na dugme _Sačuvaj_ se vrši dodavanje nove plate i korisniku se prikazuje obavještenje o uspješno dodatoj plati. Ukoliko nije moguće dodati platu prikazuje se odgovarajuće obavještenje.

### Rad sa odjeljenjima kompanije

Klikom na stavku menija _Odjeljenja_, korisniku sa ulogom kompanije se prikzuje dio za rad sa odjeljenjima kompanije. Ova stranica se sastoji od dva taba koji omogućavaju pregled aktivnih i obrisanih odjeljenja kompanije kao i manipulaciju odjeljenjima kompanije. Podrazumjevano je otvoren tab za prikaz aktivnih odjeljenja.

![image](https://github.com/user-attachments/assets/b0897f88-56bb-4969-ab93-275c6781a8af)

Pored pregleda podataka korisnik sa ulogom kompanije ima mogućnost pretrage odjeljenja po nazivu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

#### Dodavanje odjeljenja

Klikom na dugme _Dodaj odjeljenje_ se otvara prozor za dodavanje novog odjeljenja kompanije.

![image](https://github.com/user-attachments/assets/75b198ec-4c56-4a20-a73c-c685c0ae330f)

Od korisnika se zahtjeva da unese potrebne podatke te se klikom na dugme _Sačuvaj_ odjeljenje dodaje a korisniku se prikazuje odgovarajuće obavještenje. U slučaju da nije moguće dodati odjeljenje korisniku se prikazuje odgovarajuća poruka.

#### Brisanje i obnavljanje odjeljenja

Korisnik ima mogućnost brisanja odjeljenja klikom na dugme _Obriši_ pri čemu se prikauzuje poruka za potvrdu brisanja.

![image](https://github.com/user-attachments/assets/9b492d11-0947-45a9-b656-d8499af0c2ee)

Samo ako korisnik klikne na dugme _Da_ dato odjeljenje se briše.

Korisnik iz pregleda obrisanih odjeljenja ima mogućnost obnove odjeljanj tj. ponistavanja aktivnosti brisanja.

![image](https://github.com/user-attachments/assets/f5726645-1c61-439c-9edb-6d9476af9cae)

Klikom na dugme obnovi korisniku se prikazuje poruka za potvrdu obnove i ako korisnik klikne na dugme _Da_ odjeljenje će biti obnovljeno.

### Rad sa radnim mjestima u kompaniji

Klikom na stavku menija _Radna mjesta_, korisniku sa ulogom kompanije se prikzuje dio za rad sa radnim mjestima u kompaniji. Ova stranica se sastoji od dva taba koji omogućavaju pregled aktivnih i obrisanih radnih mjesta u kompaniji kao i manipulaciju istim. Podrazumjevano je otvoren tab za prikaz aktivnih radnih mjesta.

![image](https://github.com/user-attachments/assets/cd21bfd1-85e0-4923-a553-e017fcec8c29)

Korisnik ima mogućnost izbora odjeljenja za koje zeli da pregleda radna mjesta što se radi pomoću padjuće liste odjeljenja u gornjem dijelu forme. U listi su prikazana sva trenutno aktivna odjeljenja komapanije.

![image](https://github.com/user-attachments/assets/221acb58-729d-4f78-a0ea-8e6d0f9ccaed)

Pored pregleda podataka korisnik ima mogućnost pretrage radnih mjesta po nazivu. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

#### Dodavanje radnih mjesta

Klikom na dugme _Dodaj radno mjesto_ se otvara prozor za kreiranje novog radnog mjesta u kompaniji.

![image](https://github.com/user-attachments/assets/c7ce7ee7-9910-427c-85a9-aa6989b630c2)

Od korisnika se zahtjeva da izabere odjeljenje kome će da pripada radno mjesto, te naziv radnog mjesta i opis koji je opcion. Klikom na dugme _Sačuvaj_ radno mjesto se dodaje a korisniku se prikazuje obavještenje o uspjesnom dodavanju radnog mjesta. U slučaju da nije moguće dodati radno mjesto korisniku se prikazuje odgovarajuće obavještenje.

#### Brisanje i obnavljanje radnih mjesta

U pregledu aktivnih radnih mjesta korisnik ima mogućnost brisanja radnog mjesta klikom na dugme _Obriši_ pri čemu se prikazuje odgovarajuća poruka za potvrdu brisanja. Ukoliko korisnik potvrdi brisanje, dato radno mjesto se briše.

U pregledu obrisanih radnih mjesta korisnik ima mogućnost obnove tj. poništavanja brisanja radnog mjesta klikom na dugme _Obnovi_  pri čemu se prikazuje odgovarajuća poruka za potvrdu obnove. Ukoliko korisnik potvrdi obnovu, dato radno mjesto se aktivira.

## Nalog zaposlenog

### Podešavanja naloga zaposlenog

Zaposleni ima mogućnost da izvrši podešavanja svog profila što uključuje promjenu imena i prezimena. Izmjenjeni podaci se čuvaju klikom na dugme _Sačuvaj_, nakon čega se korisnik obavještava o uspješnoj promjeni podataka. 

![image](https://github.com/user-attachments/assets/aba78679-50fa-4d67-b3c3-6905adc11fda)

U slučaju da zaposleni ne unese oba podatka, prikazuje se odgovarajuće obavještenje o neuspješnoj promjeni podataka.

### Rad sa zaposlenjima

Nakon prijave na sistem, zaposlenom se prikazuje prozor aplikacije koji se sastoji iz dva dijela, vertikalni meni za izbor odgovarajuće stranice i sam sadržaj stranice. Klikom na odgovarajuću stavku menija prikazuje se sadržaj vezan za tu stavku.

Nakon prijave na sistem, zaposlenom se prikazuje dio za rad sa zaposlenjima. Ova stranica se sastoji od tabele koja omogućava pregled svih zaposlenja tog korisnika.

![image](https://github.com/user-attachments/assets/79b727e4-4c72-4b37-92b2-10720df88f01)

Pored pregleda podataka zaposleni ima mogućnost pretrage zaposlenja po nazivu kompanije, nazivu radnog mjesta ili nazivu odjeljenja. Tekst za pretragu se unosu u _textbox-u_ u gornjoj sekciji forme, pri čemu su rezultati pretrage trenutno vidljivi u tabeli.

![image](https://github.com/user-attachments/assets/efc71e28-0ba7-426d-8c7c-7e24116d4ef7)

Pored pregleda zaposlenja je moguće pregledati i sve plate koje su vezane za svako pojedinačno zaposlenje. Klikom na dugme _Plate_ otvara se prozor u kome se prikazuju plate za izabrano zaposlenje.

![image](https://github.com/user-attachments/assets/ffbff9e4-da82-4571-bef5-eff84f0f6856)
