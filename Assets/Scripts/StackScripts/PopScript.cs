using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    private bool isColl = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColl = true;

        GameObject guiObjects = GameObject.Find("S1");

        if(guiObjects!=null)
        {
            guiObjects.GetComponent<GuiKeyScript>().isActive = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject guiObjects = GameObject.Find("S1");

        if (guiObjects != null)
        {
            guiObjects.GetComponent<GuiKeyScript>().isActive = false;
        }
        isColl = false;
    }

    void playSound()
    {
        int tSamples = (int)(GameObject.Find("BOTW_Music").GetComponent<AudioSource>().time / 10.5f);

        if (tSamples % 2 == 0)
        {
            //Assume Major Section
            int tVal = Random.Range(1, 4);
            switch (tVal)
            {
                case 1:
                    GameObject.Find("A2").GetComponent<AudioSource>().Play();
                    break;
                case 2:
                    GameObject.Find("A3").GetComponent<AudioSource>().Play();
                    break;
                case 3:
                    GameObject.Find("A5").GetComponent<AudioSource>().Play();
                    break;
                case 4:
                    GameObject.Find("A8").GetComponent<AudioSource>().Play();
                    break;
                default:
                    break;
            }
        }
        else
        {
            //Assume Minor Section
            int tVal = Random.Range(1, 5);
            switch (tVal)
            {
                case 1:
                    GameObject.Find("A1").GetComponent<AudioSource>().Play();
                    break;
                case 2:
                    GameObject.Find("A3").GetComponent<AudioSource>().Play();
                    break;
                case 3:
                    GameObject.Find("A5").GetComponent<AudioSource>().Play();
                    break;
                case 4:
                    GameObject.Find("A6").GetComponent<AudioSource>().Play();
                    break;
                case 5:
                    GameObject.Find("A7").GetComponent<AudioSource>().Play();
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.c.playing)
        {
            if (isColl)
            {
                if (Controller.c.getSize() > 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        playSound();
                        Controller.c.pop();
                    }
                }

            }
        }
    }
}
