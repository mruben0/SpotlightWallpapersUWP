using SpotLightUWP.Services.Base;
using System.Linq;
using Windows.ApplicationModel.Background;

namespace SpotLightUWP.Services
{
    public class BackgroundTaskService : IBackgroundTaskService
    {
        public void RegisterBackgroundTask(string taskName, IBackgroundTrigger trigger, bool shouldUserExist)
        {
            var tasks = BackgroundTaskRegistration.AllTasks;
            if (!tasks.Any(e => e.Value.Name == taskName))
            {
                var builder = new BackgroundTaskBuilder
                {
                    Name = taskName
                };
                builder.SetTrigger(trigger);
                if (shouldUserExist)
                {
                    builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
                }
                BackgroundTaskRegistration task = builder.Register();
            }
        }

        public void UnRegisterBackgroundTask(string taskName, bool cancel)
        {
            var tasks = BackgroundTaskRegistration.AllTasks;
            if (tasks.Any(e => e.Value.Name == taskName))
            {
                tasks.First(e => e.Value.Name == taskName).Value.Unregister(cancel);
            }
        }

        public void UnregisterAllTasks()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                task.Value.Unregister(true);
            }
        }

        public bool HasRegistered(string taskName)
        {
            return BackgroundTaskRegistration.AllTasks.Any(e => e.Value.Name == taskName);
        }
    }
}
