using Code.Abstractions;
using UnityEngine;

namespace Code
{
    public class AttackCommand: ICommand
    {
        private string _name = "Attack";
        
        public string Name => _name;
        
        public void DoCommand()
        {
            Debug.Log("Attack!");
        }
    }
}