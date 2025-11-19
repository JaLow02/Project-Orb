using UnityEngine;

public class Garlic : MonoBehaviour
{
    [SerializeField] private GameObject garlicPrefab;
    public float weaponCooldown;
    private float spawnCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0)
        {
            spawnCounter = weaponCooldown;
            Instantiate(garlicPrefab, transform.position, transform.rotation, transform);
        }
    }
}
