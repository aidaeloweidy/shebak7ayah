using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    public Sprite Fridge_Open;
    public Sprite Fridge_Closed;
    private bool z_Interacted = false;
    protected override void OnCollided(GameObject collidedObject)
    {
      if (Input.GetKey(KeyCode.E)) 
      {
        OnInteract();
      }
    }

    protected virtual void OnInteract()
     {
    if (!z_Interacted)
    {
        z_Interacted = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Fridge_Open;
        Debug.Log("interact with" + name);
    } 
     }
}
