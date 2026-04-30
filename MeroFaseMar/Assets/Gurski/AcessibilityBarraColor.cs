using UnityEngine;
using TMPro;

public class AcessibilityBarraColor : MonoBehaviour
{
    private TextMeshProUGUI barra;
    public Color colorA, colorB;
    public GameObject gameManager;
    public GameManagerColor colorManager;
    void Start()
    {
        barra = gameObject.GetComponent<TextMeshProUGUI>();
        colorManager = gameManager.GetComponent<GameManagerColor>();

        barra.colorGradient = new VertexGradient(colorManager.sendColor(0), colorManager.sendColor(1), colorManager.sendColor(0), colorManager.sendColor(1));
    }

    void Update()
    {
        
    }
}
