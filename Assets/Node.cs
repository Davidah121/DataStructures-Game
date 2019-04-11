using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node next;
    public Node prev;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        next.gameObject.SetActive(true);
        prev.gameObject.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       // gameObject.SetActive(false);
    }
}