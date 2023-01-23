namespace ExchangeRatesApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var scraper = new FastWebScraper();
            string urlAddress = "https://www.nationalbank.kz/ru/exchangerates/ezhednevnye-oficialnye-rynochnye-kursy-valyut";
            WelcomeUser();
            var listCurrency = scraper.GetCurrencies(urlAddress);


            bool isWork = true;

            while (isWork)
            {
                PrintAllOptions();
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        PrintAllCurrency(listCurrency);
                        break;
                    case 2:
                        Console.Write("Введите валюту в короткой форме(напр: USD/EUR/RUB): ");
                        var value = Console.ReadLine().ToUpper();
                        Console.Write("Введите сумму: ");
                        var sum = double.Parse(Console.ReadLine());
                        ConvertCurrnecy(value, "KZT", sum, out double result);
                        Console.WriteLine($"Валюта {value} - Сумма: {sum}");
                        Console.WriteLine($"Валюта в KZT - Сумма: {result}");
                        break;
                    case 3:
                        Console.Write("Введите сумму(KZT): ");
                        var sum1 = double.Parse(Console.ReadLine());
                        Console.Write("Введите валюту в короткой форме(напр: USD/EUR/RUB): ");
                        var value1 = Console.ReadLine().ToUpper();
                        ConvertCurrnecyReverse(value1, "KZT", sum1, out double result1);
                        Console.WriteLine($"Валюта в KZT - Сумма: {sum1}");
                        Console.WriteLine($"Валюта {value1} - Сумма: {result1}");
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("Программа успешно завершена");
                        isWork = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Команда не распознана. Попробуйте ещё раз.");
                        break;

                }
            }

            void WelcomeUser()
            {
                string welcome = "*** Добро пожаловать в обменник валют ***";
                Console.WriteLine(new string('*', welcome.Length));
                Console.WriteLine(new string('*', welcome.Length));
                Console.WriteLine(welcome);
                Console.WriteLine(new string('*', welcome.Length));
                Console.WriteLine(new string('*', welcome.Length));
                //Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⢯⠙⠩⠀⡇⠊⠽⢖⠆⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠱⣠⠀⢁⣄⠔⠁⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠀⣷⣶⣾⣾⠀⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⢀⡔⠙⠈⢱⡟⣧⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⡠⠊⠀⠀⣀⡀⠀⠘⠕⢄⠀⠀⠀⠀⠀\r\n⠀⠀⠀⢀⠞⠀⠀⢀⣠⣿⣧⣀⠀⠀⢄⠱⡀⠀⠀⠀\r\n⠀⠀⡰⠃⠀⠀⢠⣿⠿⣿⡟⢿⣷⡄⠀⠑⢜⢆⠀⠀\n⠀⢰⠁⠀⠀⠀⠸⣿⣦⣿⡇⠀⠛⠋⠀⠨⡐⢍⢆⠀\n⠀⡇⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣦⡀⠀⢀⠨⡒⠙⡄\n⢠⠁⡀⠀⠀⠀⣤⡀⠀⣿⡇⢈⣿⡷⠀⠠⢕⠢⠁⡇\r\n⠸⠀⡕⠀⠀⠀⢻⣿⣶⣿⣷⣾⡿⠁⠀⠨⣐⠨⢀⠃\r\n⠀⠣⣩⠘⠀⠀⠀⠈⠙⣿⡏⠁⠀⢀⠠⢁⡂⢉⠎⠀\n⠀⠀⠈⠓⠬⢀⣀⠀⠀⠈⠀⠀⠀⢐⣬⠴⠒⠁⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀");

            }


            void PrintAllCurrency(List<Currency> allCurrency)
            {
                string dateOn = "Курс на " + allCurrency[0].Date.ToString("dd.MM.yyyy");
                Console.WriteLine(new string('*', dateOn.Length));
                Console.WriteLine(dateOn);
                Console.WriteLine(new string('*', dateOn.Length));
                for (int i = 0; i < allCurrency.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {allCurrency[i].FullName} {allCurrency[i].ShortName}  - {allCurrency[i].Value}(KZT)");
                }
            }

            void PrintAllOptions()
            {
                Console.WriteLine();
                Console.WriteLine(new string('*', 30));
                Console.WriteLine("1. Вывести все курсы валют");
                Console.WriteLine("2. Конвертировать в KZT");
                Console.WriteLine("3. Конвертировать из KZT");
                Console.WriteLine("4. Сохранить в log файл --ещё_не_дописано--");
                Console.WriteLine("5. Очистить консоль");
                Console.WriteLine("6. Выход");
                Console.WriteLine(new string('*', 30));
            }

            void ConvertCurrnecy(string value, string target, double sum, out double result)
            {
                double getShortNameValue = 0;
                foreach (var item in listCurrency)
                {
                    if (item.ShortName.Equals(value))
                    {
                        getShortNameValue = item.Value;
                        break;
                    }
                }
                result = getShortNameValue * sum;
            }

            void ConvertCurrnecyReverse(string value, string target, double sum, out double result)
            {
                double getShortNameValue = 0;
                foreach (var item in listCurrency)
                {
                    if (item.ShortName.Equals(value))
                    {
                        getShortNameValue = item.Value;
                        break;
                    }
                }
                result = Math.Round(sum / getShortNameValue, 2);
            }

        }

    }
}