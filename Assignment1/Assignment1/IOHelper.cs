using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    class IOHelper
    {

        public static List<int>ReadFileToList(string filePath)
        {
            StreamReader reader = new StreamReader(filePath, false);
            List<int> input = new List<int>();
            string allValues = reader.ReadToEnd();
            string []values = allValues.Split('\n');
            foreach(string value in values)
            {
                input.Add(Int32.Parse(value));
            }
            return input;
        }

    }
}
