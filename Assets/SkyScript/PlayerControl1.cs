using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl1 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement; //stores x (horizontal) and y (vertical)
    public GameObject hitBirdObject;
    public GameObject hitBirdBackground;
    private bool hitBird;
    //public Vector3 cameraTargetPosition = new Vector3(-10, -10, -10);
    //public PlayerControl1 cameraFollowScript;

      void Start() 
    {
        hitBird = false;
        hitBirdObject.SetActive(false);
        hitBirdBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // if (hitBird && Input.GetKeyDown(KeyCode.Space))
        // {
        //     StartCoroutine(ReloadScene());
        //    //ReloadScene();
        // }
       
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Bird"))  
        {
            hitBird = true;
            hitBirdObject.SetActive(true);
            hitBirdBackground.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    // void ReloadScene () {
    //     rb.linearVelocity = Vector2.zero;
    //     Camera.main.transform.position = cameraTargetPosition;
        
    //     SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    // }

    // IEnumerator ReloadScene () {
    //    this.enabled = false;
    //     rb.linearVelocity = Vector2.zero;
    //     yield return new WaitForSeconds(.5f);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    //     this.enabled = true;
   
   
    // }

    // void OnEnable() {
    //     Camera.main.transform.position = cameraTargetPosition;

    // }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



    
}

