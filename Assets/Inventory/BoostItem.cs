using UnityEngine;

public class BoostItem : MonoBehaviour
{
    [SerializeField] private int speedBoost;
    [SerializeField] private int jumpBoost;

    private void OnAwake()
    {
        ObjectsInInventory.speedBoost += this.speedBoost;
        ObjectsInInventory.jumpBoost += this.jumpBoost;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);

        Debug.Log("Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }

    private void OnDestroy()
    {
        ObjectsInInventory.speedBoost -= this.speedBoost;
        ObjectsInInventory.jumpBoost -= this.jumpBoost;

        Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
            "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
            "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
            "Jump Boost: " + ObjectsInInventory.jumpBoost);
    }
}
