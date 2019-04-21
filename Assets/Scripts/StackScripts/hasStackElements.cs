using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hasStackElements : MonoBehaviour
{
    [SerializeField] int[] elements;
    bool isColl = false;
    [SerializeField] public string loadLevel = "";

    private void DOTHING()
    {
        if (loadLevel != "")
        {
            Controller.c.playing = false;
            int tSamples = (int)(GameObject.Find("BOTW_Music").GetComponent<AudioSource>().time / 10.5f);

            if (tSamples % 2 == 0)
            {
                GameObject.Find("SComplete1").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("SComplete2").GetComponent<AudioSource>().Play();
            }
            Invoke("DelayedAction", 2f);
        }
        else
        {
            //Is a door/ Should be a door
            int tSamples = (int)(GameObject.Find("BOTW_Music").GetComponent<AudioSource>().time / 10.5f);

            if (tSamples % 2 == 0)
            {
                GameObject.Find("SDoor1").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("SDoor2").GetComponent<AudioSource>().Play();
            }

            Destroy(this.gameObject);
        }
    }

    void DelayedAction()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(loadLevel, LoadSceneMode.Single);
    }

// Start is called before the first frame update
void Start()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            switch (elements[i])
            {
                case Controller.GREEN:
                    transform.GetChild(i).GetComponent<KeySprite>().defaultColor =
                        new Color(0f, 1f, 0f);
                    break;
                case Controller.BLUE:
                    transform.GetChild(i).GetComponent<KeySprite>().defaultColor =
                        new Color(0f, 0f, 1f);
                    break;
                case Controller.YELLOW:
                    transform.GetChild(i).GetComponent<KeySprite>().defaultColor =
                        new Color(1f, 1f, 0f);
                    break;
                case Controller.AQUA:
                    transform.GetChild(i).GetComponent<KeySprite>().defaultColor =
                        new Color(0f, 1f, 1f);
                    break;
                case Controller.PURPLE:
                    transform.GetChild(i).GetComponent<KeySprite>().defaultColor =
                        new Color(1f, 0f, 1f);
                    break;
                default:
                    transform.GetChild(i).GetComponent<KeySprite>().defaultColor =
                        new Color(0f, 0f, 0f);
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColl = true;
        int size = Mathf.Min(Controller.c.getSize(), elements.Length);

        int[] things = new int[size];

        for(int i = 0; i < size; i++)
        {
            things[i] = Controller.c.pop();
        }

        KeySprite[] objs = transform.GetComponentsInChildren<KeySprite>();
        GameObject[] guiObjects = Controller.c.s;


        for (int i=0; i<size; i++)
        {
            if (things[i] == elements[i])
            {
                guiObjects[i].GetComponent<GuiKeyScript>().isActive = true;
                objs[i].isActive = true;
            }
            else
            {
                break;
            }
        }

        for(int i=size-1; i>=0; i--)
        {
            Controller.c.push(things[i]);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColl = false;
        KeySprite[] objs = transform.GetComponentsInChildren<KeySprite>();
        GameObject[] guiObjects = Controller.c.s;

        for (int i = 0; i < objs.Length; i++)
        {
            guiObjects[i].GetComponent<GuiKeyScript>().isActive = false;
            objs[i].isActive = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Controller.c.playing)
        {
            if (isColl)
            {
                KeySprite[] objs = transform.GetComponentsInChildren<KeySprite>();

                int size = Mathf.Min(Controller.c.getSize(), elements.Length);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    bool canDo = true;
                    for (int i = 0; i < objs.Length; i++)
                    {
                        if (objs[i].isActive == false)
                        {
                            canDo = false;
                            break;
                        }
                    }

                    if (canDo)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            Controller.c.pop();
                        }

                        GameObject[] guiObjects = Controller.c.s;
                        for (int i = 0; i < guiObjects.Length; i++)
                        {
                            guiObjects[i].GetComponent<GuiKeyScript>().isActive = false;
                        }

                        DOTHING();
                    }
                }
            }
        }
    }
}
