using Unity.VisualScripting;
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
        InvokeRepeating("FoodSpawn", 2.5f, 2f);
    }


    void RandomPositionDefine()
    {
        posX = Random.Range(9.01f, 17.6f);
        posY = Random.Range(5.12f, 9.76f);

        operators = Random.Range(1, 5); // 1 ++ 2 -+ 3 +- 4 --
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
    }
    void FoodSpawn()
    {
        random = Random.Range(0,2);
        RandomPositionDefine();
        if(random == 1)
        {
            Instantiate(FoodA, new Vector3(Mero.transform.position.x + posX, 
            Mero.transform.position.y + posY, 0), Quaternion.identity);
        }
        else if(random == 0)
        {
            Instantiate(FoodB, new Vector3(Mero.transform.position.x + posX, 
            Mero.transform.position.y + posY, 0), Quaternion.identity);
        }
    }

}
