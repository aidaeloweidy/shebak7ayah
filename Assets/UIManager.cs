using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject container_NPC;
    public GameObject container_Player;
    public Text text_NPC;
    public Text[] text_choices;
    public PlayerController player;



    // Start is called before the first frame update
    void Start()
    {
        container_NPC.SetActive(false);
        container_Player.SetActive(false);
        VD.LoadDialogues();
    }


    //  void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Return))
    //     {
    //         if (!VD.isActive)
    //         {
    //             Begin();
    //         }
    //         else
    //         {
    //             VD.Next();
    //         }
    //     }
    // }


    public void Begin(VIDE_Assign target)
    {
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(target);
    }

    void UpdateUI(VD.NodeData data)
    {
        container_NPC.SetActive(false);
        container_Player.SetActive(false);
        if (data.isPlayer)
        {
            container_Player.SetActive(true);

            for (int i = 0; i < text_choices.Length; i++)
            {
                if (i < data.comments.Length)
                {

                    text_choices[i].transform.parent.gameObject.SetActive(true);

                    // container_End.SetActive(true);
                    text_choices[i].text = data.comments[i];
                }
                else
                {

                    text_choices[i].transform.parent.gameObject.SetActive(false);
                }
            }
            EventSystem.current.SetSelectedGameObject(text_choices[0].gameObject.transform.parent.gameObject);
        }
        else
        {
            container_NPC.SetActive(true);
            text_NPC.text = data.comments[data.commentIndex];
        }
    }

    public void End(VD.NodeData data)
    {
        container_NPC.SetActive(false);
        container_Player.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }


    void OnDisable()
    {
        if (container_NPC != null)
        {
            End(null);
            VD.EndDialogue();

        }
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }

    public void SetPlayerChoice(int choice)
    {
        var data = VD.nodeData;
        VD.nodeData.commentIndex = choice;
        if (data.isPlayer)
        {
            // VD.Next();
            Debug.Log("next from Set player choice");
        }

    }
}

