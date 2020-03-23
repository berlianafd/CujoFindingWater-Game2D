using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class PlayerLv2 : MonoBehaviour
{
    public Text waterText;
    private int totalWaters = 8;
    private int totalFlags = 0;

    private Vector3 startPosition;
    public int respawn = 0;

    private Lv2PlayerInventoryDisplay playerInventoryDisplay;

    void Start()
    {
        UpdateWaterText();
        playerInventoryDisplay = GetComponent<Lv2PlayerInventoryDisplay>();
        // record position when scene starts
        startPosition = transform.position;
    }

    void Update()
    {
        if (totalWaters == 0 && totalFlags == 1)
        {
            SceneManager.LoadScene("Scene Win");
        }

        if (transform.position.y < -14)
        {
            Respawn();
        }

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("water"))
        {
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
        } else if (hit.CompareTag("ulat"))
        {
            Respawn();
        }
    }

    private void UpdateWaterText()
    {
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