using System.Numerics;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    [SerializeField]private GameObject foodSpawn;
    [SerializeField]private FoodScript foodScript;
    
    [SerializeField]private FoodSpawner FS;
    [SerializeField]private int foodDecider;
    [SerializeField]private float Speed;
    private UnityEngine.Vector3 FoodPosition;

    void Awake()
    {
        foodSpawn = GameObject.Find("Spawner");
        FS = foodSpawn.GetComponent<FoodSpawner>();
    }

    void Start()
    {
        foodDecider = Random.Range(0,FS.FoodsPos.Count);
        FoodPosition = FS.FoodsPos[foodDecider];
        FS.FoodsPos.Remove(FS.FoodsPos[foodDecider]);
    }
    void Update()
    {
        FollowFood();
    }

    void FollowFood()
    {
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, FoodPosition,Speed*Time.deltaTime);
        if(transform.position == FoodPosition)
        {
            foodDecider = Random.Range(0,FS.FoodsPos.Count);
            FoodPosition = FS.FoodsPos[foodDecider];
            FS.FoodsPos.Remove(FS.FoodsPos[foodDecider]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("Food"))
        {
            foodScript = collision.gameObject.GetComponent<FoodScript>();
            foodScript.IsInfected = true;
            Destroy(gameObject);
        }
    }
}
