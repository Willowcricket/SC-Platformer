using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject Pleyer;

    private void Update()
    {
        if (Pleyer == null)
        {
            Pleyer = GameObject.Find("Player");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.PlayerLives++;
            GameManager.instance.LoadNextScene();
        }
    }
}
