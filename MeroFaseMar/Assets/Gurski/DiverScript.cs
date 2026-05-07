using Unity.Mathematics;
using UnityEngine;

public class DiverScript : MonoBehaviour
{
    [SerializeField] private GameObject mero;
    public GameObject gameMgr;
    private GameManager gameManager;
    private MeroStats meroStats;
    private PoisonDamage poison;
    [SerializeField] private float speed = 4;
    [SerializeField] private float scaredSpeedMultiplier;
    [SerializeField] private bool notScared = true;
    private float pescadorRotation;
    Vector2 direction;
    public GameObject damageSound,healingSound;
    private float escapeTime = 5;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(notScared)
        {
            direction = mero.transform.position - transform.position;
            pescadorRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, pescadorRotation - 90);
            transform.position = Vector2.MoveTowards(transform.position, mero.transform.position, speed*Time.deltaTime);
        }
        else if(notScared == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed*scaredSpeedMultiplier); // forward evapora
        }
    }

    void RunAway()
    {
        Destroy(gameObject, escapeTime);
        notScared = false;
        transform.rotation = Quaternion.Euler(0, 0, pescadorRotation + 90);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Head"))
        {
            if(gameObject.name == "Pescador(Clone)")
            {
                Debug.Log("game over");
                Instantiate(damageSound,transform.position,Quaternion.identity);
                gameManager.GameOver();
            }
            else if(gameObject.name == "Pesquisador(Clone)")
            {
                Debug.Log("cura");
                poison.Heal();
                Instantiate(healingSound,transform.position,Quaternion.identity);
                meroStats.Poison = 0;
                Destroy(gameObject);
            }
        }
        if(collider.CompareTag("Boom"))
        {
            if(gameObject.name == "Pescador(Clone)")
            {
                Debug.Log("a");
                RunAway();
            }
        }
    }

    public void Init(GameObject gameobj)
    {
        mero = gameobj;
        meroStats = mero.GetComponent<MeroStats>();
        poison = mero.GetComponent<PoisonDamage>();
        gameManager = gameMgr.GetComponent<GameManager>();
    }


}
