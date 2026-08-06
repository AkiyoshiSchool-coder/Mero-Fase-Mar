using UnityEngine;

public class MoveBarrinha : MonoBehaviour
{
    public void MoveBarra(float amount)
    {
        transform.localScale = new Vector3(transform.localScale.x + amount/5, 
        transform.localScale.y, transform.localScale.z);
    }
    public void ResetBarra(float amount)
    {
        transform.localScale = new Vector3(amount, transform.localScale.y,
        transform.localScale.z);
    }
}