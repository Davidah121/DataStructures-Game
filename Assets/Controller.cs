using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller c;

    public Stack<int> gameStack = new Stack<int>();

    // Start is called before the first frame update
    void Start()
    {
        gameStack.Clear();
    }

    void push(int value)
    {
        gameStack.Push(value);
    }

    int getSize()
    {
        return gameStack.Count;
    }

    int pop()
    {
        return gameStack.Pop();
    }

    int peek()
    {
        return gameStack.Peek();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
