using UnityEngine;
using Interfaces;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteract interactable))
            {
                interactable.Interact();
            }
        }
    }
}
