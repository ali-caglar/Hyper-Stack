using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothTime;
    
        private void LateUpdate()
        {
            Vector3 targetPosition = _target.position + _offset;
            targetPosition.x = 0;

            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothTime * Time.deltaTime);
        }
    }
}