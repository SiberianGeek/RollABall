using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    private int count;
    public Text countText;
    public Text winText;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }

    // Update is called once per frame
    void Update () {
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("PickUp"))
        {
            count++;
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }

    void SetCountText() {
        countText.text = "Score: " + count.ToString();
        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
