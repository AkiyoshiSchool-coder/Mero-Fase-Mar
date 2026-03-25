using UnityEngine;

public class TrashMove : MonoBehaviour
{
    [SerializeField]private GameObject foodSpawn;
    [SerializeField]private FoodSpawner FS;
    [SerializeField]private int foodDecider;

    void Awake()
    {
        foodSpawn = GameObject.Find("Spawner");
        FS = foodSpawn.GetComponent<FoodSpawner>();
    }

    void Update()
    {
        
    }
}
