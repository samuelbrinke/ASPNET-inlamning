# ASPNET-inlamning

### ASP.NET CORE
ASP.NET CORE är ett stort framework som är byggt utav Microsoft som är till för att bygga snabba och kraftfulla webapplikationer.

### wwwroot
I wwwroot mappen hittar man statiska filer som man inte ändrar dynamiskt. I denna mappen finns det css filer js filer, favicon och librarys som t.ex bootstrap.
Bootstrap kommer till när man skapar ett projekt med ASP.NET

### startup.cs
I startup.cs filen hittar man appens services. En service är en återanvändbar komponent som tillbringar appfunktionalitet. Services registreras i ConfigureServices metoden och kommer
tillbringas till hela appen via dependency injection eller ApplicationServices.
Configure metoden bygger våran själva pipeline. Här ställer du in hur applikationen ska bete när den får in requests med hjälp utav middlewares.

### program.cs
Program.cs är det absolut första som startas när projektet startas upp. Här i program.cs säger vi vad som ska göras när applikationer startas. När man skapar en tom template så
kan vi t.ex. se att programmet hoppar till startup.cs filen.

## Razor Pages
I razor pages har vi 2 st filer som hänger ihop i varandra. t.ex. Index sidan har en fil "mapp" som är content page och Index.cshtml.cs som är page modeln.

### Content page
I Content pagen är var all html kod hamnar och det är vad vi ser i webbläsaren när vi skickar en request till att få från servern. Men skillnaden mellan en vanlig html fil och en
razor page är att razor pagen kan hantera razor syntax kod. Så tektiskt sätt så skulle vi kunna göra allt som händer i bakgrunden på sidan inuti content pagen också.

### Page model
I page modeln sköter det som händer i bakgrunden. Här kan vi skicka reguest om att få data från databasen, skicka data till databasen osv.

## MVC
I MVC templaten från ASP.NET får vi lite flera filer och mappar att hålla reda på. När man skapar ett MVC projekt med ASP.NET så får vi 3st filer, en model fil, en view fil och en controller fil.

I model filen är var vi skapar data strukturen till databasen. Här bestämmer vi vad som ska kunnas skickas, ta emot, ändras eller tas bort i databasen.

I view filen är vad all html kod hamnar. Här bygger vi upp layouten till sidan.

I Controller filen sköter hanteringen från t.ex. användarens inputs.

## Bra att veta
Jag fick strul under inlämningens gång så jag gjorde en helt nytt repository och använde projektet som jag fick strul med som en referens när jag började om. Det är därför det ser ut som att jag började igår :)

Jag lyckades inte riktigt få till en asp-page="" till länken för att visa sina events som man har deltagit i efter man har gått med i ett event så det fick bli en "hårdkodat" länk.
