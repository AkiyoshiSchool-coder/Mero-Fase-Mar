using UnityEngine;
using UnityEngine.UI;

public class FoodColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AcessibilityColor();
    }

    private void AcessibilityColor()
    {
        if(gameObject.CompareTag("FoodA"))
        {
            if(spriteRenderer != null)
            {
                spriteRenderer.color = GameManagerColor.getColor(0);
            }
            else
            {
                Graphic image = GetComponent<Image>();
                image.color = GameManagerColor.getColor(0);
            }
        }
        if(gameObject.CompareTag("FoodB"))
        {
            if(spriteRenderer != null)
            {
                spriteRenderer.color = GameManagerColor.getColor(1);
            }
            else
            {
                Graphic image = GetComponent<Image>();
                image.color = GameManagerColor.getColor(1);
            }
        }
    }
}