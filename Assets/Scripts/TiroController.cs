using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private GameObject impact;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Going to the UP
        //rb.velocity = new Vector2(0f, vel);
    }
 
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Enemie"))
        {
            collision.GetComponent<EnemieDad>().LostLife(1);
        }
        
        if(collision.CompareTag("Player1"))
        {
            collision.GetComponent<PlayerController>().LostLife(1);
        }


        Destroy(gameObject);


        Instantiate(impact, transform.position, transform.rotation); 

    }


}
