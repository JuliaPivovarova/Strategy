using Code.Abstractions;
namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class AttackCommandCreator: CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);
    }
}