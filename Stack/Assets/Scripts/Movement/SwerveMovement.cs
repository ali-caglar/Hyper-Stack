using UnityEngine;
using Scriptables;

namespace Movement
{
    public class SwerveMovement : MovementBase
    {
        [SerializeField] private InputData _inputData;

        [SerializeField] private float _minSwerveLimit;
        [SerializeField] private float _maxSwerveLimit;

        private Vector3 _swerve = Vector3.zero;

        private void Update()
        {
            float swerveAmount = Mathf.Clamp(transform.position.x, _minSwerveLimit, _maxSwerveLimit);
            Vector3 clampedPosition = new Vector3(swerveAmount, transform.position.y, transform.position.z);
            transform.position = clampedPosition;
        }

        private void FixedUpdate()
        {
            _swerve = new Vector3(_inputData.MoveFactorX, 0, 0);

            Move(_swerve);
        }
    }
}