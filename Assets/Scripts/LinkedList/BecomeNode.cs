using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeNode : MonoBehaviour
{
    public GameObject becomeNode;
    public Transform nodePos;
    public GameObject Player;
    public GameObject textToDisable;
    public GameObject textToEnable;
    public Node nodeToDisable;
    public AudioSource wowSound;
    public ParticleSystem wowParticles;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(becomeNode, nodePos.position, nodePos.rotation);
            Player.gameObject.SetActive(false);
            textToDisable.gameObject.SetActive(false);
            textToEnable.gameObject.SetActive(true);
            nodeToDisable.gameObject.SetActive(false);
            wowSound.Play();
            wowParticles.Play();           

        }
    }
}
