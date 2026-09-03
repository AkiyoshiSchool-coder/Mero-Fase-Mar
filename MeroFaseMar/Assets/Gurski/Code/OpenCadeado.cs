using UnityEngine;
using UnityEngine.UI;

public class OpenCadeado : MonoBehaviour
{
    public GameObject mgr;
    public GameManager gameManager;
    public int levelReq;
    public RawImage lockSprite;
    public Texture openSprite;
    
    void Start()
    {
        gameManager = mgr.GetComponent<GameManager>();
        OpenLock();
    }

    void OpenLock()
    {
        int currentLevel = gameManager.GetLevel();
        if(currentLevel >= levelReq)
        {
            lockSprite.texture = openSprite;
        }
    }
}