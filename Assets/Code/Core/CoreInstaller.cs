using Zenject;

namespace Code.Core
{
    public class CoreInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
            //Container.Bind(typeof(ITimeModel), typeof(ITickable)).To(typeof(TimeModel)).AsSingle();
            // эти две строчки аналогичны. Можно привязать все интерфейсы, а можно привязать конкретные
        }
    }
}