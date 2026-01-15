using UnityEngine;

namespace Script
{
    public class Target : MonoBehaviour
    {
        public int life;

        [SerializeField] private float shakeIntensity = 0.1f;
        [SerializeField] private float shakeFrequency = 25f;
        [SerializeField] private float shakeDuration = 0.2f;

        private Vector3 basePosition;
        private Vector3 currentOffset;
        private float shakeTimer;
        private float nextShakeTime;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            basePosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (shakeTimer > 0f)
            {
                shakeTimer -= Time.deltaTime;

                if (shakeFrequency <= 0f)
                {
                    currentOffset = Random.insideUnitSphere * shakeIntensity;
                }
                else if (Time.time >= nextShakeTime)
                {
                    currentOffset = Random.insideUnitSphere * shakeIntensity;
                    nextShakeTime = Time.time + (1f / shakeFrequency);
                }

                transform.position = basePosition + currentOffset;

                if (shakeTimer <= 0f)
                {
                    shakeTimer = 0f;
                    currentOffset = Vector3.zero;
                    transform.position = basePosition;
                }
            }
            else
            {
                basePosition = transform.position;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                print("touched");
                TriggerShake();
                Damage();
            }
        }

        private void TriggerShake()
        {
            shakeTimer = shakeDuration;
            nextShakeTime = 0f;
            currentOffset = Vector3.zero;
        }

        private void Damage()
        {
            if (life <= 0)
            {
                Destroy(gameObject);
            }

            life--;
        }
    }
}
