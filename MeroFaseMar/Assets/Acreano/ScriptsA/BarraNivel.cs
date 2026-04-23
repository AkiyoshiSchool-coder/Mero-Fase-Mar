using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BarraNivel : MonoBehaviour
{
    private float teste = 0;
    public float qntd;
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
        teste += qntd;
        transform.localScale = new Vector3(teste*0.0665f,0.65f,1);
        if(teste>=100)
        {
            Debug.Log("Você venceu");
            if(scene.name == "Level1")
            {
                gameManager.Cutscene12();
            }
            else if(scene.name == "Level2")
            {
                gameManager.Cutscene23();
            }
            else if(scene.name == "Level3")
            {
                gameManager.Victory();
            }
        }
    }
}
