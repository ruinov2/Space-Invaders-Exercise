using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    public Animator enemyAnimator;
    public AudioSource enemyAudio;
    private float time = 1.00F;



    private Vector2 startPosition;
    private Vector2 newPosition;

    public float speed;
    public int maxDistance;
    float minX, maxX, minY, maxY;
    float playerRadius = 0;

    void Start()
    {
        CalculateBoundaries();
        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
        newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
        transform.position = newPosition;
    }

    void LateUpdate()
    {

        UpdatePositionBoundaries();
    }

    void CalculateBoundaries()
    {

        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        //in Start
        CircleCollider2D playerCollider = GetComponent<CircleCollider2D>();
        playerRadius = playerCollider.bounds.extents.x;

        //replace your code with this
        minX = bottomCorner.x + playerRadius;
        maxX = topCorner.x - playerRadius;
        minY = bottomCorner.y + playerRadius;
        maxY = topCorner.y - playerRadius;


    }

    void UpdatePositionBoundaries()
    {

        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;

        // vertical contraint
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
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


