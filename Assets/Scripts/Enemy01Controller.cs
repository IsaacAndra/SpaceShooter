using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Controller : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float vel = -3f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, vel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
