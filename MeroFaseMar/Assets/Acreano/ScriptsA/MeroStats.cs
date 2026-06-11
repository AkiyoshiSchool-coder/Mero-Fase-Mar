using UnityEngine;

public class MeroStats : MonoBehaviour
{
    public int FoodCount;
    public int Poison;
    public int PescadorCount;
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
            // gameManager.Load("GameOver");
        }
    }
    public void PescadorAumenta(int num)
    {
        PescadorCount += num;
    }
}
