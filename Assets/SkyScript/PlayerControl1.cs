using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl1 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement; //stores x (horizontal) and y (vertical)
    public TextMeshProUGUI textInput;
    public GameObject hitBirdObject;
    private bool hitBird = false;

    void Start() {
        hitBirdObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("HIT");
        if (other.gameObject.CompareTag("Bird"))  {
            Debug.Log("BIRD HIT");
            hitBird = true;
            hitBirdObject.SetActive(true);
        }
        hitBird = false;

    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    
}

