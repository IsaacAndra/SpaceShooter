using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float velocity = 20f;
    [SerializeField] private GameObject tiro;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBehavior();

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(tiro, transform.position, transform.rotation);
        }
    }

    private void MoveBehavior()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector2 myVelocity = new Vector2(horizontal, vertical);
        myVelocity.Normalize();
        rb.velocity = myVelocity * velocity;
    }
}
