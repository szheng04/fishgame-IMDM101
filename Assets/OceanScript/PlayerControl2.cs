using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl2 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement; //stores x (horizontal) and y (vertical)
    public GameObject collectPearl, finishText;
    private GameObject[] pearls, goldenPearls;
    private int pearlCount, goldenPearlCount; 

void Start() 
{
    pearls = GameObject.FindGameObjectsWithTag("Pearl");
    goldenPearls = GameObject.FindGameObjectsWithTag("Golden Pearl");

    pearlCount = 0;
    goldenPearlCount = 0;

    for (int i = 0; i < goldenPearls.Length; i++) {
        goldenPearls[i].SetActive(false);
    }
    collectPearl.SetActive(false);
    finishText.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Pearl"))  
        {
            other.gameObject.SetActive(false);
            pearlCount = pearlCount + 1;
            Debug.Log(pearlCount);
            AllPearlsCollected();
            
        }

        if (other.gameObject.CompareTag("Golden Pearl")) {
            other.gameObject.SetActive(false);
            goldenPearlCount = goldenPearlCount + 1;
            AllGoldenPearlsCollected();
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void AllPearlsCollected() {
        if (pearlCount >= pearls.Length) {
            StartCoroutine(ShowForSeconds(collectPearl, 1f));
            
            for (int i = 0; i < goldenPearls.Length; i++) {
                goldenPearls[i].SetActive(true);
            }  

        }
    }

    void AllGoldenPearlsCollected() {
        if (goldenPearlCount >= goldenPearls.Length) {
            finishText.SetActive(true);
        }
        
    }

    IEnumerator ShowForSeconds(GameObject obj, float duration)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(duration);
        obj.SetActive(false);
    }

    
}


