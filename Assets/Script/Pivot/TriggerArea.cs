using UnityEngine;
using UnityEngine.Events;


namespace Script.Pivot
{
    public class TriggerArea : MonoBehaviour
    {
        public UnityEvent OnEnter;

        public UnityEvent OnExit;

        public bool hasKey;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnEnter.Invoke();
            }

            if (other.CompareTag("Player") && hasKey && other.CompareTag("Key"))
            {
                OnEnter.Invoke();
            }
                
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnExit.Invoke();
            }

        }
    }
}