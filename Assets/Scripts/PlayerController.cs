using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float velocity = 20f;
    [SerializeField] private GameObject tiro;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform shotPosition;
    [SerializeField] private float life = 3f;

    [SerializeField] private float velShot = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBehavior();
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           GameObject shot = Instantiate(tiro, shotPosition.position, transform.rotation);

            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velShot);

        }
    }

    private void MoveBehavior()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var myVelocity = new Vector2(horizontal, vertical);
        myVelocity.Normalize();
        rb.velocity = myVelocity * velocity;
    }

    public void LostLife(float damage)
    {
        life -= damage;

        if(life <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }

    }

}
