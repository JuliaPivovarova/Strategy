using System.Linq;
using UnityEngine;

namespace Code.UserControlSystem.UIView
{
    public class OutlineSelectView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] _renderers;
        [SerializeField] private Material _outlineMaterial;
    
        private bool _isSelected;
    
        public void SetSelected(bool isSelected)
        {
            if(_isSelected == isSelected)
                return;
            
            for(int i = 0; i < _renderers.Length; i++)
            {
                var renderer = _renderers[i];
                var materialsList = renderer.materials.ToList();
                if (isSelected)
                    materialsList.Add(_outlineMaterial);
                else
                    materialsList.RemoveAt(materialsList.Count - 1);
                
                renderer.materials = materialsList.ToArray();
            }
        
            _isSelected = isSelected;
        }
    }
}
