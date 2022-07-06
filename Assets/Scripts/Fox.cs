using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fox : MonoBehaviour
{
    [SerializeField]
    private float speed = 7.5f;

    [SerializeField]
    private float jump = 14f;

    public Slider slider;

    private int health = 50;

    private bool onGround = true;

    private float moveX;

    private Rigidbody2D boby;

    private SpriteRenderer sr;

    private Animator anim;

    private void Awake(){

        boby = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    public void setHealth(int newHealth){
        slider.value = newHealth;
        this.health = newHealth;
    }

    public int getHealth(){
        return health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        move();
        foxJump();
        moveanimation();
        checkDeath();
    }

    private void checkDeath(){
        if(health <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }


    public void move(){

        moveX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(moveX,0f,0f) * Time.deltaTime * speed;

    }

    private void foxJump(){

        if((Input.GetButtonDown("Jump") || (Input.GetAxisRaw("Vertical") > 0)) && onGround){
            onGround = false;
            boby.AddForce(new Vector2(0f,jump),ForceMode2D.Impulse);
        }

        if((Input.GetAxisRaw("Vertical") < 0)){
            boby.AddForce(new Vector2(0f,-3f),ForceMode2D.Impulse);    
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            onGround = true;
        }
    }

    private void moveanimation(){

        anim.SetBool("Walk",false);

        if(moveX > 0){
            sr.flipX = false;
            anim.SetBool("Walk",true);
        }
        else if(moveX < 0){
            sr.flipX = true;
            anim.SetBool("Walk",true);
        }


    }

}
