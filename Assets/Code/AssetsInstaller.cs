using Code.UserControlSystem.UIModel.CommandCreators;
using Code.Utils;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = nameof(AssetsInstaller), menuName = "Installers/" + nameof(AssetsInstaller))]
public class AssetsInstaller: ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetContext _legasyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private AttackableValue _attackableValue;

    public override void InstallBindings()
    {
        Container.Bind<AssetContext>().FromInstance(_legasyContext);
        Container.Bind<Vector3Value>().FromInstance(_groundClicksRMB);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        Container.Bind<AttackableValue>().FromInstance(_attackableValue);
    }
}