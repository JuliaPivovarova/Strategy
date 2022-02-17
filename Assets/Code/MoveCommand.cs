using Code.Abstractions;
using UnityEngine;

namespace Code
{
    public class MoveCommand: ICommand
    {
        private string _name = "Move";
        
        public string Name => _name;
        
        public void DoCommand()
        {
            Debug.Log("Move!");
        }
    }
}