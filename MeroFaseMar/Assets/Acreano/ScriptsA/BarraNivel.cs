using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BarraNivel : MonoBehaviour
{
    private int teste = 0;

    public void FoodCount()
    {
        teste += 1;
        transform.localScale = new Vector3(teste*0.3325f,0.65f,1);
    }
}
