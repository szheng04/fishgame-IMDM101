using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{

    public GameObject hitBirdObject;
    public GameObject hitBirdBackground;
    private bool hitBird;
    //public Vector3 cameraTargetPosition = new Vector3(45, 0, -10);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitBird = false;
        hitBirdObject.SetActive(false);
        hitBirdBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitBird && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ReloadScene());
           //ReloadScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Airplane")) {
            Debug.Log("switch scene");
        }
        if (other.gameObject.CompareTag("Bird"))  
        {
            hitBird = true;
            hitBirdObject.SetActive(true);
            hitBirdBackground.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator ReloadScene () {
        GetComponent<PlayerControl1>().enabled = false;

        //rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        GetComponent<PlayerControl1>().enabled = true;
      //  Camera.main.transform.position = cameraTargetPosition;

   
   
    }
}
