using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StairClimb : MonoBehaviour
{
    public Collider2D stairs;
    public bool isPlayerColliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.W) && isPlayerColliding)
        {
            stairs.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag ==  "Player")
        {
            isPlayerColliding = true;  
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerColliding = false;
        stairs.enabled = false;
    }
}
