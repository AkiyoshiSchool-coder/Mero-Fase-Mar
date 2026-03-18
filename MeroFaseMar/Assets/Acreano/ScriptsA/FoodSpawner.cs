using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject FoodA;
    public GameObject FoodB;
    public GameObject Mero;
    [SerializeField] int operators = 0;

    private Vector3 RandomPos;

    private float posX, posY;

    private int random;

    void Start()
    {
        InvokeRepeating("RandomDefine", 2.5f, 2f);
    }


    void Update()
    {
        
    }
    // mathf.abs()
    void RandomDefine()
    {
        posX = Random.Range(9.02f, 17.5f);
        posY = Random.Range(5.13f, 9.75f);

        operators = Random.Range(1, 4); // 1 ++ 2 -+ 3 +- 4 --
        if(operators == 2)
        {
            posX = posX*-1;
        }
        else if(operators == 3)
        {
            posY = posY*-1;
        }
        else if(operators == 4)
        {
            posX = posX*-1;
            posY = posY*-1;
        }

        Instantiate(FoodA, new Vector3(Mero.transform.position.x + posX, 
        Mero.transform.position.y + posY, 0), Quaternion.identity);
    }
    //9.02 5.13
    void FoodPositionDecider()
    {
        
    }
    void FoodDecider()
    {
        random = Random.Range(0,1);
    }
    void FoodSpawn(int rand, Vector3 randPos)
    {
        if(rand == 1)
        {
            Instantiate(FoodA, randPos, Quaternion.identity);
        }
    }

}
