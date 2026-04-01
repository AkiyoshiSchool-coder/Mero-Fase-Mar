using System.Numerics;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    [SerializeField]private GameObject foodSpawn;
    [SerializeField]private FoodSpawner FS;
    [SerializeField]private int foodDecider;
    [SerializeField]private float Speed;

    void Awake()
    {
        foodSpawn = GameObject.Find("Spawner");
        FS = foodSpawn.GetComponent<FoodSpawner>();
    }

    void Start()
    {
        foodDecider = Random.Range(0,FS.Foods.Count);
    }
    void Update()
    {
        FollowFood();
    }

    void FollowFood()
    {
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, FS.Foods[foodDecider],Speed);
    }
}
