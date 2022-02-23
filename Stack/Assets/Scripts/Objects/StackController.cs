using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Objects
{
    public class StackController : MonoBehaviour
    {
        [SerializeField] private Transform _pickUpParent;
        [SerializeField] private float _spaceBetweenNodes;
        [SerializeField] private float _lerpDuration;

        private Transform _stackParent;
        private Transform _playerTransform;
        private List<Transform> _stack = new List<Transform>();

        private void Awake()
        {
            _stackParent = transform;
            _playerTransform = FindObjectOfType<PlayerController>().transform;
            _stack.Add(_playerTransform);

            PickUp.OnInteract += UpdateStack;
        }

        private void Update()
        {
            // Simple fix for the child-parent-parent position relationship.
            transform.localPosition = new Vector3(_playerTransform.position.x * -1, 0, 0);
        }

        private void FixedUpdate()
        {
            WaveNodes();
        }

        private void WaveNodes()
        {
            for (int i = 1; i < _stack.Count; i++)
            {
                Vector3 nodePosition = _stack[i].localPosition;
                Vector3 previousNodePosition = _stack[i - 1].localPosition;
                nodePosition = new Vector3(
                    Mathf.Lerp(nodePosition.x, previousNodePosition.x, Time.deltaTime * _lerpDuration),
                    nodePosition.y,
                    i * _spaceBetweenNodes);

                _stack[i].localPosition = nodePosition;
            }
        }

        private void UpdateStack(bool isPickedUp, Transform node)
        {
            if (isPickedUp)
            {
                _stack.Add(node);
                node.SetParent(_stackParent);
            }
            else
            {
                _stack.Remove(node);
                node.SetParent(_pickUpParent);
            }
        }
    }
}