using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    //variables for score/lives/count
    private int count;
    private int score;
    private int lives;
    //adjustable speed
    public float speed;
    //text components dependent on player action
    public Text countText;
    public Text scoreText;
    public Text livesText;
    public Text winText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        winText.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        //quit on hitting escape
        if (Input.GetKey("escape"))
        {
            Application.Quit();

        }
        //call text edits
        SetCountText();
    }
    
    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
        {
            //deactivate other objects with tag of pickup
            if(other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                score = score + 1;
                SetCountText();
            }

            //deactivate enemy when picked up
            else if(other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                lives = lives - 1;
                SetCountText();
            }

            //transitions when all YELLOW pickups on field 1 are picked up
            if(score == 12)
            {
                transform.position = new Vector3(68.19f, transform.position.y, 0);
            }

            if(lives == 0)
            {
                this.gameObject.SetActive(false);
            }
        }

    private void SetCountText()
    {
        //text edits
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        
        //only gets you win when you perfect both boards
        if(score>= 24)
        {
            winText.text = "You win! Winner Winner Chicken Dinner";
        }
        else if(lives == 0)
        {
            winText.text = "You lose..";
        }
    }
}
