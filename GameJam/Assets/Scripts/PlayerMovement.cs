using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    public float speed;
    public Vector3 jumpHeight;
    public int NumberOfJumpsLeft;
    public int MaxNumberOfJumps;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        jumpHeight = new Vector3(0, 6f, 0);
        MaxNumberOfJumps = 2;
        NumberOfJumpsLeft = MaxNumberOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<Animator>().SetBool("IsRunning", true);
        }

        //Movement Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<Animator>().SetBool("IsRunning", true);
        }

        //Not Running
        if(Input.GetAxis("Horizontal") == 0)
        {
            this.GetComponent<Animator>().SetBool("IsRunning", false);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && NumberOfJumpsLeft > 0) 
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            NumberOfJumpsLeft -= 1;
        }
    }


    //Load Death Scene as "Game Over"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("deathmarker"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (other.gameObject.CompareTag("ground"))
        {
            NumberOfJumpsLeft = MaxNumberOfJumps;
        }

    }
}
