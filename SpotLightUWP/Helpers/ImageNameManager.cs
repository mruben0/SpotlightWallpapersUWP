using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotLightUWP.Helpers
{
    public class ImageNameManager
    {
        public int GetId(string name)
        {
            if (name.Contains("__"))
            {
                var substrings = name.Split("__");
                return Convert.ToInt32(substrings[1]);
            }
            else return 0;  
        }

        public string CleanName(string name)
        {
            if (name.Contains('.'))
            {
                return name.Split('.')[0];
            }
            else return name;
        }

        public string CreateName(string name)
        {
            if (name.Contains("__"))
            {
                var substrings = name.Split("__");
                name = substrings[1];                 
            }
            if (name.Contains("."))
            {
                return name + ".jpg";
            }
            return name;
        } 
    }
}
