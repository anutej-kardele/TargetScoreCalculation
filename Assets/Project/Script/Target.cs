using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Texture2D refrenceTexture;
    private Color pixelColor = Color.white;


    public void CalculateScore(Vector2 hitCoordinate){

        // Debug.Log("Received texture coordinates : " + hitCoordinate);

        hitCoordinate.x *= refrenceTexture.width;
        hitCoordinate.y *= refrenceTexture.height;

        pixelColor = refrenceTexture.GetPixel((int)hitCoordinate.x, (int)hitCoordinate.y);

        //Debug.Log("Score : " + GetScore(pixelColor));
        DisplayScore.instance.IncrementScore(GetScore(pixelColor));
    }

    private int GetScore(Color color){

        if(color == Color.green) return 10;                // code 00FF00
        if(color == Color.blue) return 9;                  // code 0000FF 
        if(color == Color.cyan) return 8;                  // code 00FFFF 
        if(color == Color.yellow) return 7;                // code FFEB04
        if(color == Color.magenta) return 6;               // code FF00FF
        else if(color == Color.red) return 5;              // code FF0000
        else return 0;

    }
}
