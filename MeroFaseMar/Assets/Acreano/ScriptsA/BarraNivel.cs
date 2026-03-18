using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BarraNivel : MonoBehaviour
{
    private int teste = 0;
    public GameObject victory;
    public GameObject player;

    public void FoodCount()
    {
        teste += 5;
        transform.localScale = new Vector3(teste*0.133f,0.65f,1);
        if(teste>=50)
        {
            Debug.Log("Você venceu");
            // Instantiate(victory, player.transform.position, Quaternion.identity);
        }
    }
}
