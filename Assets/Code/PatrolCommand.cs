using Code.Abstractions;
using UnityEngine;

namespace Code
{
    public class PatrolCommand: ICommand
    {
        private string _name = "Patrol";
                
        public string Name => _name;
        
        public void DoCommand()
        {
            Debug.Log("Patrol!");
        }
    }
}