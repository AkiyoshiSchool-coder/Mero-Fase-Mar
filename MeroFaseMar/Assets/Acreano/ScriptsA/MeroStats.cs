using UnityEngine;

public class MeroStats : MonoBehaviour
{
    public int FoodCount;
    public int qntd;
    public int Poison;
    public GameObject gameMgr;
    private GameManager gameManager;

    void Start()
    {
        gameManager = gameMgr.GetComponent<GameManager>();
    }

    void Update()
    {
        if(FoodCount >= 10-Poison || FoodCount <= -10+Poison)
        {
            Debug.Log("Morte Bruta");
            // gameManager.GameOver();
        }
    }
}
