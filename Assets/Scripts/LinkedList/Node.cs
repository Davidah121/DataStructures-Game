using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node next;
    public Node prev;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        next.gameObject.SetActive(true);
        prev.gameObject.SetActive(false);
    }
}