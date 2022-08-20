using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Controller : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float vel = -3f;
    [SerializeField] private GameObject shot;
    private float delayShot = 1f;


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
        delayShot -= Time.deltaTime;
        if(delayShot <= 0)
        {
            Instantiate(shot, transform.position, transform.rotation);

            delayShot = Random.Range(1.5f, 2f);
        }

    }
}
