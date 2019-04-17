using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    [SerializeField] int[] stackItems;
    public void initStack()
    {
        for(int i=0; i<stackItems.Length; i++)
        {
            Controller.c.push(stackItems[i]);
        }
    }
}
