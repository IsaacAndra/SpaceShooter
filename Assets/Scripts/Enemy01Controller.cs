using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Controller : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float vel = -3f;
    [SerializeField] private GameObject shot;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform shotPosition;
    private float delayShot = 1f;
    [SerializeField] private float life = 1f;


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
        
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if(visible)
        {
            delayShot -= Time.deltaTime;
            if (delayShot <= 0)
            {
                Instantiate(shot, shotPosition.position, transform.rotation);

                delayShot = Random.Range(1.5f, 2f);
            }
        }
       
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
