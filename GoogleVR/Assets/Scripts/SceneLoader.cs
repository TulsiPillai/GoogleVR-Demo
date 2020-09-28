using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneLoader : MonoBehaviour
{
    private const string TELEPORT_SCENE = "TeleportScene";
    private const string FLIGHT_SCENE = "FlyScene";
    public static SceneLoader instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        XRSettings.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnFlightClicked()
    {
        SceneManager.LoadSceneAsync(FLIGHT_SCENE);
    }

    public void OnTeleportClicked()
    {
        SceneManager.LoadSceneAsync(TELEPORT_SCENE);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == TELEPORT_SCENE || scene.name == FLIGHT_SCENE)
            XRSettings.enabled = true;
    }
}
