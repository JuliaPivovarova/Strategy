using System;
using Code.Abstractions;

namespace Code.Core
{
    public abstract class CommandCreatorBase<T> where T: ICommand
    {
        public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
        {
            var classSpecificCommandExecutor = commandExecutor as ICommandExecutor<T>;
            if(classSpecificCommandExecutor != null)
            {
                ClassSpecificCommandCreation(callback);
            }
            return commandExecutor;
        }

        protected abstract void ClassSpecificCommandCreation(Action<T> creationCallback);

        public virtual void ProcessCancel() { }
    }
}
