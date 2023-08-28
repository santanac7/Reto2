using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class RedemZone : MonoBehaviour
{
    AnimationAndMovementController player;
    GameManager gameManager;
    public GameObject panelCanRedem;
    public GameObject panelCantRedem;
    public GameObject panelCanPlantInfo;

    bool hasSeed = false;

    private void Start()
    {
        player = GameObject.Find("Player T-Pose").GetComponent<AnimationAndMovementController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameManager.canRedem)
            {
                panelCanRedem.SetActive(true);                
            }
            else
            {
                panelCantRedem.SetActive(true);
                AudioManager.instance.PlaySfx(4);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameManager.canRedem) { 
            if (player.playerInput.PlayerControls.Action.triggered)
            {
                hasSeed = true;
                gameManager.canPlant = true;
                panelCanRedem.SetActive(false);
                panelCanPlantInfo.SetActive(true);
                AudioManager.instance.PlaySfx(3);
            }
        }
    }


private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameManager.canRedem)
            {
                panelCanRedem.SetActive(false);
                panelCanPlantInfo.SetActive(false);
            }
            else
            {
                panelCantRedem.SetActive(false);
            }
        }
        if (hasSeed)
        {
            Destroy(panelCanRedem);
            Destroy(panelCantRedem);
            Destroy(panelCanPlantInfo);
        }
    }
}
