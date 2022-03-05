using System.IO;
using System.Reflection;

namespace Foxoft.AppCode
{
    public class CustomMethods
    {
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
    }
}
