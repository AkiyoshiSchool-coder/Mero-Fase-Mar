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

        barra.colorGradient = new VertexGradient(GameManagerColor.getColor(0), GameManagerColor.getColor(1), GameManagerColor.getColor(0), GameManagerColor.getColor(1));
    }

}
