using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTouch : MonoBehaviour
{
    public float delay = 440;

    public string levelToLoad;

    public string sceneName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Invoke("DelayedAction", delay);
        }
    }

    void DelayedAction()
    {
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
