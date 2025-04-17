using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTriggerColor : MonoBehaviour
{

   SpriteRenderer sprite;

   void Start() {
            sprite = GetComponent<SpriteRenderer>();
    }
   
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player") {
             sprite.color = new Color (0.7f, 0.4f, 1f, 0.9f);
 }
        
    }

    void OnTriggerExit2D() {
        sprite.color = Color.white;
    }
}
