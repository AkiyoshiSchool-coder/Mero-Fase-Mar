using UnityEngine;

public class PescadorScript : MonoBehaviour
{
    public GameObject mero;
    [SerializeField] private int speed = 4;
    [SerializeField] private bool notScared = true;
    private float pescadorRotation;
    Vector2 direction;
    void Start()
    {
        mero = GameObject.Find("Mero");
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
            transform.Translate(Vector3.up * Time.deltaTime * speed*3); // forward evapora
        }
    }

    void RunAway()
    {
        Destroy(gameObject, 5);
        notScared = false;
        transform.rotation = Quaternion.Euler(0, 0, pescadorRotation + 90);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Mero")
        {
            Debug.Log("Game Over!");
        }
        if(collider.tag == "Boom")
        {
            Debug.Log("a");
            RunAway();
        }
    }


}
