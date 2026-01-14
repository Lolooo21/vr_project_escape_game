using UnityEngine;

namespace Script.Pivot
{
    public class Door : MonoBehaviour
    {
        public bool isOpen;
        
        public Transform pivot;
        public Transform openedReference;
        public Transform closedReference;
        [SerializeField] private float openSpeed = 2f;

        private void Update()
        {
            var targetRotation = isOpen ? openedReference.localRotation : closedReference.localRotation;
            pivot.localRotation = Quaternion.Slerp(
                pivot.localRotation,
                targetRotation,
                openSpeed * Time.deltaTime
            );
        }
        
        
        public void OpenDoor()
        {
            isOpen = true;
        }
        public void CloseDoor()
        {
            isOpen = false;
        }
    }
}
