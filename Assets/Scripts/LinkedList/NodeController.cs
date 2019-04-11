using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    private LinkedList<GameObject> nodes = new LinkedList<GameObject>();

    public Vector2 startNodePostition;
    public float distanceBetweenNodes;
    public int totalNodes;

    public GameObject nodePrefab;

    public GameObject chainPrefab;
    public float chainOffsetX = .29f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalNodes; i++)
        {
            GameObject node = Instantiate(nodePrefab, new Vector3(startNodePostition.x + distanceBetweenNodes * i, startNodePostition.y), Quaternion.identity);
            nodes.AddLast(node);
            Instantiate(chainPrefab, new Vector3(startNodePostition.x + distanceBetweenNodes * i + chainOffsetX, -2.34f), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
