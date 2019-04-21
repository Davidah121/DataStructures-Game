using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNodes : MonoBehaviour
{
    public Animator anim;
    private bool inTriggerZone = false;
    public GameObject becomeAdd;
    public Transform posOfAdd;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inTriggerZone == true && inTriggerZone != false)
        {
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("Player pressed key");
                anim.Play("NodesShift");
                Instantiate(becomeAdd, posOfAdd.position, posOfAdd.rotation);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in right spot");
            inTriggerZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exit spot.");
            inTriggerZone = false;
        }
    }
}
