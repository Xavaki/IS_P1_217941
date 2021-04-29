using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Config params
    public float speed = 0;
    private int count;
    private bool gameEnded;

    // UI
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject replayButtonObject;

    // SFX
    public AudioClip pickupSFX;
    public AudioClip winSFX;
    public AudioClip deathSFX;

    // Cached components
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; // ideally this should be dinamically assigned 
        gameEnded = false;
        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        replayButtonObject.SetActive(false);
    }

    // New input system didn't work so I had to use old one 
    //void onMove(InputValue movementValue)
    //{
    //    Vector2 movementVector = movementValue.Get<Vector2>();
        
    //    movementX = movementVector.x;
    //    movementY = movementVector.y;
    //}

    
    void Update()
    {
        // Define player movement based on user input
        var deltaX = Input.GetAxis("Horizontal");
        var deltaZ = Input.GetAxis("Vertical");
        Debug.Log(deltaX);
        Vector3 movement = new Vector3(deltaX, 0.0f, deltaZ);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Lava") && !gameEnded)
        {
            // Play death sound
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
            // "Stop" player input and slow player down
            speed = 0.0f;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);

            // Activate UI elements
            loseTextObject.SetActive(true);
            replayButtonObject.SetActive(true);

            // Inform that game has ended 
            gameEnded = true;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
        {
            winTextObject.SetActive(true);
            replayButtonObject.SetActive(true);
            AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);

            // Inform that game has ended 
            gameEnded = true;
        }
    }



}
