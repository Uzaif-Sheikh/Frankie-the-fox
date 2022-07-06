using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{

    [HideInInspector]
    public float speed = 4f;

    private int damage = 4;

    private Rigidbody2D body;
    //private SpriteRenderer spriteRenderer;

    public int getDamage(){
        return damage;
    }

    void Awake() {
        
        body = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        body.velocity = new Vector2(speed,body.velocity.y);

    }



    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("Fox")){

            //Fox fox = other.gameObject.GetComponent<Fox>();

            int health = other.gameObject.GetComponent<Fox>().getHealth();
            health -= damage;
            other.gameObject.GetComponent<Fox>().setHealth(health);
        }

    }

}
