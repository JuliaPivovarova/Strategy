using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UserControlSystem.UIPreseter
{
    public class BottomRightPresenter: MonoBehaviour
    {
        [SerializeField] private RectTransform _right;

        private Button[] _commandsButtons;

        private void Start()
        {
            _commandsButtons = _right.GetComponentsInChildren<Button>();
        }
    }
}