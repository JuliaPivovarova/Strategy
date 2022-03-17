using Zenject;

namespace Code.UserControlSystem.UIView
{
    public class UIViewInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BottomCenterView>().FromComponentInHierarchy().AsSingle();
        }
    }
}