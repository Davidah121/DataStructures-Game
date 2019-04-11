using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackObjectScript : MonoBehaviour
{
    [SerializeField] int id = 0; //Not a valid number
    
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
        Controller.c.push(id);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
