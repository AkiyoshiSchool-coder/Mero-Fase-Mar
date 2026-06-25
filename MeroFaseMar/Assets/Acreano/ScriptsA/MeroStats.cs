using UnityEngine;

public class MeroStats : MonoBehaviour
{
    public int FoodCount;
    public int Poison;
    public int PescadorCount;
    public GameObject gameMgr;
    private GameManager gameManager;
    [SerializeField] private GameObject botao;
    [SerializeField] private int pescButton;

    void Start()
    {
        gameManager = gameMgr.GetComponent<GameManager>();
    }

    void Update()
    {
        
    }
    public void PescadorAumenta(int num)
    {
        PescadorCount += num;
        if(PescadorCount >= pescButton)
        {
            botao.SetActive(true);
        }
    }
    public void FoodCounter()
    {
        FoodCount++;
        
        if(FoodCount >= 10-Poison || FoodCount <= -10+Poison)
        {
            Debug.Log("Morte Bruta");
            // gameManager.Load("GameOver");
        }
    }
    public void PoisonUpper()
    {
        Poison++;
    }
}
