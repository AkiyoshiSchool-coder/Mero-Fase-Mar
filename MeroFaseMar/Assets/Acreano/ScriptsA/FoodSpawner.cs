using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<UnityEngine.Vector3> FoodsPos = new List<UnityEngine.Vector3>();
    public List<GameObject> Foods = new List<GameObject>();
    public GameObject FoodA;
    public GameObject FoodB;
    [SerializeField] private GameObject Mero, cursor, barraNivel;
    [SerializeField] int operators = 0;
    private GameObject TempFood;
    private FoodScript TempFoodScript;
    private UnityEngine.Vector3 RandomPos;

    private float posX, posY;

    private int random;

    void Start()
    {
        InvokeRepeating("FoodSpawn", 1f, 0.6f);
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
        if((Mathf.Abs(Mero.transform.position.x)+ Mathf.Abs(posX)) > 34)
        {
            if(Mero.transform.position.x < 0)
            {
                posX = Random.Range(9.02f,18.04f);    
            }
            if(Mero.transform.position.x > 0)
            {
                posX = Random.Range(-18.04f,-9.02f);    
            }
            
        }
        if((Mathf.Abs(Mero.transform.position.y)+ Mathf.Abs(posY)) > 18)
        {
            if(Mero.transform.position.y >0)
            {
                posY = Random.Range(-10.24f,-5.12f);
            }
            if(Mero.transform.position.y < 0)
            {
                posY = Random.Range(5.12f,10.25f);
            }
            
        }
    }
    void FoodSpawn()
    {
        random = Random.Range(0,2);
        RandomPositionDefine();
        if(random == 1)
        {
            RandomPos = new UnityEngine.Vector3(Mero.transform.position.x + posX, Mero.transform.position.y + posY, -1);

            TempFood = Instantiate(FoodA, RandomPos, UnityEngine.Quaternion.identity);
            FoodsPos.Add(RandomPos); 
            Foods.Add(TempFood);

        }
        else if(random == 0)
        {
            RandomPos = new UnityEngine.Vector3(Mero.transform.position.x + posX, Mero.transform.position.y + posY, -1);

            TempFood = Instantiate(FoodB, RandomPos, UnityEngine.Quaternion.identity);
            FoodsPos.Add(RandomPos); 
            Foods.Add(TempFood);
        }
        TempFoodScript = TempFood.GetComponent<FoodScript>();
        TempFoodScript.Init(Mero, cursor, barraNivel, gameObject);
    }

}
