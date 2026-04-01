using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string cena;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        InvokeRepeating("CenaInicial", 5, 2);
    }

    void CenaInicial()
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
}
