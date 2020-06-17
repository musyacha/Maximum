using System;
using System.IO;

namespace MaxLength
{
    class Program
    {
        static int MaxLength(string text)
        {
            int max = 0;
            int length = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] != '\r' && text[i] != '\n')
                {
                    length++;
                }
                else
                {
                    if (max < length)
                        max = length;
                    length = 0;
                }
            }

            if(max == 0 && length != 0)
                max = length;
            if (max == 0 && length == 0)
                return -1;

            return max;
        }

        static string ReadFile(string path)
        {
            string text = "";
            using (StreamReader input = new StreamReader(path))
            {
                text = input.ReadToEnd();
            }

            return text;
        }
        static void Main()
        {
            try
            {
                string text = ReadFile("TestFile.txt");
                int max = MaxLength(text);
                if (text.Length == 0 || max == -1)
                    Console.WriteLine("В файле нет слов");
                else
                    Console.WriteLine("Максимальная длина слова {0}", max);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Console.ReadLine();
        }
    }
}
