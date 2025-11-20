using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject garlic;
    private int garlicActivated = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (garlicActivated >= ObjectsInInventory.garlicAmount)
        {
            SpawnWeapon();
            ++ garlicActivated;
        }
    }

    void SpawnWeapon()
    {
        Instantiate(garlic, transform.position, Quaternion.identity, transform);
    }
    
   
}
