using Lab4Ivt2;
using static Lab4Ivt2.laboratory_func;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("1) Все символы в тексте");
        Console.WriteLine("2) Пронумеровать слова");
        Console.WriteLine("3) Перевернуть предложение");
        Console.WriteLine("4) Найти предложения которые заканчиваются .com. Вывести предложения с наименьшим кол-во пробелов");
        Console.WriteLine("5) Слова которые начинаются с большой буквы и кочаются двумя цифрами");
        Console.WriteLine("6) Перевести string математическое выражение в int");
        Console.WriteLine("7) Посчитать сумму длин всех песен, показать самую маленькую и длинную песню. Показать песни у которых минимальное различие");
        Console.WriteLine("8) Шифратор и дешифратор текста");
        Console.WriteLine("9) Отсеять названия для переменных");
        Console.WriteLine("10) Регулярное выражение");
        Console.Write("Номер: ");

        int user_choice = int.Parse(Console.ReadLine());

        switch (user_choice)
        {
            case 1:
                Console.WriteLine("Введите текст: ");
                string case_1_input = Console.ReadLine();

                laboratory_func.SymbolsFunctions SymbolsFunctions = new laboratory_func.SymbolsFunctions();

                SymbolsFunctions.find_symbols(case_1_input);
                Console.WriteLine();
                SymbolsFunctions.find_symbols_withFunction(case_1_input);

                break;
            case 2:
                Console.WriteLine("Введите текст: ");
                string case_2_input = Console.ReadLine();

                laboratory_func.WordFunctions WordFunctions = new laboratory_func.WordFunctions();


                WordFunctions.numerate_words(case_2_input);
                Console.WriteLine();


                WordFunctions.numerate_words_withFunc(case_2_input);


                break;

            case 3:
                Console.WriteLine("Введите текст: ");
                string case_3_input = Console.ReadLine();

                laboratory_func.SentenceFunctions SentenceFunctions = new laboratory_func.SentenceFunctions();

                SentenceFunctions.reverse_sentence(case_3_input);
                Console.WriteLine();



                SentenceFunctions.reverse_sentence_withFunc(case_3_input);

                break;

            case 4:
                string[] case_4_input = new string[7];
                
                for (int i = 0; i < 7; i++)
                {
                    Console.Write($"{i + 1})");
                    case_4_input[i] = (Console.ReadLine());
                }


                laboratory_func.FindingSentence FindingSentence = new laboratory_func.FindingSentence();

                FindingSentence.com_finder(case_4_input);
                Console.WriteLine();



                FindingSentence.com_finder_withMethods(case_4_input);

                break;

            case 5:
                Console.WriteLine("Введите текст:");
                string case_5_input = Console.ReadLine();

                laboratory_func.FilterForUsernames FilterForUsernames = new laboratory_func.FilterForUsernames();

                FilterForUsernames.filterUsernames(case_5_input);
                Console.WriteLine();



                FilterForUsernames.filterUsername_withRegex(case_5_input);

                break;

            case 6:
                Console.WriteLine("Ваше матем. выражение: ");
                string case_6_input = Console.ReadLine();
                
                laboratory_func.TransformMathem breakDown = new laboratory_func.TransformMathem();

                breakDown.Transform_withRegex(case_6_input);


                break;

            case 7:

                string[] case_7_input =
                {
                    "1. Gentle Giant – Free Hand [6:15]",
                    "2. Supertramp – Child Of Vision [07:27]",
                    "3. Camel – Lawrence [10:46]",
                    "4. Yes – Don’t Kill The Whale [3:55]",
                    "5. 10CC – Notell Hotel [04:58]",
                    "6. Nektar – King Of Twilight [4:16]",
                    "7. The Flower Kings – Monsters & Men [21:19]",
                    "8. Focus – Le Clochard [1:59]",
                    "9. Pendragon – Fallen Dream And Angel [5:23]",
                    "10. Kaipa – Remains Of The Day (08:02)"

                };


                laboratory_func.Playlist_counter Playlist_counter = new laboratory_func.Playlist_counter();

                Playlist_counter.time_counter(case_7_input);


                break;

            case 8:
                Console.WriteLine("Выбери шифр: ");
                Console.WriteLine("1) Шифр Полибия");
                Console.WriteLine("2) Шифр Гронсфельда");
                Console.WriteLine("3) Книжный шифр");

                int cypherChoice;
                if (!int.TryParse(Console.ReadLine(), out cypherChoice) || cypherChoice < 1 || cypherChoice > 3)
                {
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
                }

                Console.WriteLine("Введите текст для шифрования/дешифрования:");
                string inputText = Console.ReadLine();

                TextDeCypher textDeCypher = new TextDeCypher();

                switch (cypherChoice)
                {
                    case 1: // Шифр Полибия
                        Console.WriteLine("1) Шифрование");
                        Console.WriteLine("2) Дешифрование");
                        int polyChoice = int.Parse(Console.ReadLine());

                        if (polyChoice == 1)
                        {
                            Console.WriteLine("Результат шифрования (Полибий):");
                            Console.WriteLine(textDeCypher.PolybiusEncrypt(inputText));
                        }
                        else if (polyChoice == 2)
                        {
                            Console.WriteLine("Результат дешифрования (Полибий):");
                            Console.WriteLine(textDeCypher.PolybiusDecrypt(inputText));
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор операции.");
                        }
                        break;

                    case 2: // Шифр Гронсфельда
                        Console.WriteLine("Введите ключ (цифры для шифра Гронсфельда):");
                        string gronsfeldKey = Console.ReadLine();

                        Console.WriteLine("1) Шифрование");
                        Console.WriteLine("2) Дешифрование");
                        int gronsfeldChoice = int.Parse(Console.ReadLine());

                        if (gronsfeldChoice == 1)
                        {
                            Console.WriteLine("Результат шифрования (Гронсфельд):");
                            Console.WriteLine(textDeCypher.GronsfeldEncrypt(inputText, gronsfeldKey));
                        }
                        else if (gronsfeldChoice == 2)
                        {
                            Console.WriteLine("Результат дешифрования (Гронсфельд):");
                            Console.WriteLine(textDeCypher.GronsfeldDecrypt(inputText, gronsfeldKey));
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор операции.");
                        }
                        break;

                    case 3: // Книжный шифр
                        Console.WriteLine("Введите текст книги для шифрования (это будет ключ для книжного шифра):");
                        string bookText = Console.ReadLine();

                        Console.WriteLine("1) Шифрование");
                        Console.WriteLine("2) Дешифрование");
                        int bookChoice = int.Parse(Console.ReadLine());

                        if (bookChoice == 1)
                        {
                            Console.WriteLine("Результат шифрования (Книжный):");
                            Console.WriteLine(textDeCypher.BookEncrypt(inputText, bookText));
                        }
                        else if (bookChoice == 2)
                        {
                            Console.WriteLine("Результат дешифрования (Книжный):");
                            Console.WriteLine(textDeCypher.BookDecrypt(inputText, bookText));
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор операции.");
                        }
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор шифра.");
                        break;
                }

                break;

            case 9:
                Console.WriteLine("Введите текст: ");
                string case_9_input = Console.ReadLine();

                laboratory_func.TextManager textManager = new laboratory_func.TextManager();

                string resultWithArray = textManager.TextStringWithArray(case_9_input);
                Console.WriteLine("Результат (через массивы):");
                Console.WriteLine(resultWithArray + "\n");

                string resultWithFunctions = textManager.TextStringWithFunctions(case_9_input);
                Console.WriteLine("Результат (через функции):");
                Console.WriteLine(resultWithFunctions);

                break;

            case 10:
                Console.WriteLine("Введите текст: ");
                string case_10_input = Console.ReadLine();

                laboratory_func.TimeFinder timeFinder = new laboratory_func.TimeFinder();

                var timeValues = timeFinder.FindTimeValues(case_10_input);

                if (timeValues.Count > 0)
                {
                    Console.WriteLine("Найденные значения времени:");
                    foreach (var time in timeValues)
                    {
                        Console.WriteLine(time);
                    }
                }
                else
                {
                    Console.WriteLine("Время не найдено.");
                }

                break;


        }

    }
}