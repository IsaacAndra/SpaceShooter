using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieDad : MonoBehaviour
{

    [SerializeField] protected float vel;
    [SerializeField] protected float life;
    [SerializeField] protected GameObject explosion;
    [SerializeField] protected GameObject shot;
    [SerializeField] protected float velocityShot = 5f;
    protected float delayShot = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LostLife(float damage)
    {
        life -= damage;

        if(life <= 0 && transform.position.y < 5f)
        {
            Destroy(gameObject);

            Instantiate(explosion, transform.position, transform.rotation);
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player1"))
        {
            Destroy(gameObject);

            Instantiate(explosion, transform.position, transform.rotation);

            other.gameObject.GetComponent<PlayerController>().LostLife(1);
        }
    }


}
