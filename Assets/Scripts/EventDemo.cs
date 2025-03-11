using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDemo : MonoBehaviour
{
    public Image spritee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Justpushedbutton()
    {
        Debug.Log ("I just pressed the button");
    }

    public void Alsopushedbutton()
    {
        Debug.Log("I just pressed the button again");
    }

    public void Mouseisnowinside()
    {
        Debug.Log("Mouse had entered the sprite!");
    }

    public void Mouseisnowoutside()
    {
        Debug.Log("Mouse had exited the sprite!");
    }
}
