using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoleccionItems : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Aprovechable"))
        {
            gameManager.ContadorApro++;
            Debug.Log("Aprovechable " + gameManager.ContadorApro);
        }

        if (other.gameObject.CompareTag("NoAprovechable"))
        {
            gameManager.ContadorNoApro++;
            Debug.Log("No Aprovechable " + gameManager.ContadorNoApro);
        }
    }
}