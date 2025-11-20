using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private List<GameObject> placedGameObjects = new();

    public int PlaceObject(GameObject prefab, Vector3 position)
    {

        GameObject currentObject = Instantiate(prefab);
        currentObject.transform.position = position;
        placedGameObjects.Add(currentObject);

        ApplyStats(currentObject);

        return placedGameObjects.Count - 1;
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if(placedGameObjects.Count <= gameObjectIndex || placedGameObjects[gameObjectIndex] == null) { return; }
        Destroy(placedGameObjects[gameObjectIndex]);

        RemoveStats(placedGameObjects[gameObjectIndex]);

        placedGameObjects[gameObjectIndex] = null;
    }

    void ApplyStats(GameObject obj)
    {
        var stats = obj.GetComponent<InventoryObject>();
        if (stats == null)
            return;

        ObjectsInInventory.totalSpeedBoost += stats.speedBoost;
        ObjectsInInventory.totalJumpBoost += stats.jumpBoost;

        if (stats.isSword) ObjectsInInventory.swordEquiped = true;
        if (stats.isBow) ObjectsInInventory.bowEquiped = true;
    }

    void RemoveStats(GameObject obj)
    {
        var stats = obj.GetComponent<InventoryObject>();
        if (stats == null)
            return;

        ObjectsInInventory.totalSpeedBoost -= stats.speedBoost;
        ObjectsInInventory.totalJumpBoost -= stats.jumpBoost;

        // Prüfen, ob noch ein Schwert existiert
        if (stats.isSword)
            CheckIfAnySwordLeft();

        // Prüfen, ob noch ein Bogen existiert
        if (stats.isBow)
            CheckIfAnyBowLeft();
    }

    private void CheckIfAnySwordLeft()
    {
        foreach (var obj in placedGameObjects)
        {
            if (obj == null) continue;
            var stats = obj.GetComponent<InventoryObject>();
            if (stats != null && stats.isSword)
            {
                ObjectsInInventory.swordEquiped = true;
                return;
            }
        }
        ObjectsInInventory.swordEquiped = false;
    }

    private void CheckIfAnyBowLeft()
    {
        foreach (var obj in placedGameObjects)
        {
            if (obj == null) continue;
            var stats = obj.GetComponent<InventoryObject>();
            if (stats != null && stats.isBow)
            {
                ObjectsInInventory.bowEquiped = true;
                return;
            }
        }
        ObjectsInInventory.bowEquiped = false;
    }
}
