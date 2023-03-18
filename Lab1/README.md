##### C# – Laboratorijske vježbe

# 1. laboratorijska vježba

## 1. zadatak
Napisati program koji upisuje dva cjelobrojna broja i ispisuje rezultat dijeljenja ta dva
broja. Rezultat treba ispisati u sljedećim formatima (Currency, Integer, Scientific,
Fixed-point, General, Number, Hexadecimal).  
Prilikom upisa nekog podatka sa tipkovnice, podatak se učitava kao tip string, a ako
nam treba tip int moramo ga pretvoriti uz pomoć ugrađenih metoda.
Pripaziti da se obrade sve iznimke.

## 2. zadatak
Napisati program koji sadrži dvije varijable, jednu tipa int, a drugu tipa long u koju će
biti zapisana najveća moguća vrijednost za tip long. Varijablu tipa long treba
pridružiti varijabli tipa int, s tim da se obradi iznimka ako dođe do preljeva
(overflow).  
Pomoć: vidjeti [`checked`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/checked-and-unchecked) u MSDN.

## 3. zadatak
Napisati program za bankare koji ima deklariran pobrojani tip podataka u kojem se
nalaze vrste računa (Štednja, Tekući račun, Žiro račun). Unutar programa deklarirati
strukturu BankAccount koja će sadržavati tri varijable, broj računa, iznos na računu i
vrstu računa.  
Program treba deklarirati polje struktura BankAccount od 5 elemenata, te napraviti
izbornik koji će imati opcije upisa novog računa, i ispis svih računa. Za ispis svih
računa koristiti `foreach` iteraciju.
