using UnityEngine;

namespace Movement
{
    public class MovementBase : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move(Vector3 position)
        {
            Vector3 offset = position * (_speed * Time.deltaTime);
        
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}