using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction level1action, level2action, level3action;

    private string cena;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        InvokeRepeating("CenaInicial", 1, 2);
        level1action = InputSystem.actions.FindAction("Level1");
        level2action = InputSystem.actions.FindAction("Level2");
        level3action = InputSystem.actions.FindAction("Level3");
    }

    void Update()
    {
        if(level1action.WasPressedThisFrame())
        {
            Level1();
        }
        if(level2action.WasPressedThisFrame())
        {
            Level2();
        }
        if(level3action.WasPressedThisFrame())
        {
            Level3();
        }
    }

    public void CenaInicial()
    {
        SceneManager.LoadScene("MenuInicial");
        Debug.Log("kkkk");
        CancelInvoke("CenaInicial");
    }

    public void GameOver()
    {
        cena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOver");
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene(cena);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Vitoria");
    }

    public void Retry()
    {
        SceneManager.LoadScene(cena);
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
