using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotLightUWP.Services.Base
{
    public interface IConfigsService
    {
        Configs GetConfigs();
        void SaveConfigs(Configs configs);
    }
}
