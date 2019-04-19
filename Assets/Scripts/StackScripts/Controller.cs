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

    public bool playing = true;

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
        s[0] = GameObject.Find("S1");
        s[1] = GameObject.Find("S2");
        s[2] = GameObject.Find("S3");
        s[3] = GameObject.Find("S4");
        s[4] = GameObject.Find("S5");
        s[5] = GameObject.Find("S6");
        s[6] = GameObject.Find("S7");
        s[7] = GameObject.Find("S8");

        c = this;
        gameStack.Clear();
        updateGuiList();

        GetComponent<StartScript>().initStack();
    }

    void updateGuiList()
    {
        for(int i=0; i<s.Length; i++)
        {
            GuiKeyScript proc = s[i].GetComponent<GuiKeyScript>();
            proc.defaultColor = new Color(0f, 0f, 0f, 0f);
        }

        int[] oldValues = new int[gameStack.Count];
        
        for (int i=0; i<oldValues.Length; i++)
        {
            oldValues[i] = gameStack.Pop();
            GuiKeyScript proc = s[i].GetComponent<GuiKeyScript>();

            switch (oldValues[i])
            {
                case GREEN:
                    proc.defaultColor = new Color(0f, 1f, 0f, 1f);
                    break;
                case BLUE:
                    proc.defaultColor = new Color(0f, 0f, 1f, 1f);
                    break;
                case YELLOW:
                    proc.defaultColor = new Color(1f, 1f, 0f, 1f);
                    break;
                case AQUA:
                    proc.defaultColor = new Color(0f, 1f, 1f, 1f);
                    break;
                case PURPLE:
                    proc.defaultColor = new Color(1f, 0f, 1f, 1f);
                    break;
                default:
                    proc.defaultColor = new Color(1f, 1f, 1f, 0f);
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
