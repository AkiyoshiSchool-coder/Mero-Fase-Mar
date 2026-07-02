using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcessibilityFood : MonoBehaviour
{
    public Color[] colorList = {Color.lightGoldenRod, Color.thistle, Color.paleTurquoise, 
        Color.paleGreen, Color.lightCoral, Color.cornflowerBlue, Color.rosyBrown};
    public GameObject gameManager;
    public GameManagerColor colorManager;
    public int index;
    public int imageIndex; // inspector
    private int limit;
    public Color cor;

    public Image sprite;

    void Start()
    {
        limit = 7;
        colorManager = gameManager.GetComponent<GameManagerColor>();
        cor = GameManagerColor.getColor(imageIndex);
        sprite.color = cor;
    }

    public void changeColor()
    {
        index++;
        if(index == limit)
        {
            index = 0;
        }
        sprite.color = colorList[index];
        GameManagerColor.setColor(imageIndex, colorList[index]);
    }
}