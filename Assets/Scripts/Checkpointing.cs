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
    public Transform trf;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        trf = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Player == null)
        {
            Player = GameManager.instance.Player;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Got != true)
            {
                sr.sprite = CheckPGot;
                Got = true;
                GameManager.instance.GetComponent<SoundManager>().PlayCheckPGet();
            }
        }
    }

    public void RespawnPlayer()
    {
        if (GameManager.instance.PlayerLives != 0)
        {
            if (Got == true)
            {
                GameManager.instance.Player.transform.position = this.gameObject.transform.position;
            }
            else
            {
                GameManager.instance.Player.transform.position = new Vector2(0.0f, 0.0f);
            }
            GameManager.instance.PlayerLives--;
            Debug.Log("Respawning Player");
        }
        else
        {
            GameManager.instance.LoadLevel(4);
        }
    }
}
