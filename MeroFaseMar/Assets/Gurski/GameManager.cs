using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction level1action, level2action, level3action, menuaction;
    private string cena;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        InvokeRepeating("CenaInicial", 0.2f, 1); // nunca mais mexer nessa linha
        level1action = InputSystem.actions.FindAction("Level1");
        level2action = InputSystem.actions.FindAction("Level2");
        level3action = InputSystem.actions.FindAction("Level3");
        menuaction = InputSystem.actions.FindAction("MainMenu");
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
        if(menuaction.WasPressedThisFrame())
        {
            CenaInicial();
        }
    }

    public void CenaInicial()
    {
        SceneManager.LoadScene("MenuInicial");
        CancelInvoke("CenaInicial");
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
    public void Cutscene12()
    {
        SceneManager.LoadScene("LevelCutscene1-2");
    }
    public void Cutscene23()
    {
        SceneManager.LoadScene("LevelCutscene2-3");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Vitoria");
    }

    public void Narrativa()
    {
        SceneManager.LoadScene("Narrativa");
    }

    public void Controles()
    {
        SceneManager.LoadScene("Controles");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Créditos");
    }

    public void SaibaMais()
    {
        SceneManager.LoadScene("SaibaMais");
    }

    public void Acessibilidade()
    {
        SceneManager.LoadScene("Acessibilidade");
    }

    public void Voltar()
    {
        SceneManager.LoadScene("MenuInicial");
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
