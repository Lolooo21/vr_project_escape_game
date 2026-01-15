using UnityEngine;

namespace Script
{


    public class Enemy : MonoBehaviour
    {
        private Transform _playerCamera;
        private Vector3 _directionToPlayer;
        private Vector3 _movement;
        private float _distanceToPlayer;
        public Rigidbody rb;
        public float speed = 0;
        public Animator animator;   
        public float distanceToStop;

        public int life;

        public float timeToMove = 4.30f;
        private float moveTimer ;
        private bool speedBoosted;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _playerCamera = Camera.main.transform;
            moveTimer = 0f;
            speedBoosted = false;
            speed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (!speedBoosted)
            {
                moveTimer += Time.deltaTime;
                if (moveTimer < timeToMove)
                {
                    rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                    animator.SetBool("Moving", false);
                    animator.SetBool("Screaming", false);
                    animator.SetBool("Touched", false);
                    animator.SetBool("IsDead", false);
                    
                    return;
                }
                
                speedBoosted = true;
            }

            speed = 2;

            _directionToPlayer = _playerCamera.position - transform.position;
            _directionToPlayer.y =0 ;
            transform.rotation = Quaternion.LookRotation(_directionToPlayer);

            _distanceToPlayer = Vector3.Distance(transform.position, _playerCamera.position);

             if (_distanceToPlayer > distanceToStop)
             {
                 _movement = _directionToPlayer.normalized * speed;
                 rb.linearVelocity = _movement + new Vector3(0, rb.linearVelocity.y, 0);
                 
                 animator.SetBool("Moving", true);
             }
             
             else
             {
                 rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                 animator.SetBool("Moving", false);
                 animator.SetBool("Screaming", true);
             }
             

        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                print("touched");
               // TriggerShake();
                Damage();
            }
        }
        

        private void Damage()
        {
            if (life <= 0)
            {
                animator.SetBool("IsDead", true);
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                //Destroy(gameObject);
            }
            life--;
            animator.SetBool("Touch", true);
        }
    }
}
