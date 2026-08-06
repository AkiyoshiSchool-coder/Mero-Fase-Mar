using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Vector2 direction;
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
            transform.rotation = Quaternion.Euler(0, 0, pescadorRotation - 90); // olha pro peixe
            transform.position = Vector2.MoveTowards(transform.position, mero.transform.position, speed*Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed*scaredSpeedMultiplier); // vector3.forward evapora
        }
    }

    void RunAway()
    {
        Destroy(gameObject, escapeTime);
        notScared = false;
        transform.rotation = Quaternion.Euler(0, 0, pescadorRotation + 90); // vira de costas pro peixe
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Head"))
        {
            if(gameObject.CompareTag("Pescador"))
            {
                if(SceneManager.GetActiveScene().name != "LevelCutscene23")
                {
                    gameManager.GameOver();
                }
            }
            else if(gameObject.CompareTag("Pesquisador"))
            {
                poison.Heal();
                meroStats.Poison = 0;
            }
            Destroy(gameObject);
        }

        if(collider.CompareTag("Boom"))
        {
            if(gameObject.CompareTag("Pescador"))
            {
                RunAway();
                meroStats.PescadorAumenta(1);
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