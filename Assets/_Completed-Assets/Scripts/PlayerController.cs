using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text winText;
    public float speed;
    public Text countText;
    private Rigidbody2D rb2d;
    private int count;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        winText.text = "";
        SetCountText ();
    }

    void FixedUpdate()
    {
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");
    Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
    rb2d.AddForce(movement * speed);
    }

    
     void OnTriggerEnter2D(Collider2D other) 
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))

        //... then set the other object we just collided with to inactive.
        other.gameObject.SetActive(false);

        //Add one to the current value of our count variable.
        count = count + 1;

        //Update the currently displayed count by calling the SetCountText function.
        SetCountText ();
    }

    //This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        countText.text = "Count: " + count.ToString ();

        //Check if we've collected all 12 pickups. If we have...
        if (count >= 12)
            //... then set the text property of our winText object to "You win!"
            winText.text = "You win!";
    }
}