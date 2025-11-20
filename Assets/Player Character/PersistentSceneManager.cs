using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentSceneManager : MonoBehaviour
{
    public static PersistentSceneManager Instance;

    private string sceneA = "Test Scene";
    private string sceneB = "Inventory";

    private string currentScene = "";

    private void Awake()
    {
        // Singleton: nur ein einziges Exemplar behalten
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);    // überlebt Szenenwechsel
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private IEnumerator Start()
    {
        // Beide Szenen laden (falls sie noch nicht geladen sind)
        yield return LoadIfNotLoaded(sceneA);
        yield return LoadIfNotLoaded(sceneB);

        // Inventory ausblenden, MainScene sichtbar machen
        SetSceneObjectsActive(sceneB, false);
        SetSceneObjectsActive(sceneA, true);
        currentScene = sceneA;

        // Aktive Szene setzen
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneA));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleScenes();
        }
    }

    // -------------------------------------------------------
    // Scene Switching
    // -------------------------------------------------------

    public void ToggleScenes()
    {
        if (currentScene == sceneA)
        {
            SwitchToScene(sceneB, sceneA);
        }
        else
        {
            SwitchToScene(sceneA, sceneB);
        }
    }

    private void SwitchToScene(string target, string previous)
    {
        // Sichtbarkeit umschalten
        SetSceneObjectsActive(previous, false);
        SetSceneObjectsActive(target, true);

        // Aktive Szene setzen
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(target));

        currentScene = target;
    }

    // -------------------------------------------------------
    // Szene laden (falls nötig)
    // -------------------------------------------------------

    private IEnumerator LoadIfNotLoaded(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (!scene.isLoaded)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }

    // -------------------------------------------------------
    // Alle Objekte einer Szene sichtbar/unsichtbar schalten
    // -------------------------------------------------------

    private void SetSceneObjectsActive(string sceneName, bool active)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (!scene.isLoaded) return;

        foreach (GameObject go in scene.GetRootGameObjects())
        {
            go.SetActive(active);
        }
    }
}

