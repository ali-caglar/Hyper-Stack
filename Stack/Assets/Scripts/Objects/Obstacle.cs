using UnityEngine;
using Interfaces;

namespace Objects
{
    public class Obstacle : MonoBehaviour
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