using UnityEngine;

public class SwordItem : MonoBehaviour
{
    private void OnAwake()
    {
        ObjectsInInventory.swordEquiped = true;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }

    private void OnDestroy()
    {
        //ObjectsInInventory.swordEquiped = false;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }
}
