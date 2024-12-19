using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Tracing;

namespace Lab4Ivt2
{
    internal class laboratory_func
    {
        public class SymbolsFunctions
        {
            public void find_symbols(string input_string) 
            {
                input_string = input_string.TrimEnd('.');
                
                char[] characters = input_string.ToCharArray();
                int[] counts = new int[char.MaxValue];

                foreach (char c in characters)
                {
                    if (!char.IsWhiteSpace(c) && !char.IsPunctuation(c))
                    {
                        counts[c]++;
                    }
                }

                Console.WriteLine("Символы, которые появляются один раз:");
                foreach (char c in characters)
                {
                    if (!char.IsWhiteSpace(c) && !char.IsPunctuation(c) && counts[c] == 1)
                    {
                        Console.Write(c + " ");

                    }
                }
            }
            public void find_symbols_withFunction(string input_string) 
            {
                input_string = input_string.TrimEnd('.');

                var FilteredCharacters = input_string.Where(c => !char.IsWhiteSpace(c) && !char.IsPunctuation(c));

                var CharacterCounts = FilteredCharacters.GroupBy(c => c).Where(g => g.Count() == 1).Select(g => g.Key);


                Console.WriteLine("Символы, которые появляются один раз (с помощью функций): ");
                foreach (char c in input_string)
                {
                    if (CharacterCounts.Contains(c) && !char.IsWhiteSpace(c) && !char.IsPunctuation(c))
                    {
                        Console.WriteLine(c + " ");
                    }
                }


            }
        }

        public class WordFunctions
        {
            public void numerate_words(string input_string) 
            {
                input_string = input_string.TrimEnd('.');

                var regex_matches = Regex.Matches(input_string, @"\w+|[^\w\s]|\s+");

                int word_counter = 0;
                string output_string = "";

                foreach (Match match in regex_matches)
                {
                    string part = match.Value;

                    if (Regex.IsMatch(part, @"\w+"))
                    {
                        word_counter++;
                        output_string += $"{part}({word_counter})";
                    }
                    else
                    {
                        output_string += part;
                    }
                }
                Console.WriteLine("Через массивы: ");
                Console.WriteLine(output_string.Trim());


            }

            public void numerate_words_withFunc(string input_string) 
            {
                input_string = input_string.TrimEnd('.');

                int word_counter = 0;
                string output_string = "";
                string current_word = "";

                for (int i = 0; i < input_string.Length; i++)
                {
                    char current_char = input_string[i];

                    if (char.IsLetterOrDigit(current_char))
                    {
                        current_word += current_char;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(current_word))
                        {
                            word_counter++;
                            output_string += $"{current_word}({word_counter})";
                            current_word = "";
                        }

                        output_string += current_char;
                    }
                }

                if (!string.IsNullOrEmpty(current_word))
                {
                    word_counter++;
                    output_string += $"{current_word}({word_counter})";
                }

                output_string = output_string.Trim();

                Console.WriteLine("Через string: ");
                Console.WriteLine(output_string);

            }

        }

        public class SentenceFunctions
        {
            public void reverse_sentence(string input_string) 
            {
                input_string = input_string.TrimEnd('.');

                var string_array = input_string.Split(' ');

                Array.Reverse(string_array);

                var reversed_string = string.Join(" ", string_array);

                Console.WriteLine("Через массив: ");

                Console.WriteLine(reversed_string);


            }

            public void reverse_sentence_withFunc(string input_string) 
            {
                input_string = input_string.TrimEnd('.');

                var splited_string = input_string.Split(" ");

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = splited_string.Length - 1; i >= 0; i--)
                {
                    stringBuilder.Append(splited_string[i]);
                    if (i > 0)
                    {
                        stringBuilder.Append(" ");
                    }
                }


                Console.WriteLine("Через методы: ");

                Console.WriteLine(stringBuilder.ToString());



            }
        }

        public class FindingSentence
        {
            public void com_finder(string[] input_string) 
            {
                string reg_pattern = @"\.com$";
                string[] temp_list = new string[input_string.Length];
                int counter = 0;
                int minspaces = int.MaxValue;
                string sentence_with_min_spaces = "";
                int line_with_min_space = -1;



                for (int i = 0; i < input_string.Length; i++)
                {
                    string line = input_string[i];

                    if (Regex.IsMatch(line, reg_pattern, RegexOptions.IgnoreCase))
                    {
                        temp_list[counter] = line;
                        counter++;
                    }

                    int spaceCount = CountSpaces(line);
                    if (spaceCount < minspaces)
                    {
                        minspaces = spaceCount;
                        sentence_with_min_spaces = line;
                        line_with_min_space = i + 1;
                    }

                }

                Console.WriteLine("Через массив: ");
                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine($"{i + 1}) {temp_list[i]}");
                }

                Console.WriteLine($"Предложение у которого меньше пробелов: {line_with_min_space}) {sentence_with_min_spaces}");

            }

            public void com_finder_withMethods(string[] input_strings) 
            {
                string reg_pattern = @"\b\w+\.com\b";
                Regex regex = new Regex(reg_pattern, RegexOptions.IgnoreCase);

                string sentenceWithMinSpaces = "";
                int minSpaces = int.MaxValue;
                int lineWithMinSpaces = -1;

                Console.WriteLine("Через методы: ");

                for (int i = 0; i < input_strings.Length; i++)
                {
                    string line = input_strings[i];

                    if (regex.IsMatch(line))
                    {
                        Console.WriteLine($"{i + 1}) {line}");
                    }

                    int spaceCount = line.Split(' ').Length - 1;
                    if (spaceCount < minSpaces)
                    {
                        minSpaces = spaceCount;
                        sentenceWithMinSpaces = line;
                        lineWithMinSpaces = i + 1;
                    }
                }

                Console.WriteLine($"Предложение с наименьшим кол-во пробелов: {lineWithMinSpaces}) {sentenceWithMinSpaces}");
            }



            private int CountSpaces(string sentence)
            {
                int my_spacecounter = 0;
                foreach (char c in sentence)
                {
                    if (c == ' ')
                    {
                        my_spacecounter++;
                    }
                }
                return my_spacecounter;

            }
        }

        public class FilterForUsernames
        {
            public void filterUsernames(string input_string) 
            {
                string[] words = input_string.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine("Через массив: ");

                foreach (var word in words)
                {
                    if (word.Length >= 3 && char.IsUpper(word[0]) && char.IsDigit(word[word.Length - 1]) && char.IsDigit(word[word.Length - 2]))
                    {
                        Console.WriteLine(word);
                    }
                }

            }

            public void filterUsername_withRegex(string input_text) 
            {
                string pattern = @"\b[A-Z][a-zA-Z]*\d{2}\b";

                Regex regex = new Regex(pattern);

                Console.WriteLine("Через регулярные выражения:");

                MatchCollection matches = regex.Matches(input_text);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }


            }




        }

        public class TransformMathem
        {
            public void Transform_withRegex(string inputString)
            {
                string pattern = @"\s*(-?\d+)\s*([\+\-\*/])\s*(-?\d+)\s*=\s*(-?\d+)\s*";
                

                Match match = Regex.Match(inputString, pattern);

                if (match.Success)
                {
                    int operand1 = int.Parse(match.Groups[1].Value);
                    string operation = match.Groups[2].Value;
                    int operand2 = int.Parse(match.Groups[3].Value);
                    int result = int.Parse(match.Groups[4].Value);

                    Console.WriteLine($"Операнд 1: {operand1}");
                    Console.WriteLine($"Операция: {operation}");
                    Console.WriteLine($"Операнд 2: {operand2}");
                    Console.WriteLine($"Результат: {result}");

                }


            }


        }

        public class Playlist_counter
        {
            public void time_counter(string[] inputTracklist)
            {
                var songDurations = new List<(string Title, TimeSpan Duration)>();
                string pattern = @"^.*?\[(\d+):(\d+)\]|\((\d+):(\d+)\)$";

                foreach (var track in inputTracklist)
                {
                    var match = Regex.Match(track, pattern);
                    if (match.Success)
                    {
                        int minutes = int.Parse(match.Groups[1].Value != "" ? match.Groups[1].Value : match.Groups[3].Value);
                        int seconds = int.Parse(match.Groups[2].Value != "" ? match.Groups[2].Value : match.Groups[4].Value);
                        TimeSpan duration = new TimeSpan(0, minutes, seconds);

                        string title = track.Split(new[] { " – " }, StringSplitOptions.None)[1].Split('[')[0].Trim();
                        songDurations.Add((title, duration));
                    }
                }

                TimeSpan totalDuration = songDurations.Select(s => s.Duration).Aggregate((t1, t2) => t1 + t2);

                var longestSong = songDurations.OrderByDescending(s => s.Duration).First();
                var shortestSong = songDurations.OrderBy(s => s.Duration).First();

                var minDiffPair = songDurations
                    .SelectMany((s1, i) => songDurations.Skip(i + 1), (s1, s2) => (s1, s2))
                    .OrderBy(pair => Math.Abs((pair.s1.Duration - pair.s2.Duration).TotalSeconds))
                    .First();

                Console.WriteLine($"Общее время: {totalDuration}");
                Console.WriteLine($"Самая длинная песня: {longestSong.Title} ({longestSong.Duration})");
                Console.WriteLine($"Самая короткая песня: {shortestSong.Title} ({shortestSong.Duration})");
                Console.WriteLine($"Самая минимальная разница: {minDiffPair.s1.Title} ({minDiffPair.s1.Duration}) и {minDiffPair.s2.Title} ({minDiffPair.s2.Duration})");

            }

        }

        public class TextDeCypher
        {
            private readonly char[,] PolybiusSquare =
            {
                { 'A', 'B', 'C', 'D', 'E' },
                { 'F', 'G', 'H', 'I', 'K' },
                { 'L', 'M', 'N', 'O', 'P' },
                { 'Q', 'R', 'S', 'T', 'U' },
                { 'V', 'W', 'X', 'Y', 'Z' }
            };
            public string PolybiusEncrypt(string text)
            {
                StringBuilder cipherText = new StringBuilder();
                text = text.ToUpper().Replace('J', 'I');

                foreach (char ch in text)
                {
                    if (ch >= 'A' && ch <= 'Z')
                    {
                        for (int row = 0; row < 5; row++)
                        {
                            for (int col = 0; col < 5; col++)
                            {
                                if (PolybiusSquare[row, col] == ch)
                                {
                                    cipherText.Append((row + 1).ToString());
                                    cipherText.Append((col + 1).ToString());
                                }
                            }
                        }
                    }
                }

                return cipherText.ToString();
            }

            public string PolybiusDecrypt(string cipherText)
            {
                StringBuilder decryptedText = new StringBuilder();
                for (int i = 0; i < cipherText.Length; i += 2)
                {
                    int row = cipherText[i] - '1';
                    int col = cipherText[i + 1] - '1';
                    decryptedText.Append(PolybiusSquare[row, col]);
                }

                return decryptedText.ToString();
            }

            public string GronsfeldEncrypt(string text, string key)
            {
                StringBuilder cipherText = new StringBuilder();
                int keyIndex = 0;

                foreach (char ch in text)
                {
                    if (char.IsLetter(ch))
                    {
                        char baseChar = char.IsUpper(ch) ? 'A' : 'a';
                        int shift = key[keyIndex % key.Length] - '0';
                        char encryptedChar = (char)((ch - baseChar + shift) % 26 + baseChar);
                        cipherText.Append(encryptedChar);
                        keyIndex++;
                    }
                    else
                    {
                        cipherText.Append(ch);
                    }
                }

                return cipherText.ToString();
            }

            public string GronsfeldDecrypt(string cipherText, string key)
            {
                StringBuilder decryptedText = new StringBuilder();
                int keyIndex = 0;

                foreach (char ch in cipherText)
                {
                    if (char.IsLetter(ch))
                    {
                        char baseChar = char.IsUpper(ch) ? 'A' : 'a';
                        int shift = key[keyIndex % key.Length] - '0';
                        char decryptedChar = (char)((ch - baseChar - shift + 26) % 26 + baseChar);
                        decryptedText.Append(decryptedChar);
                        keyIndex++;
                    }
                    else
                    {
                        decryptedText.Append(ch);
                    }
                }

                return decryptedText.ToString();
            }

            public string BookEncrypt(string text, string bookText)
            {
                StringBuilder cipherText = new StringBuilder();

                foreach (char ch in text)
                {
                    int index = bookText.ToUpper().IndexOf(char.ToUpper(ch));
                    if (index != -1)
                    {
                        cipherText.Append((index + 1) + " ");
                    }
                    else
                    {
                        cipherText.Append("? ");
                    }
                }

                return cipherText.ToString().Trim();
            }

            public string BookDecrypt(string cipherText, string bookText)
            {
                StringBuilder decryptedText = new StringBuilder();

                string[] indices = cipherText.Split(' ');

                foreach (string indexStr in indices)
                {
                    if (int.TryParse(indexStr, out int index) && index > 0 && index <= bookText.Length)
                    {
                        decryptedText.Append(bookText[index - 1]);
                    }
                    else
                    {
                        decryptedText.Append("?");
                    }
                }

                return decryptedText.ToString();
            }
        }

        public class TextManager
        {
            public string TextStringWithArray(string text)
            {
                char[] delimiters = { ' ', '\t', '.', ',', ';', '!', '?', ':', '(', ')', '[', ']' };
                string result = ProcessTextAsCharArray(text, delimiters);
                return result;
            }

            private string ProcessTextAsCharArray(string text, char[] delimiters)
            {
                string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                string result = "";

                foreach (string word in words)
                {
                    if (IsValidVariableName(word))
                    {
                        result += word + " ";
                    }
                }

                return result.Trim(); 
            }

            public string TextStringWithFunctions(string text)
            {
                string result = ProcessTextWithStringBuilder(text);
                return result;
            }

            private string ProcessTextWithStringBuilder(string text)
            {
                string[] words = text.Split(new char[] { ' ', '\t', '.', ',', ';', '!', '?', ':', '(', ')', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder result = new StringBuilder();

                foreach (string word in words)
                {
                    if (IsValidVariableName(word))
                    {
                        result.Append(word + " ");
                    }
                }

                return result.ToString().Trim(); 
            }

            private bool IsValidVariableName(string word)
            {
                if (string.IsNullOrEmpty(word))
                    return false;

                string[] csharpKeywords = new string[] { "int", "class", "public", "private", "void", "return", "string", "for", "while", "if", "else", "switch", "case", "try", "catch" };

                if (Array.Exists(csharpKeywords, keyword => keyword.Equals(word, StringComparison.OrdinalIgnoreCase)))
                    return false;

                if (!char.IsLetter(word[0]) && word[0] != '_')
                    return false;

                foreach (char c in word)
                {
                    if (!char.IsLetterOrDigit(c) && c != '_')
                        return false;
                }

                return true;
            }
        }


            public class TimeFinder
            {
                public List<string> FindTimeValues(string text)
                {
                    string pattern = @"\b([01]?[0-9]|2[0-3]):([0-5]?[0-9]):([0-5]?[0-9])\b";

                    Regex regex = new Regex(pattern);

                    MatchCollection matches = regex.Matches(text);

                    List<string> timeValues = new List<string>();

                    foreach (Match match in matches)
                    {
                        timeValues.Add(match.Value);
                    }

                    return timeValues;

            }
        }




    }
}
