using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject garlic;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnWeapon();
        }
    }

    void SpawnWeapon()
    {
        Instantiate(garlic, transform.position, Quaternion.identity, transform);
    }
    
   
}
