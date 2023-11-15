using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace Foxoft.AppCode
{
    public class CustomMethods
    {
        public string ClearVariablesFromQuery(string querySql)
        {
            if (querySql is not null)

                if (querySql.Contains("{"))
                {
                    int startindex = querySql.IndexOf('{');
                    int endindex = querySql.IndexOf('}');
                    string outputstring = querySql.Substring(startindex, endindex - startindex + 1);
                    string newQuerySql = querySql.Replace(outputstring, "");
                    return newQuerySql;
                }
                else
                    return querySql;
            else return null;
        }

        public string GetDataFromFile(string pathFile)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(pathFile))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public List<Image> GetImagesFrom(String folderPath, String[] filters, SearchOption searchOption)
        {
            List<Image> filesFound = new();

            foreach (var filter in filters)
            {
                if (CustomExtensions.DirectoryExist(folderPath))
                {
                    string[] fileNames = Directory.GetFiles(folderPath, String.Format("*.{0}", filter), searchOption);

                    foreach (var fileName in fileNames)
                    {
                        string fullPath = Path.Combine(folderPath, fileName);

                        if (File.Exists(fullPath))
                            using (var file = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                Image img = Image.FromStream(file);
                                img.Tag = fullPath;
                                filesFound.Add(img);
                            }
                    }
                }
            }

            return filesFound;
        }
    }
}
