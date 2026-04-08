using UnityEngine;

public class MeroStats : MonoBehaviour
{
    public int FoodA;
    public int FoodB;
    public int Poison;
    public GameObject gameMgr;
    private GameManager gameManager;

    void Start()
    {
        gameManager = gameMgr.GetComponent<GameManager>();
    }

    void Update()
    {
        if(FoodA > 10 -Poison || FoodB > 10 -Poison)
        {
            Debug.Log("Morte Bruta");
            gameManager.GameOver();
        }
    }
}
