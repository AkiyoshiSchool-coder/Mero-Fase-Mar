using UnityEngine;

public class AbrigoDetection : MonoBehaviour
{
    public GameObject player;
    private MeroBoom mero;
    void Start()
    {
        mero = player.GetComponent<MeroBoom>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Head"))
        {
            mero.Abrigo(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Head"))
        {
            mero.Abrigo(false);
        }
    }
}
