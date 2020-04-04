using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioS;
    
    public AudioClip JumpS;
    public AudioClip EnemyKS;
    public AudioClip CheckPGS;

    // Start is called before the first frame update
    void Start()
    {
        AudioS = gameObject.GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        AudioS.clip = JumpS;
        AudioS.Play();
    }

    public void PlayCheckPGet()
    {
        AudioS.clip = CheckPGS;
        AudioS.Play();
    }

    public void PlayEnemyKill()
    {
        AudioS.clip = EnemyKS;
        AudioS.Play();
    }
}
