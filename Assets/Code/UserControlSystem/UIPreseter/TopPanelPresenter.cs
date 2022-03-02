using System;
using Code.Abstractions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UserControlSystem.UIPreseter
{
    public class TopPanelPresenter: MonoBehaviour
    {
        [SerializeField] private TMP_Text _timer;
        [SerializeField] private Button _menyButton;
        [SerializeField] private GameObject _menuGameObject;

        [Inject]
        private void Init(ITimeModel timeModel)
        {
            timeModel.GameTime.Subscribe(seconds =>
            {
                var t = TimeSpan.FromSeconds(seconds);
                _timer.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            });
            _menyButton.OnClickAsObservable().Subscribe(_ =>
            {
                _menuGameObject.SetActive(true);
                Time.timeScale = 0;
            });
        }
    }
}