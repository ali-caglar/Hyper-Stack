using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Input Data", fileName = "Input Data")]
    public class InputData : ScriptableObject
    {
        private float _moveFactorX;
        private float _lastFrameInputPositionX;

        public float MoveFactorX => _moveFactorX;

        public void ReadInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameInputPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameInputPositionX;
                _lastFrameInputPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0;
            }
        }
    }
}