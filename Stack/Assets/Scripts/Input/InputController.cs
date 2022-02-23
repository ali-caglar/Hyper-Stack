using UnityEngine;
using Scriptables;

namespace Inputs
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;

        private void Update()
        {
            _inputData.ReadInput();
        }
    }
}