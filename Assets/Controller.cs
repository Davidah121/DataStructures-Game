using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Controller c;
    [SerializeField] public Text myText;

    public Stack<int> gameStack = new Stack<int>();
    public GameObject[] s = new GameObject[8];

    //Constants
    public const int INVALID = 0;
    public const int GREEN = 1;
    public const int BLUE = 2;
    public const int YELLOW = 3;
    public const int AQUA = 4;
    public const int PURPLE = 5;

    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.FindGameObjectsWithTag("GuiList");
        
        c = this;
        gameStack.Clear();
        updateGuiList();
    }

    void updateGuiList()
    {
        for(int i=0; i<s.Length; i++)
        {
            Image proc = s[i].GetComponent<Image>();
            proc.color = new Color(0f, 0f, 0f, 0f);
        }

        int[] oldValues = new int[gameStack.Count];
        
        for (int i=0; i<oldValues.Length; i++)
        {
            oldValues[i] = gameStack.Pop();
            Image proc = s[i].GetComponent<Image>();

            switch (oldValues[i])
            {
                case GREEN:
                    proc.color = new Color(0f, 1f, 0f, 1f);
                    break;
                case BLUE:
                    proc.color = new Color(0f, 0f, 1f, 1f);
                    break;
                case YELLOW:
                    proc.color = new Color(1f, 1f, 0f, 1f);
                    break;
                case AQUA:
                    proc.color = new Color(0f, 1f, 1f, 1f);
                    break;
                case PURPLE:
                    proc.color = new Color(1f, 0f, 1f, 1f);
                    break;
                default:
                    proc.color = new Color(1f, 1f, 1f, 0f);
                    break;
            }
        }

        for(int i=oldValues.Length-1; i>=0; i--)
        {
            gameStack.Push(oldValues[i]);
        }
    }

    public void push(int value)
    {
        gameStack.Push(value);

        updateGuiList();
    }

    public int getSize()
    {
        return gameStack.Count;
    }

    public int pop()
    {
        int value = gameStack.Pop();
        updateGuiList();
        return value;
    }

    public int peek()
    {
        return gameStack.Peek();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
