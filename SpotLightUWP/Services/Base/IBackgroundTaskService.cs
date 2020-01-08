using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace SpotLightUWP.Services.Base
{
    public interface IBackgroundTaskService
    {
        string GetRegisteredTasks();
        void RegisterBackgroundTask(string taskName, IBackgroundTrigger trigger, bool shouldUserExist);
        void UnRegisterBackgroundTask(string taskName, bool cancel);
        void UnregisterAllTasks();

        bool HasRegistered(string taskName);
    }
}
