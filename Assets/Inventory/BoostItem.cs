using UnityEngine;

public class BoostItem : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private int jump = 1;

    bool boostAdded = false;

    private void OnEnable()
     {
        if (!boostAdded)
        {
            ObjectsInInventory.speedBoost += this.speed;
            ObjectsInInventory.jumpBoost += this.jump;
        }

         Debug.Log("Speed Boost: " + ObjectsInInventory.speedBoost + System.Environment.NewLine +
             "Jump Boost: " + ObjectsInInventory.jumpBoost);
     }

     private void OnDisable()
     {
         //ObjectsInInventory.speedBoost -= this.speedBoost;
         //ObjectsInInventory.jumpBoost -= this.jumpBoost;
     }
}
