using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public InputActionAsset InputActions;
   // private InputAction level1action, level2action, level3action, menuaction;
    public static GameManager instance;
    public string cena;
    public GameObject pauseMenu;
    private InputActionMap playerMap;
    [SerializeField] private int levelsUnlocked = 1;

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
        /* level1action = InputSystem.actions.FindAction("Level1");
        level2action = InputSystem.actions.FindAction("Level2");
        level3action = InputSystem.actions.FindAction("Level3");
        menuaction = InputSystem.actions.FindAction("MainMenu"); */
        playerMap = InputActions.FindActionMap("Player");
    }

   /* void Update()
    {
        if(level1action.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Level1");
        }
        if(level2action.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Level3");
        }
        if(level3action.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Level3");
        }
        if(menuaction.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Level3");
        }
    } */

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel2()
    {
        if(GameManager.instance.levelsUnlocked >= 2)
        {
            SceneManager.LoadScene("LevelCutscene12");
        }
    }

    public void LoadLevel3()
    {
        if(GameManager.instance.levelsUnlocked >= 3)
        {
            SceneManager.LoadScene("LevelCutscene23");
        }
    }

    public void LevelUp(int level)
    {
        if(level > levelsUnlocked)
        {
            levelsUnlocked = level;
        }
    }

    public void GameOver()
    {
        GameManager.instance.cena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOver");
    }

    public void Retry()
    {
        SceneManager.LoadScene(GameManager.instance.cena);
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

    public int GetLevel()
    {
        return levelsUnlocked;
    }
}