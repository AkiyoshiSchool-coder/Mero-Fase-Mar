using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction level1action, level2action, level3action, menuaction;
    private static GameManager instance;
    private string cena;
    public GameObject pauseMenu;
    private InputActionMap playerMap;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        level1action = InputSystem.actions.FindAction("Level1");
        level2action = InputSystem.actions.FindAction("Level2");
        level3action = InputSystem.actions.FindAction("Level3");
        menuaction = InputSystem.actions.FindAction("MainMenu");
        playerMap = InputActions.FindActionMap("Player");
    }

    void Update()
    {
        if(level1action.WasPressedThisFrame())
        {
            Load("Level1");
        }
        if(level2action.WasPressedThisFrame())
        {
            Load("LevelCutscene12");
        }
        if(level3action.WasPressedThisFrame())
        {
            Load("LevelCutscene23");
        }
        if(menuaction.WasPressedThisFrame())
        {
            Load("MenuInicial");
        }
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        cena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOver");
    }

    public void Retry()
    {
        SceneManager.LoadScene(cena);
    }

    public void Pause(bool pause)
    {
        pauseMenu.SetActive(pause);
        if(pause)
        {
            Time.timeScale = 0;
            playerMap.Disable();
        }
        else
        {
            Time.timeScale = 1;
            playerMap.Enable();
        }
    }

    public void UnpauseMap()
    {
        Time.timeScale = 1;
        InputActions.FindActionMap("Player").Enable();
        InputActions.FindActionMap("UI").Disable();
    }

    public void EndGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}