using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotLightUWP.Models
{
    public class ImageDetailNavigationArgs
    {
        public ImageDetailNavigationArgs(ObservableCollection<ImageDTO> source = null, string id = null, string name = null)
        {
            Source = source;
            Id = id;
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<ImageDTO> Source { get; set; }
    }
}
