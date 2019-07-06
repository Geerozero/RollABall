using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private int score;
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        winText.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();

        }
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

            else if(other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                score = score - 1;
                SetCountText();
            }
        }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();

        if(count>= 12)
        {
            winText.text = "You win!";
        }
    }
}
