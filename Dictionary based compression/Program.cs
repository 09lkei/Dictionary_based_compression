using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

class Program {
    public static void Main (string[] args)
    {
        string text = "Give a man a fish and you feed him for a day. Teach a man to fish and you feed him for a lifetime.";
        dictionaryCompress(text);
    }

    public static void dictionaryCompress(string inputString)
    {
        IDictionary<int, string> myDictionary = new Dictionary<int, string>();
        int originalLength = Encoding.Unicode.GetByteCount(inputString);
        int nextIndex = 0;
        string usedString = inputString;
        for (int length = inputString.Length/2; length>1; length--)
        {
            bool compressed = false;
            for (int i = 0; i + length < usedString.Length; i++)
            {
                string checkRepeat = usedString.Substring(i,length);
                for (int j = i + length; j + length < inputString.Length; j++)
                {
                    if (usedString.Substring(j, length) == checkRepeat)
                    {
                        j += length;
                        myDictionary.Add(nextIndex, checkRepeat);
                        usedString = usedString.Substring(0, j);
                        nextIndex++;
                        break;
                    }
                }
            }

            
        }

        foreach (var values in myDictionary)
        {
            Console.WriteLine("Key: {0}, Value: {1}", values.Key, values.Value);
        }
    }
}