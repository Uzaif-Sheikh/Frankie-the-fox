using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;

    private int damage = 8;


    public int getDamage(){
        return damage;
    }

    private Rigidbody2D body;
    //private SpriteRenderer spriteRenderer;

    void Awake() {
        
        body = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        body.velocity = new Vector2(-speed,body.velocity.y);

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
