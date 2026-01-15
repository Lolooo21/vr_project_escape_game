using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{


    public class Shoot : MonoBehaviour
    {
        public InputActionReference touche;

        public GameObject bullet;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnEnable()
        {
            touche.action.Enable();
            touche.action.performed += OnTouchedPressed;
        }

        private void OnDisable()
        {
            touche.action.Disable();
            touche.action.performed -= OnTouchedPressed;
        }

        public void OnTouchedPressed(InputAction.CallbackContext obj)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}