﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject CheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CheckPoint.gameObject.GetComponent<Checkpointing>().RespawnPlayer();
            GameManager.instance.GetComponent<SoundManager>().PlayEnemyKill();
            Debug.Log("Enemy Has hit Player");
        }
    }
}
