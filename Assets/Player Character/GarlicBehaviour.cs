using UnityEngine;

public class GarlicBehaviour : MonoBehaviour
{
    public float duration;
    public float damage;
    void Start()
    {
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyMovement enemy = other.GetComponent<EnemyMovement>();
            enemy.TakeDamage(damage);
        }
    }
}
