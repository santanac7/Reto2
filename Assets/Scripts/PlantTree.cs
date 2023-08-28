using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTree : MonoBehaviour
{
    [SerializeField] GameObject tree;
    [SerializeField] GameObject panelPlantTree;
    [SerializeField] GameObject panelNeedSeed;

    AnimationAndMovementController player;
    GameManager gameManager;

    private void Awake()
    {
        player = GameObject.Find("Player T-Pose").GetComponent<AnimationAndMovementController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Start()
    {
        tree.SetActive(false);
        panelPlantTree.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!gameManager.canPlant)
            {
                panelNeedSeed.SetActive(true);
                AudioManager.instance.PlaySfx(4);
            }
            else
            {
                panelPlantTree.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameManager.canPlant)
        {
            if (player.playerInput.PlayerControls.Action.triggered)
            {
                tree.SetActive(true);
                panelPlantTree.SetActive(false);
                this.gameObject.SetActive(false);
                AudioManager.instance.PlaySfx(6);
            }
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!gameManager.canPlant)
            {
                panelNeedSeed.SetActive(false);
            }
            else
            {
                panelPlantTree.SetActive(false);
            }
        }
        
    }
}