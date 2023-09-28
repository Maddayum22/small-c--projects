using System;
using System.IO;

namespace WordUnscrambler.workers
{
    public class FileReader
    {
        internal string[] Read(string wordListFileName)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(wordListFileName);

            } catch (Exception ex)
            {
                Console.WriteLine(Constants.WordListNotFound);
                throw new Exception(ex.Message);
            }
            return fileContent;
        }
    }
}
