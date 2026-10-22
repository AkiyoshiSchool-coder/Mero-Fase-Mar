using UnityEngine;
using UnityEngine.UI;

public class ResizeRectPlatform : MonoBehaviour
{
    public float sizeX, sizeY;
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        if(Application.platform.Equals(RuntimePlatform.Android))
            rt.sizeDelta = new Vector2(sizeX, sizeY);
    }

    void Update()
    {
        
    }
}
