using UnityEngine;

public class SwordItem : MonoBehaviour
{
    private void OnEnable()
     {
         ObjectsInInventory.swordEquiped = true;

         Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
             "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
             "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
             "Jump Boost: " + ObjectsInInventory.jumpBoost);
     }

     private void OnDisable()
     {
         //ObjectsInInventory.swordEquiped = false;

         Debug.Log("Bow: " + ObjectsInInventory.bowEquiped + System.Environment.NewLine +
             "Sword: " + ObjectsInInventory.swordEquiped + System.Environment.NewLine +
             "Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
             "Jump Boost: " + ObjectsInInventory.jumpBoost);
     }
}
