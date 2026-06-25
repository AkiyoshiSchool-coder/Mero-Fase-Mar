using UnityEngine;
using UnityEngine.UI;

public class RepositionPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 pos;
    public RectTransform objectPos;

    void Start()
    {
        objectPos.anchoredPosition = pos;
    }
}
