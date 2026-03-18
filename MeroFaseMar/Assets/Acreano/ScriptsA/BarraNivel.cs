using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BarraNivel : MonoBehaviour
{
    public int teste;
    void Update()
    {
        FoodCount(teste);
    }

    void FoodCount(int food)
    {
        transform.localScale = new Vector3(food*0.3325f,0.65f,1);
    }
}
