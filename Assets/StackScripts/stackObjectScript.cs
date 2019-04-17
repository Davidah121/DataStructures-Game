using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackObjectScript : MonoBehaviour
{
    [SerializeField] int id = 0; //Not a valid number
    [SerializeField] GameObject partObject;

    // Start is called before the first frame update
    void Start()
    {
        switch(id)
        {
            case Controller.GREEN:
                GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
                break;
            case Controller.BLUE:
                GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);
                break;
            case Controller.YELLOW:
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 1f);
                break;
            case Controller.AQUA:
                GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 1f);
                break;
            case Controller.PURPLE:
                GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 1f, 1f);
                break;
            default:
                GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        int tSamples = (int)(GameObject.Find("BOTW_Music").GetComponent<AudioSource>().time/10.5f);

        if (tSamples%2 == 0)
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
        Vector3 tempVec = this.transform.position;
        tempVec.z = -1;
        Quaternion q = Quaternion.Euler(90, 0, 0);
        
        GameObject.Instantiate(partObject, tempVec, q);
        
        Controller.c.push(id);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
