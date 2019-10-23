using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator enemyAnimator;
    public Sprite enemy;
    public Sprite explosion;
    public AudioSource enemyAudio;
    private float time = 1.00F; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        //this.GetComponent<SpriteRenderer>().sprite = explosion;
        enemyAudio.PlayOneShot(enemyAudio.clip);
        enemyAnimator.SetBool("Triggered", true);
        Destroy(gameObject, time);
        Destroy(col.gameObject);
    }
}
