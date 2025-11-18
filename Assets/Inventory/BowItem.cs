using UnityEngine;

public class BowItem : MonoBehaviour
{
    private void OnAwake()
    {
        ObjectsInInventory.bowEquiped = true;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }

    private void OnDestroy()
    {
        //ObjectsInInventory.bowEquiped = false;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }
}
