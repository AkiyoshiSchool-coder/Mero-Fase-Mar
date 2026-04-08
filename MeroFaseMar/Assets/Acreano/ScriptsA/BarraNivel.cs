using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BarraNivel : MonoBehaviour
{
    private int teste = 0;
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
        teste += 5;
        transform.localScale = new Vector3(teste*0.133f,0.65f,1);
        if(teste>=50)
        {
            Debug.Log("Você venceu");
            if(scene.name == "Level1")
            {
                gameManager.Level2();
            }
            else if(scene.name == "Level2")
            {
                gameManager.Level3();
            }
            else if(scene.name == "Level3")
            {
                gameManager.Victory();
            }
        }
    }
}
