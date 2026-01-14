using UnityEngine;

public class Target : MonoBehaviour
{
    public int life;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            print("touched");
            Damage();
        }
    }
    
    private void Damage()
    {
        life--;
    }
}
