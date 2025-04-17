using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D rb;
    public bool isWalking;
   

    public Vector2 facing;
    public float collisionOffset = 0.05f;
  

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Animator anim;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
 
 void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
         
 }
 

 void Update ()
    {
        if(isWalking == false)
        {
            facing.x = 0;
            facing.y = 0;
        }

  if(isWalking == true)
        {
            walkCounter -= Time.deltaTime;
           

            switch (walkDirection)
            {


                case 0:
                    rb.velocity = new Vector2(0, moveSpeed);
                    facing.y = 1;
                    facing.x = 0;
                    break;

                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    facing.x = 1;
                    facing.y = 0;
                    transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
                    break;

                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    facing.y = -1;
                    facing.x = 0;
                    break;

                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    facing.y = 0;
                    facing.x = -1;
                    transform.localScale = new Vector3(0.4f, 0.4f, 1f);

                    break;



                    

            }
        

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }

        else
        {
           rb.velocity = Vector2.zero;

            waitCounter -= Time.deltaTime;

            if(waitCounter < 0)
            {
                ChooseDirection();

            }
        }

        // anim.SetFloat("YourFloat", facing.x);
        // anim.SetFloat("YourFloat", facing.y);
        // anim.SetBool("YourBool", isWalking);
    }

    void FixedUpdate()
    { 
        
	//Length of the ray
	float laserLength = 4f;
    int layerMask = LayerMask.GetMask("Block", "Player");
	//Get the first object hit by the ray
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, laserLength, layerMask, 0);


	//If the collider of the object hit is not NUll
	if (hit.collider != null)
	{
		//Hit something, print the tag of the object
		//Debug.Log("Hitting: " + hit.collider.name);
        isWalking = false;
	}

	
	
}
    

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("OnCollisionEnter2D");
    }
}
