using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Controller : EnemieDad
{

    private Rigidbody2D rb;
    [SerializeField] private Transform shotPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * vel;

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
            var player = FindObjectOfType<PlayerController>();

            if (player)
            {
                delayShot -= Time.deltaTime;
                if (delayShot <= 0)
                {
                    var myShot = Instantiate(shot, shotPosition.position, transform.rotation);
                    Vector2 direction = player.transform.position - myShot.transform.position;
                    direction.Normalize();
                    myShot.GetComponent<Rigidbody2D>().velocity = direction * velocityShot;


                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    myShot.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);

                    delayShot = Random.Range(1.5f, 3f);
                }
            }
        }
    }


}
