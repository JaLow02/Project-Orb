using UnityEngine;

public class BowItem : MonoBehaviour
{
    private void OnEnable()
    {
        ObjectsInInventory.bowEquiped = true;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }

    private void OnDisable()
    {
        //ObjectsInInventory.bowEquiped = false;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }
}
