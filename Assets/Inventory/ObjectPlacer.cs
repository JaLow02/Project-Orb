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
        return placedGameObjects.Count - 1;
    }
}
