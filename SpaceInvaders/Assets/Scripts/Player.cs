using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 5f;
    public GameObject character;
    //FIRE
    public GameObject shoot;
    public Transform shootSpawn;
    public float fireRate;
    private float nextFire;

    private float minX, maxX, minY, maxY;
    private float playerRadius = 0;


    // Use this for initialization
    void Start()
    {
        CalculateBoundaries();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerControl();

        PlayerFire();


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

    void UpdatePositionBoundaries() {

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

    void PlayerControl() {

        float h = Input.GetAxis("Horizontal") * Speed;
        character.transform.Translate(h * Time.deltaTime, 0, 0);
    }

    void PlayerFire()
    {

        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
        }
    }
}
