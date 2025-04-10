using UnityEngine;

public class ParallaxController : MonoBehaviour
{
 // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    private float offset;

    void Start()
    {
        // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position.x - player.transform.position.x; 
    }

    void LateUpdate()
    {
        // Maintain the same offset between the camera and player throughout the game.
        transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
        //player.transform.position.x + offset;  
    }



        
    // Transform cam;
    // Vector3 camStartPos;
    // float distance;

    // GameObject[] backgrounds;
    // float[] backSpeed;

    // float farthestBack;
    // [Range(0.0f, 10f)]
    // public float parallaxSpeed;

    
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     cam = Camera.main.transform;
    //     camStartPos = cam.position;

    //     int backCount = transform.childCount;
    //     backSpeed = new float[backCount];
    //     backgrounds = new GameObject[backCount];

    //     for (int i = 0; i < backCount; i++) {
    //         backgrounds[i] = transform.GetChild(i).gameObject;
    //     }

    //     BackSpeedCalculate(backCount);
    // }

    // void BackSpeedCalculate (int backCount) {
    //     for (int i = 0; i < backCount; i++) {
    //         if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack) {
    //             farthestBack = backgrounds[i].transform.position.z - cam.position.z;
    //         }
    //     }

    //     for (int i = 0; i < backCount; i++) {
    //         backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
    //     }
    // }

    // private void LateUpdate() {
    //     distance = cam.position.x - camStartPos.x;
    //    // transform.position = new Vector3(cam.position.x, transform.position.y, -10);

    //     for (int i = 0; i < backgrounds.Length; i++) {
    //         float speed = backSpeed[i] * parallaxSpeed;
    //         Vector3 backgroundTargetPos = new Vector3(camStartPos.x + distance * speed, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
    //         backgrounds[i].transform.position = backgroundTargetPos;
    //     }
    // }

}
