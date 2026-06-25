using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BarraNivel : MonoBehaviour
{
    [SerializeField] private float multiply;
    [SerializeField] private float teste = 0;
    public float qntd;
    [SerializeField] int counter;
    [SerializeField] private int goal;
    Scene scene;
    public GameObject gameMgr;
    private GameManager gameManager;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        gameManager = gameMgr.GetComponent<GameManager>();
    }

    public void FoodCount()
    {
        counter++;
        teste += qntd;
        transform.localScale = new Vector3(teste*multiply,0.65f,1);
        if(teste>=goal)
        {
            Debug.Log("Você venceu");
            if(scene.name == "Level1")
            {
                gameManager.Load("LevelCutscene12");
            }
            else if(scene.name == "Level2")
            {
                gameManager.Load("LevelCutscene23");
            }
            else if(scene.name == "Level3")
            {
                gameManager.Load("Vitoria");
            }
        }
    }
}
