using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public static class EventAggregator
    {
        public static void SendMessage<T>(T message)
        {
            var type = typeof(IListener<T>);

            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetInterfaces().Contains(type))
                .Each(x =>
            {
                GameObject.FindObjectsOfType<MonoBehaviour>()
                    .Where(t => t.GetType() == x)
                    .Each(z => ((IListener<T>)z).Handle(message));
            });

        }
    }
}
