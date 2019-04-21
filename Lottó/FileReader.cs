using System;
using System.IO;
using Consts;

namespace Lottó
{
    public static class FileReader
    {
        public static string GetFileContent(string fileName)
        {
            string result;
            if (File.Exists(fileName))
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        result = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                    fileStream.Close();
                }
            }
            else
            {
                throw new FileNotFoundException(String.Concat(Constants.FILE_NOT_FOUND, fileName), fileName);
            }
            return result;
        }
    }
}
