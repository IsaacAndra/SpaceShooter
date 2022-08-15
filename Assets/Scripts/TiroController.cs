using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float vel = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Going to the UP
        rb.velocity = new Vector2(0f, vel);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
