using Code.Abstractions;
using UnityEngine;

namespace Code
{
    public class ProduceUnitsCommand: ICommand
    {
        private string _name = "Produce unit";
        
        public string Name => _name;

        public void DoCommand()
        {
            Debug.Log("Produce Unit");
        }
    }
}