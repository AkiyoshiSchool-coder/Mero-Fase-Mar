using UnityEngine;

public class DiverScript : MonoBehaviour
{
    private GameObject mero;
    public GameObject gameMgr;
    private GameManager gameManager;
    private MeroStats meroStats;
    private PoisonDamage poison;
    [SerializeField] private int speed = 12;
    [SerializeField] private bool notScared = true;
    private float pescadorRotation;
    Vector2 direction;
    private float escapeTime = 5;
    void Start()
    {
        mero = GameObject.Find("Mero");
        meroStats = mero.GetComponent<MeroStats>();
        poison = mero.GetComponent<PoisonDamage>();
        gameManager = gameMgr.GetComponent<GameManager>();

    }

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
            transform.Translate(Vector3.up * Time.deltaTime * speed); // forward evapora
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
        if(collider.name == "Mero")
        {
            if(gameObject.name == "Pescador(Clone)")
            {
                Debug.Log("game over");
                gameManager.GameOver();
            }
            else if(gameObject.name == "Pesquisador(Clone)")
            {
                Debug.Log("cura");
                poison.Heal();
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


}
