using System.Threading.Tasks;
using Code.Abstractions;

namespace Code.Core
{
    public class SetCollectionPointCommandExecutor: CommandExecutorBase<ISetCollectionPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetCollectionPointCommand command)
        {
            GetComponent<MainBuilding>().CollectionPoint = command.CollectionPoint;
        }
    }
}