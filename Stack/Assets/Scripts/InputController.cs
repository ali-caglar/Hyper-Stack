using UnityEngine;
using Scriptables;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputData _inputData;

    private void Update()
    {
        _inputData.ReadInput();
    }
}