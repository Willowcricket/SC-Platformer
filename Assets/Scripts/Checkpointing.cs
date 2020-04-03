using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointing : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject Player;
    public SpriteRenderer sr;
    public Sprite CheckPNGot;
    public Sprite CheckPGot;
    public bool Got = false;

    public Transform PlayerTrans;
    public Transform trf;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        trf = gameObject.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sr.sprite = CheckPGot;
            Got = true;
        }
    }

    public void RespawnPlayer()
    {
        if (GameManager.instance.PlayerLives != 0)
        {
            //Player.gameObject.transform = trf;
            GameManager.instance.PlayerLives--;
            Debug.Log("Respawning Player");
        }
    }
}
