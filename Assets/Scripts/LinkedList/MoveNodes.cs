using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNodes : MonoBehaviour
{
    public Animator anim;
    private bool inTriggerZone = false;
    public GameObject becomeAdd;
    public Transform posOfAdd;

    // Start is called before the first frame update
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
        else
        {
            inTriggerZone = false;
        }
    }
}
