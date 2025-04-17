using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VIDE_Data;



public class PlayerController : MonoBehaviour
{
    public UIManager diagUI;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    public GameObject container_Item;
    public Text text_item;

    public VIDE_Assign inTrigger;
    public TimeController time;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // public List<string> player_Items = new List<string>();
    // public List<string> player_ItemInventory = new List<string>();

    // fix sprite renderer walking anim issue

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = other.GetComponent<VIDE_Assign>();
        }
    }

    void OnTriggerExit2D()
    {
        inTrigger = null;
        //Debug.Log("interacted");
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        container_Item.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TryInteract();

        }
    }


    public void CheckItemTake(string item)
    {


        GameObject owner = inTrigger.gameObject;
        if (owner.transform.childCount > 0)
        {

            for (int i = 0; i < owner.transform.childCount; i++)
            {
                if (owner.transform.GetChild(i).name == item)
                {
                    TakeItem(i, owner);
                    // Debug.Log("take item called");
                }
            }
        }
    }


    public void TakeItem(int index, GameObject owner)
    {
        StartCoroutine(showThenFade(index, owner));
        Debug.Log("entered take item");
        owner.transform.GetChild(index).parent = this.transform;
        Debug.Log("item taken");

    }

    public void FixedUpdate()
    {
        if (!VD.isActive)
        {
            //if (time.currentTime !<= 0) {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }

                }


                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (movementInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private bool TryMove(Vector2 direction)
    {


        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
            );

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }


    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void TryInteract()
    {

        if (inTrigger)
        {
            if (!VD.isActive)
            {
                diagUI.Begin(inTrigger);

                if (container_Item.activeSelf)
                {
                    container_Item.SetActive(false);
                }
                Debug.Log("Try interact begin dialog");
            }
            else
            {
                Debug.Log("Next from try interact");
                VD.Next();
            }

        }
    }

    public IEnumerator showThenFade(int index, GameObject owner)
    {
        //Debug.Log(owner.transform.GetChild(index).name);
        string text = owner.transform.GetChild(index).name + " ﻲﺘﻗﻮﻟﺩ ﻙﺎﻌﻣ";
        container_Item.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = text;
        Debug.Log(text);
        container_Item.SetActive(true);
        yield return new WaitForSeconds(4);
        container_Item.SetActive(false);

    }
}

