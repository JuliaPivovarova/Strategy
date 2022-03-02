using System.Linq;
using Code.Abstractions;
using Code.UserControlSystem.UIModel.CommandCreators;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.UserControlSystem.UIPreseter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;
        
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackableRMB;
        [SerializeField] private Transform _groundTransform;

        private Plane _groundPlane;

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);

            var everyStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());
            var leftMouseButtonStream = everyStream.Where(_ => Input.GetMouseButtonDown(0));
            var rightMouseButtonStream = everyStream.Where(_ => Input.GetMouseButtonDown(1));

            var leftMouseButtonRay = leftMouseButtonStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
            var rightMouseButtonRay = rightMouseButtonStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));

            var lmbHits = leftMouseButtonRay.Select(ray => Physics.RaycastAll(ray));
            var rmbHits = rightMouseButtonRay.Select(ray => (ray, Physics.RaycastAll(ray)));

            lmbHits.Subscribe(hits =>
            {
                HitAnObject<ISelectable>(hits, out var selectable);
                _selectedObject.SetValue(selectable);
            });

            rmbHits.Subscribe(hitsData =>
            {
                var (ray, hits) = hitsData;
                
                if (HitAnObject<IAttackable>(hits, out var attackable))
                {
                    _attackableRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            });
        }

        private bool HitAnObject<T>(RaycastHit[] hits, out T result) where T: class
        {
            result = default;
            if (hits.Length == 0)
            {
                return false;
            }
            result = hits
                .Select(hit => hit.collider.GetComponentInParent<T>())
                .Where(c => c != null)
                .FirstOrDefault();
            return result != default;
        }
    }
}
