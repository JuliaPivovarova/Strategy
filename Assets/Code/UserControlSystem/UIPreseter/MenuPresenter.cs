using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UserControlSystem.UIPreseter
{
    public class MenuPresenter: MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _backButton.OnClickAsObservable().Subscribe(_ =>
            {
                gameObject.SetActive(false);
                Time.timeScale = 1;
            });  
            _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
        }
    }
}