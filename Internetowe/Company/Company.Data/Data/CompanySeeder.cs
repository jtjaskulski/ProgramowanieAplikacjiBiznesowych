using Company.Data.Models.CMS;
using Company.Data.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Data;

/// <summary>
/// Wypełnia pustą bazę danymi demonstracyjnymi sklepu i CMS.
/// Każda tabela jest uzupełniana tylko wtedy, gdy nie ma jeszcze wierszy,
/// więc ponowne uruchomienie aplikacji nie dubluje rekordów.
/// </summary>
public static class CompanySeeder
{
    public static void Seed(CompanyContext context)
    {
        using var transaction = context.Database.BeginTransaction();

        SeedPages(context);
        SeedNews(context);
        SeedCategories(context);
        context.SaveChanges();

        SeedProducts(context);
        context.SaveChanges();

        SeedOrders(context);
        SeedCartItems(context);
        context.SaveChanges();

        transaction.Commit();
    }

    private static void SeedPages(CompanyContext context)
    {
        if (context.Page.Any())
            return;

        context.Page.AddRange(
            Page(1, "Start", "Strona główna",
                "Company to sklep ze sprzętem komputerowym i elektroniką użytkową. " +
                "Sprzedajemy laptopy, smartfony, monitory i akcesoria z dostawą na terenie całej Polski.<br><br>" +
                "Poniżej znajdziesz aktualności, a w zakładce Sklep pełną ofertę pogrupowaną według kategorii."),
            Page(2, "Dostawa", "Dostawa i płatności",
                "Kurier InPost oraz odbiór osobisty w Skawinie i Warszawie. " +
                "Darmowa dostawa od 300 zł. Zamówienia złożone do 14:00 wychodzą tego samego dnia roboczego.<br><br>" +
                "Płatność: szybki przelew, BLIK, karta lub przy odbiorze."),
            Page(3, "Regulamin", "Regulamin sklepu",
                ""),
            Page(4, "Kariera", "Praca w Company",
                "Szukamy osób do magazynu, obsługi klienta i serwisu laptopów. " +
                "Praca stacjonarna w Skawinie, jedna zmiana, wdrożenie przy doświadczonym zespole.<br><br>" +
                "CV wysyłaj na praca@company-demo.pl z nazwą stanowiska w tytule.")
        );
    }

    private static void SeedNews(CompanyContext context)
    {
        if (context.News.Any())
            return;

        context.News.AddRange(
            News(1, "Nowa dostawa laptopów",
                "Do magazynu weszła wiosenna dostawa laptopów 14 i 16 cali. " +
                "W ofercie są modele biurowe z 16 GB RAM oraz dwie konstrukcje z kartą graficzną do pracy z wideo."),
            News(2, "Promocja na monitory 27\"",
                "Do końca miesiąca monitory 27 cali IPS są tańsze o 150–200 zł. " +
                "Promocja obejmuje sztuki z pełną gwarancją producenta, bez egzemplarzy powystawowych."),
            News(3, "Black Week w Company",
                "Przez tydzień obniżamy ceny słuchawek, dysków i zasilaczy. " +
                "Kody rabatowe nie łączą się z tą obniżką, a darmowa dostawa od 300 zł nadal obowiązuje."),
            News(4, "Darmowa dostawa od 300 zł",
                "Obniżyliśmy próg darmowej wysyłki kurierem z 500 do 300 zł. " +
                "Paczkomaty pozostają w stałej cenie 12,90 zł niezależnie od wartości koszyka."),
            News(5, "Odbiór osobisty w Warszawie",
                "Uruchomiliśmy punkt odbioru przy ul. Prostej 12. " +
                "Zamówienie złożone do 12:00 w dzień roboczy można odebrać następnego dnia po mailu z potwierdzeniem."),
            News(6, "Gwarancja do 36 miesięcy",
                "Do laptopów i monitorów można dokupić przedłużenie gwarancji o dodatkowy rok. " +
                "Opcja pojawia się na karcie produktu i jest doliczana do zamówienia jako osobna pozycja."),
            News(7, "Warsztaty składania PC",
                "W sobotę 12 kwietnia o 11:00 w Skawinie pokazujemy, jak złożyć komputer z części dostępnych w sklepie. " +
                "Liczba miejsc: 16. Zapisy pod adresem warsztaty@company-demo.pl."),
            News(8, "Nowy cennik akcesoriów",
                "Od czerwca ujednolicamy ceny kabli, ładowarek i etui. " +
                "Starsze, wyższe ceny znikają z kart produktów automatycznie po północy w dniu zmiany.")
        );
    }

    private static void SeedCategories(CompanyContext context)
    {
        if (context.Category.Any())
            return;

        context.Category.AddRange(
            Category("Laptopy", "Komputery przenośne do biura, nauki i gier."),
            Category("Smartfony", "Telefony z Androidem i iOS, od modeli codziennych po flagowce."),
            Category("Tablety", "Tablety do notatek, nauki i multimediów."),
            Category("Monitory", "Ekrany biurowe, graficzne i gamingowe."),
            Category("Audio", "Słuchawki, głośniki i zestawy do wideokonferencji."),
            Category("Akcesoria", "Etui, ładowarki, kable i drobne dodatki."),
            Category("Podzespoły", "Dyski, pamięci RAM, zasilacze i obudowy."),
            Category("Sieć", "Routery, przełączniki i karty sieciowe.")
        );
    }

    private static void SeedProducts(CompanyContext context)
    {
        if (context.Product.Any())
            return;

        var categories = context.Category.ToDictionary(c => c.Name, c => c.IdCategory);

        foreach (var (name, description) in MissingCategories(categories.Keys))
        {
            var category = Category(name, description);
            context.Category.Add(category);
            context.SaveChanges();
            categories[name] = category.IdCategory;
        }

        context.Product.AddRange(Catalog.Select(item => new Product
        {
            Code = item.Code,
            Name = item.Name,
            Price = item.Price,
            FotoURL = $"https://picsum.photos/seed/{item.Code}/480/360",
            Description = item.Description,
            IdCategory = categories[item.Category]
        }));
    }

    private static void SeedOrders(CompanyContext context)
    {
        if (context.Order.Any())
            return;

        var products = context.Product
            .AsNoTracking()
            .OrderBy(p => p.Code)
            .Select(p => new PricedProduct(p.IdProduct, p.Price))
            .ToList();

        if (products.Count == 0)
            return;

        var today = DateTime.Today;
        foreach (var draft in OrderDrafts)
        {
            var lines = draft.Lines
                .Select(line => (Product: products[line.ProductIndex % products.Count], line.Quantity))
                .ToList();

            var created = today.AddDays(-draft.DaysAgo).AddHours(draft.Hour);
            context.Order.Add(new Order
            {
                OrderDate = created,
                Login = draft.Login,
                FirstName = draft.FirstName,
                LastName = draft.LastName,
                Street = draft.Street,
                City = draft.City,
                Voivodeship = draft.Voivodeship,
                ZipCode = draft.ZipCode,
                Country = "Polska",
                PhoneNumber = draft.PhoneNumber,
                Email = draft.Email,
                Total = lines.Sum(line => line.Product.Price * line.Quantity),
                OrderPosition = lines.Select(line => new OrderPosition
                {
                    IdProduct = line.Product.Id,
                    Quantity = line.Quantity,
                    Price = line.Product.Price,
                    CreatedDate = created
                }).ToList()
            });
        }
    }

    private static void SeedCartItems(CompanyContext context)
    {
        if (context.CartItem.Any())
            return;

        var products = context.Product
            .AsNoTracking()
            .OrderBy(p => p.IdProduct)
            .Select(p => p.IdProduct)
            .ToList();

        if (products.Count == 0)
            return;

        var now = DateTime.Now;
        var carts = new (string Session, int[] ProductIndexes, decimal[] Quantities, int HoursAgo)[]
        {
            ("seed-sesja-anna", [0, 4, 8], [1m, 2m, 1m], 2),
            ("seed-sesja-piotr", [2, 11], [1m, 1m], 5),
            ("seed-sesja-biuro", [6, 14, 18, 21], [3m, 1m, 2m, 1m], 9),
            ("seed-sesja-marek", [9], [1m], 26),
            ("seed-sesja-ola", [3, 16, 24], [1m, 1m, 4m], 30)
        };

        foreach (var cart in carts)
        {
            for (var i = 0; i < cart.ProductIndexes.Length; i++)
            {
                context.CartItem.Add(new CartItem
                {
                    IdSessionOfCart = cart.Session,
                    IdProduct = products[cart.ProductIndexes[i] % products.Count],
                    Quantity = cart.Quantities[i],
                    CreatedDate = now.AddHours(-(cart.HoursAgo + i))
                });
            }
        }
    }

    private static IEnumerable<(string Name, string Description)> MissingCategories(IEnumerable<string> existing)
    {
        var present = existing.ToHashSet(StringComparer.Ordinal);
        foreach (var name in Catalog.Select(item => item.Category).Distinct())
        {
            if (!present.Contains(name))
                yield return (name, "Kategoria uzupełniona przez seeder.");
        }
    }

    private static Page Page(int order, string linkTitle, string title, string content) => new()
    {
        DisplayOrder = order,
        LinkTitle = linkTitle,
        Title = title,
        Content = content
    };

    private static News News(int order, string title, string content) => new()
    {
        DisplayOrder = order,
        LinkTitle = title,
        Title = title,
        Content = content
    };

    private static Category Category(string name, string description) => new()
    {
        Name = name,
        Description = description
    };

    private sealed record PricedProduct(int Id, decimal Price);

    private sealed record OrderLine(int ProductIndex, decimal Quantity);

    private sealed record OrderDraft(
        int DaysAgo,
        int Hour,
        string? Login,
        string FirstName,
        string LastName,
        string Street,
        string City,
        string Voivodeship,
        string ZipCode,
        string PhoneNumber,
        string Email,
        OrderLine[] Lines);

    private static readonly OrderDraft[] OrderDrafts =
    [
        new(1, 9, "anna.wisniewska", "Anna", "Wiśniewska", "ul. Długa 14/6", "Kraków", "małopolskie", "31-147", "+48 600 111 203", "anna.wisniewska@example.com",
            [new(0, 1m), new(20, 1m)]),
        new(2, 11, "piotr.zielinski", "Piotr", "Zieliński", "ul. Marszałkowska 88/12", "Warszawa", "mazowieckie", "00-514", "+48 501 220 118", "piotr.zielinski@example.com",
            [new(4, 1m), new(16, 2m), new(28, 1m)]),
        new(3, 15, null, "Katarzyna", "Lewandowska", "ul. 3 Maja 5", "Katowice", "śląskie", "40-096", "+48 512 334 907", "k.lewandowska@example.com",
            [new(8, 1m)]),
        new(5, 10, "marek.wojcik", "Marek", "Wójcik", "ul. Garbary 21", "Poznań", "wielkopolskie", "61-867", "+48 607 445 221", "marek.wojcik@example.com",
            [new(2, 1m), new(12, 1m)]),
        new(7, 13, "biuro.nova", "Ewa", "Kamińska", "ul. Legnicka 55", "Wrocław", "dolnośląskie", "54-203", "+48 71 350 10 22", "biuro@nova-demo.pl",
            [new(1, 4m), new(18, 4m), new(25, 2m)]),
        new(9, 8, null, "Tomasz", "Kaczmarek", "ul. Grunwaldzka 102/4", "Gdańsk", "pomorskie", "80-244", "+48 692 118 540", "tomasz.kaczmarek@example.com",
            [new(6, 1m), new(22, 1m)]),
        new(12, 16, "ola.adamska", "Aleksandra", "Adamska", "ul. Piotrkowska 77", "Łódź", "łódzkie", "90-423", "+48 535 672 014", "ola.adamska@example.com",
            [new(10, 1m), new(14, 1m), new(30, 3m)]),
        new(15, 12, "jan.nowak", "Jan", "Nowak", "ul. Krakowskie Przedmieście 9", "Lublin", "lubelskie", "20-002", "+48 81 441 22 10", "jan.nowak@example.com",
            [new(3, 1m)]),
        new(21, 18, null, "Magdalena", "Pawlak", "ul. Słowackiego 3/8", "Rzeszów", "podkarpackie", "35-060", "+48 788 230 661", "magdalena.pawlak@example.com",
            [new(7, 1m), new(19, 2m)]),
        new(28, 14, "szkola.nr4", "Barbara", "Sikora", "ul. Szkolna 4", "Olsztyn", "warmińsko-mazurskie", "10-001", "+48 89 522 11 40", "sekretariat@szkola4-demo.pl",
            [new(5, 6m), new(15, 6m), new(27, 6m)]),
        new(36, 9, "adam.mazur", "Adam", "Mazur", "ul. Wojska Polskiego 18", "Szczecin", "zachodniopomorskie", "70-471", "+48 604 909 332", "adam.mazur@example.com",
            [new(11, 1m), new(23, 1m)]),
        new(48, 17, null, "Natalia", "Król", "ul. 11 Listopada 2", "Białystok", "podlaskie", "15-234", "+48 85 740 09 18", "natalia.krol@example.com",
            [new(9, 1m), new(17, 1m), new(26, 2m), new(31, 1m)])
    ];

    private static readonly (string Category, string Code, string Name, decimal Price, string Description)[] Catalog =
    [
        ("Laptopy", "LAP-1401", "Laptop Office 14 i5", 3299.00m,
            "14-calowy laptop do biura. Procesor Intel Core i5, 16 GB RAM, dysk SSD 512 GB, matowa matryca Full HD i waga poniżej 1,4 kg."),
        ("Laptopy", "LAP-1402", "Laptop Office 14 Ryzen 5", 3099.00m,
            "Cichy laptop na Ryzenie 5 z 16 GB RAM. Dobrze sprawdza się przy arkuszach, przeglądarce i wideokonferencjach."),
        ("Laptopy", "LAP-1601", "Laptop Pro 16 i7", 5499.00m,
            "16 cali, Intel Core i7, 32 GB RAM i SSD 1 TB. Zapas mocy na kilka maszyn wirtualnych i większe projekty."),
        ("Laptopy", "LAP-1602", "Laptop Game 16 RTX", 6999.00m,
            "Laptop z kartą RTX, ekranem 165 Hz i podświetlaną klawiaturą. Do gier oraz montażu krótkich materiałów wideo."),
        ("Smartfony", "PHN-A01", "Smartfon Nova A 128 GB", 1499.00m,
            "Telefon na co dzień: ekran 6,5 cala, aparat 50 MP i bateria, która wytrzymuje pełny dzień pracy."),
        ("Smartfony", "PHN-A02", "Smartfon Nova B 256 GB", 2199.00m,
            "Wersja z podwójnym aparatem i 256 GB pamięci. Obsługuje ładowanie 33 W i dwie karty SIM."),
        ("Smartfony", "PHN-P01", "Smartfon Pixel Line 128 GB", 2899.00m,
            "Czysty system, mocny aparat i pięć lat aktualizacji. Dobry wybór, jeśli telefon ma zostać na dłużej."),
        ("Smartfony", "PHN-F01", "Smartfon Flagowiec 256 GB", 4599.00m,
            "Flagowiec z jasnym ekranem 120 Hz, szybkim ładowaniem i wodoszczelną obudową."),
        ("Tablety", "TAB-1001", "Tablet Note 10", 1799.00m,
            "Tablet 10,4 cala do notatek i filmów. Rysik jest w zestawie, a obudowa mieści się w mniejszym plecaku."),
        ("Tablety", "TAB-1101", "Tablet Study 11", 2399.00m,
            "11 cali, klawiatura w zestawie i 128 GB pamięci. Wygodny do zajęć online i czytania skryptów."),
        ("Tablety", "TAB-1201", "Tablet Draw 12", 3299.00m,
            "Ekran 12,4 cala o wysokiej rozdzielczości i rysik z małą latencją. Do szkiców i oznaczania PDF-ów."),
        ("Monitory", "MON-2401", "Monitor 24 cale IPS", 649.00m,
            "24 cale, matryca IPS, 75 Hz i cienkie ramki. Podstawowy ekran do biurka, z regulacją pochylenia."),
        ("Monitory", "MON-2701", "Monitor 27 cali IPS", 999.00m,
            "27 cali QHD, matryca IPS i stopka z regulacją wysokości. Wygodny przy arkuszach i kilku oknach naraz."),
        ("Monitory", "MON-2702", "Monitor 27 cali 144 Hz", 1299.00m,
            "Szybka matryca 144 Hz i czas reakcji 1 ms. Do gier oraz płynnego przewijania długich dokumentów."),
        ("Monitory", "MON-3201", "Monitor 32 cale 4K", 1899.00m,
            "Duży ekran 4K do zdjęć i pracy z tekstem. Złącza HDMI i DisplayPort, hub USB w stopce."),
        ("Audio", "AUD-H01", "Słuchawki nauszne BT", 349.00m,
            "Bezprzewodowe słuchawki z redukcją hałasu i 30 godzinami pracy. Składają się do torby."),
        ("Audio", "AUD-H02", "Słuchawki douszne ANC", 429.00m,
            "Douszne słuchawki z etui ładującym i trybem przepuszczania głosu. Sprawdzają się w biurze i w drodze."),
        ("Audio", "AUD-S01", "Głośnik konferencyjny", 259.00m,
            "Mały głośnik z mikrofonem do spotkań przy jednym stole. Łączy się przez USB-C albo Bluetooth."),
        ("Audio", "AUD-S02", "Zestaw soundbar", 599.00m,
            "Krótki soundbar pod monitor. Wyraźniejsze dialogi w filmach bez zajmowania miejsca na biurku."),
        ("Akcesoria", "ACC-C01", "Etui laptop 14 cali", 89.00m,
            "Sztywne etui z przegrodą na zasilacz. Mieści laptop 14 cali i cienki notatnik."),
        ("Akcesoria", "ACC-C02", "Plecak na laptop 16 cali", 189.00m,
            "Plecak z usztywnianą kieszenią na laptop 16 cali i osobną przegrodą na ładowarkę."),
        ("Akcesoria", "ACC-P01", "Ładowarka USB-C 65 W", 129.00m,
            "Jedna ładowarka do laptopa i telefonu. Kabel USB-C o długości 1,8 m jest w zestawie."),
        ("Akcesoria", "ACC-K01", "Kabel HDMI 2.0 2 m", 39.00m,
            "Kabel HDMI 2 metry, 4K 60 Hz. Do podłączenia laptopa z monitorem albo telewizorem."),
        ("Akcesoria", "ACC-M01", "Mysz bezprzewodowa", 79.00m,
            "Cicha mysz na baterii, z odbiornikiem chowanym w obudowie. Działa na większości powierzchni."),
        ("Podzespoły", "PC-SSD01", "Dysk SSD 1 TB NVMe", 329.00m,
            "Dysk NVMe 1 TB do laptopa i komputera stacjonarnego. Odczyt powyżej 3000 MB/s."),
        ("Podzespoły", "PC-SSD02", "Dysk SSD 2 TB NVMe", 549.00m,
            "2 TB na gry, zdjęcia i projekty. Radiator w zestawie, format M.2 2280."),
        ("Podzespoły", "PC-RAM01", "Pamięć RAM 16 GB DDR4", 189.00m,
            "Moduł 16 GB DDR4 3200 MHz. Do rozbudowy laptopa albo drugiego slotu w komputerze."),
        ("Podzespoły", "PC-RAM02", "Pamięć RAM 32 GB DDR5", 449.00m,
            "Kość 32 GB DDR5. Sensowny zapas, gdy komputer trzyma wiele kart przeglądarki i maszyny wirtualne."),
        ("Podzespoły", "PC-PSU01", "Zasilacz 650 W 80+", 399.00m,
            "Zasilacz 650 W z certyfikatem 80 Plus Bronze i odpinanymi kablami. Do zestawów z jedną kartą graficzną."),
        ("Podzespoły", "PC-CASE1", "Obudowa ATX z siatką", 279.00m,
            "Przewiewna obudowa ATX z panelem bocznym ze szkła i miejscem na chłodzenie z przodu."),
        ("Sieć", "NET-R01", "Router Wi-Fi 6", 349.00m,
            "Router dwuzakresowy Wi-Fi 6 do mieszkania. Cztery porty LAN i prosta aplikacja do konfiguracji."),
        ("Sieć", "NET-R02", "Router Wi-Fi 6 mesh", 699.00m,
            "Zestaw mesh na większe mieszkanie. Drugi punkt dokłada się bez przeciągania kabla przez korytarz."),
        ("Sieć", "NET-S01", "Przełącznik 8 portów", 119.00m,
            "Metalowy switch gigabitowy, 8 portów, bez wentylatora. Do biurka albo szafy w domu."),
        ("Sieć", "NET-U01", "Karta USB Wi-Fi 6", 99.00m,
            "Karta USB dla komputera, który nie ma wbudowanego Wi-Fi. Działa od razu po podłączeniu.")
    ];
}
