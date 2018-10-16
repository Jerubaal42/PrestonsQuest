using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxes : MonoBehaviour
{
    public GameObject player;
    public Canvas FlyingBirds;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnMouseDown()
    {
            
        if(Time.timeScale == 0 && FlyingBirds.enabled == true)
        {
            Time.timeScale = 1;
            FlyingBirds.enabled = false;
        }
        else
        {

            Time.timeScale = 0;
            FlyingBirds.enabled = true;
        }
            
    }
}
