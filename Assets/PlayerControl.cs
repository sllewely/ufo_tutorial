using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float speed;
    public Text countText;
    public Text winText;

	private Rigidbody2D rb2d;
    private int count;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        SetCountText();
        winText.text = "";
    }
	
//	// Update is called once per frame before rendering a frame
//	void Update () {
//		
//	}

	// Called just before performing any physics calculations
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	// whenever touch a collider
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
            count++;
            SetCountText();
        }
	}

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winText.text = "Congrats!!";
        }
    }
}
