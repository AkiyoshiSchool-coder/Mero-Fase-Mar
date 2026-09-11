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
    public void FoodCounter(int value)
    {
        FoodCount += value;
        
        if(FoodCount >= 10-Poison || FoodCount <= -10+Poison)
        {
            GameManager.instance.GameOver();
        }
    }
    public void PoisonUpper()
    {
        Poison++;
    }
}
