using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiKeyScript : MonoBehaviour
{
    public bool isActive = false;
    public Color defaultColor;
    private float v = 0;
    private bool goBack = false;

    // Start is called before the first frame update
    void Start()
    {
        //defaultColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Color newCol = new Color(defaultColor.r + v, defaultColor.g + v, defaultColor.b + v);

            GetComponent<Image>().color = newCol;

            if (goBack)
            {
                v -= 4f / 256f;

                if (v <= 0f)
                {
                    v = 0f;
                    goBack = false;
                }
            }
            else
            {
                v += 4f / 256f;

                if (v >= 1f)
                {
                    v = 1f;
                    goBack = true;
                }
            }
        }
        else
        {
            v = 0f;
            GetComponent<Image>().color = defaultColor;
        }
    }
}
