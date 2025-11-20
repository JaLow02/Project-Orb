using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] Grid grid;

    [SerializeField] private ObjectsDatabaseSO database;
    [SerializeField] private GameObject gridVisualization;

    private GridData itemData;
    [SerializeField] private PreviewSystem preview;
    private Vector3Int lastDetectedPosition = Vector3Int.zero;
    [SerializeField] private ObjectPlacer objectPlacer;

    IBuildingState buildingState;

    [SerializeField] private List<Button> placementButtons;
    private Dictionary<int, bool> objectPlaced = new Dictionary<int, bool>();

    private void Start()
    {
        StopPlacement();
        itemData = new();

        ObjectsInInventory.SetCount(0, 1);
        ObjectsInInventory.SetCount(1, 1);
        ObjectsInInventory.SetCount(2, 3);

        foreach (var obj in database.objectsData)
        {
            objectPlaced[obj.ID] = false;
        }
    }

    public void StartPlacement(int ID)
    {
        if(ObjectsInInventory.GetCount(ID) <= 0)
        {
            Debug.Log("No Objects of this type availeable!");
            return;
        }

        StopPlacement();
        gridVisualization.SetActive(true);

        var state = new PlacementState(ID, grid, preview, database, itemData, objectPlacer);
        state.OnObjectPlaced += HandleObjectPlaced;

        buildingState = state;

        inputManager.OnClicked += PlaceStructure;
        inputManager.OnClicked += StopPlacement;
    }

    private void HandleObjectPlaced(int id)
    {
        ObjectsInInventory.Consume(id);

        var data = database.objectsData.Find(obj => obj.ID == id);

        // BOOST ANWENDEN
        ObjectsInInventory.AddBoost(data.speedBoost, data.jumpBoost);

        // Button deaktivieren wenn Counter 0 ist
        if (ObjectsInInventory.GetCount(id) <= 0)
        {
            placementButtons[id].interactable = false;
        }
    }


    public void StartRemoving()
    {
        StopPlacement();
        gridVisualization.SetActive(true);

        var state = new RemovingState(grid, preview, itemData, objectPlacer);
        state.OnObjectRemoved += HandleObjectRemoved;
        buildingState = state;

        inputManager.OnClicked += PlaceStructure;
        inputManager.OnClicked += StopPlacement;
    }

    private void HandleObjectRemoved(int id)
    {
        ObjectsInInventory.AddBack(id);

        var data = database.objectsData.Find(obj => obj.ID == id);

        // BOOST ZURÜCKNEHMEN
        ObjectsInInventory.RemoveBoost(data.speedBoost, data.jumpBoost);

        // Button wieder aktivieren
        placementButtons[id].interactable = true;
    }


    private void PlaceStructure()
    {
        if(inputManager.IsPointerOverUI()){ return; }

        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        buildingState.OnAction(gridPosition);
    }

    private void StopPlacement()
    {
        if (buildingState == null) { return; }
        gridVisualization.SetActive(false);
        buildingState.EndState();

        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnClicked -= StopPlacement;
        lastDetectedPosition = Vector3Int.zero;

        buildingState = null;
    }

    private void Update()
    {
        if (buildingState == null) { return; }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        if(lastDetectedPosition != gridPosition)
        {
            buildingState.UpdateState(gridPosition);
            lastDetectedPosition = gridPosition;
        }
    }
}
