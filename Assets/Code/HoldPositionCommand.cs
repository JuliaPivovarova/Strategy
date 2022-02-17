using Code.Abstractions;
using UnityEngine;

namespace Code
{
    public class HoldPositionCommand: ICommand
    {
        private string _name = "Hold position";
        
        public string Name => _name;
        
        public void DoCommand()
        {
            Debug.Log("Hold Position!");
        }
    }
}