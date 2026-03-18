using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject FoodA;
    public GameObject FoodB;
    public GameObject Mero;

    private Vector3 RandomPos;

    private int random;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//mathf.abs()
    void RandomDefine(float posX, float posY)
    {
        posX = UnityEngine.Random.Range(9.02f,18.04f)
    }
    //9.02 5.13
    void FoodPositionDecider()
    {
        
    }
    void FoodDecider()
    {
        random = UnityEngine.Random.Range(0,1);
    }
    void FoodSpawn(int rand, Vector3 randPos)
    {
        if(rand == 1)
        {
            Instantiate(FoodA, randPos, Quaternion.identity);
        }
    }

}
