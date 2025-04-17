using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class CheckPlayersItems : MonoBehaviour
{

    public PlayerController player;
    public VIDE_Assign npcObject;
    public bool HasItem = false;


    public bool CheckItemGive(string item)
    {

        GameObject playerItem = player.gameObject;
        if (playerItem.transform.childCount > 0)
        {

            int temp = playerItem.transform.childCount;
            //Debug.Log(temp);
            for (int i = 0; i < temp; i++)
            {

                if (playerItem.transform.GetChild(i).name == item)
                {


                    // npcObject = this.GetComponent<VIDE_Assign>();
                    temp = playerItem.transform.childCount;
                    // GiveItem(i, playerItem);
                    //VD.Next();
                    return true;
                    // Debug.Log("went to give item function");

                }
                // else
                // {

                //     // ChangeNodeID();
                //     // return false;
                // }

            }
        }
        else
        {
            // HasItem = false;
            // if (HasItem == false)
            // {
            ChangeNodeID();
            // }
            return false;
        }
        ChangeNodeID();
        return false;
    }

    public void ChangeNodeID()
    {

        npcObject = this.GetComponent<VIDE_Assign>();

        if (VD.assigned.alias == "room17")
        {
            Debug.Log("you dont have onion");
            VD.SetNode(6);
        }

        if (VD.assigned.alias == "room3")
        {
            Debug.Log("you dont have mostanad");
            VD.SetNode(12);
        }

        if (VD.assigned.alias == "level2npc4")
        {
            Debug.Log("you dont have toilet paper");
            VD.SetNode(7);
        }

        if (VD.assigned.alias == "ragab")
        {
            Debug.Log("you dont have shakshoka");
            VD.SetNode(5);
        }

    }

    public void GiveItem(int index, GameObject owner)
    {
        owner.transform.GetChild(index).parent = this.transform;
        // Debug.Log("item given");
    }
}
