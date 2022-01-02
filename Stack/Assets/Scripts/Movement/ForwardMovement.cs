using UnityEngine;

namespace Movement
{
    public class ForwardMovement : MovementBase
    {
        private void FixedUpdate()
        {
            Move(Vector3.forward);
        }
    }
}