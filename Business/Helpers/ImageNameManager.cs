using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotLightUWP.Core.Helpers
{

    public static class ImageNameManager
    {
        public static string GetId(string name)
        {
            if (name.Contains("__"))
            {
                var substrings = name.Split("__".ToCharArray());
                return substrings[2];
            }
            else return name;
        }
        public static string ResultPathGenerator(string url, string path, string id = null, string name = null)
        {
            string _name = name ?? Path.GetFileName(url);
            if (id != null)
            {
                _name = $"__{id}__" + _name;
            }
            string resultPath = Path.Combine(path, _name);
            return resultPath.Replace("'", string.Empty);
        }

        public static string CleanName(string name)
        {
            if (name.Contains('.'))
            {
                return name.Split('.')[0];
            }
            else return name;
        }

        public static string CreateName(string name)
        {
            if (name.Contains("__"))
            {
                var substrings = name.Split("__".ToCharArray());
                name = substrings.Last();
            }
            if (name.Contains("."))
            {
                return name + ".jpg";
            }
            return name;
        }
    }
}
