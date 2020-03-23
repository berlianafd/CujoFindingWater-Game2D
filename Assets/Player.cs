using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {
    public Text waterText;
    private int totalWaters = 5;
    private int totalFlags = 0;

    private Vector3 startPosition;
    public int respawn = 0;

    private PlayerInventoryDisplay playerInventoryDisplay;

    void Start() {
        UpdateWaterText();
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        // record position when scene starts
        startPosition = transform.position;
    }

    void Update()
    {
        if(totalWaters == 0 && totalFlags ==1)
        {
            SceneManager.LoadScene("Play2");
        }

        if (transform.position.y < -14) {
           Respawn();
        }
            
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.CompareTag("water")) {
            totalWaters--;
            UpdateWaterText();
            Destroy(hit.gameObject);
        }
        else if (hit.CompareTag("flag"))
        {
            if (totalWaters == 0)
            {
                Destroy(hit.gameObject);
                totalFlags++;
            }
        }
    }

    private void UpdateWaterText() {
        string waterMessage = "Water = " + totalWaters;
        waterText.text = waterMessage;
    }

    void Respawn()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        transform.position = startPosition;
        respawn++;
        if (respawn == 3)
        {
            SceneManager.LoadScene("Scene Retry");
        }
        playerInventoryDisplay.OnChangeHeartTotal(respawn);
    }

} 