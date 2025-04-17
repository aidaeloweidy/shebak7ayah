using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class makeMeActive : MonoBehaviour
{
    Button me;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    void OnEnable()
    {
        me = GetComponent<Button>();
        me.Select();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
