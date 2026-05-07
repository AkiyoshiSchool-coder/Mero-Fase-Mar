using UnityEngine;

public class AbrigoDetection : MonoBehaviour
{
    public GameObject player;
    private MeroBoom mero;
    void Start()
    {
        mero = player.GetComponent<MeroBoom>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("head"))
        {
            mero.Abrigo(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("head"))
        {
            mero.Abrigo(false);
        }
    }
}
