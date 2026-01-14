using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public float initialForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(transform.forward * initialForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
