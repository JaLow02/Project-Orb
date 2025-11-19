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

        foreach (var obj in database.objectsData)
        {
            objectPlaced[obj.ID] = false;
        }
    }

    public void StartPlacement(int ID)
    {
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
        Debug.Log("Button disabled");

        objectPlaced[id] = true;
        DisableButtonForID(id);
    }

    private void DisableButtonForID(int id)
    {
        if (id >= 0 && id <placementButtons.Count)
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
        if (id >= 0 && id < placementButtons.Count)
        {
            placementButtons[id].interactable = true;
        }
        objectPlaced[id] = false;
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
