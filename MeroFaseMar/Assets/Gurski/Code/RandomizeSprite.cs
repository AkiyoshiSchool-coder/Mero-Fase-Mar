using UnityEngine;

public class RandomizeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer objectSprite;
    private float randomScale;
    private float randomRotation;

    void Start()
    {
        randomRotation = Random.Range(0f, 360.1f);
        randomScale = Random.Range(0.8f, 1.2f);
        objectSprite.sprite = sprites[Random.Range(0, 4)];
        gameObject.transform.localScale = new Vector3(randomScale, randomScale, 1);
        gameObject.transform.Rotate(0, 0, randomRotation, Space.World);
    }
}