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
        if (other.gameObject.CompareTag("Item"))
        {
            AudioManager.instance.PlaySfx(2);
            Destroy(other.gameObject);
            gameManager.CounterItems++;
        }
    }
}