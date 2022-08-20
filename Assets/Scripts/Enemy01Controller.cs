using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Controller : EnemieDad
{

    private Rigidbody2D rb;
    [SerializeField] private Transform shotPosition;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, vel);

        delayShot = Random.Range(0.5f, 2f);


    }

    // Update is called once per frame
    void Update()
    {

        Shooting();
    }

    private void Shooting()
    {
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visible)
        {
            delayShot -= Time.deltaTime;
            if (delayShot <= 0)
            {
                var myShot = Instantiate(shot, shotPosition.position, transform.rotation);
                myShot.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocityShot;  
                delayShot = Random.Range(1.5f, 2f);
            }
        }
    }
}
