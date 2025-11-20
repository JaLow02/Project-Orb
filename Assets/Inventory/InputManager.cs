using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera sceneCamera;
    [SerializeField] LayerMask placementLayermask;

    Vector3 lastPosition;

    public event Action OnClicked;
    //, OnExit

    bool isSwitching = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && !isSwitching)
        {
            //OnExit?.Invoke();
            //SceneManager.UnloadSceneAsync("Inventory");
            //SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
            //StartCoroutine(SwitchToMainScene());
        }
    }

    /*IEnumerator SwitchToMainScene()
    {
        isSwitching = true;

        // 1. Neue Szene additive laden
        AsyncOperation loadOp = SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
        yield return loadOp;

        // 2. Neue Szene aktiv setzen
        Scene inventoryScene = SceneManager.GetSceneByName("MainScene");
        SceneManager.SetActiveScene(inventoryScene);

        // 3. Alte Szene entladen
        AsyncOperation unloadOp = SceneManager.UnloadSceneAsync("Inventory");
        yield return unloadOp;

        isSwitching = false;
    }*/

    public bool IsPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, placementLayermask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }
}
