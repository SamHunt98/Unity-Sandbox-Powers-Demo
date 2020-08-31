using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightGemDisplay : MonoBehaviour
{
    public isInLight lightLevel;
    public Image gemImage;

    void Update()
    {
        float alpha = lightLevel.visibility;
        Color temp = gemImage.color;
        temp.a = alpha;
        //Debug.Log(alpha);
        gemImage.color = temp;
    }
}
