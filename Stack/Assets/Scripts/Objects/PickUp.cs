using System;
using UnityEngine;
using Interfaces;

namespace Objects
{
    public class PickUp : MonoBehaviour, IInteract
    {
        public static Action<bool, Transform> OnInteract;

        private bool _isPickedUp;
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        public void Interact()
        {
            if (!_isPickedUp)
            {
                AddToStack();
            }
            else
            {
                RemoveFromStack();
            }

            OnInteract?.Invoke(_isPickedUp, transform);
        }

        private void AddToStack()
        {
            _isPickedUp = true;
            _collider.isTrigger = false;
        }

        private void RemoveFromStack()
        {
            _isPickedUp = false;
            _collider.isTrigger = true;
            gameObject.SetActive(false);
        }
    }
}