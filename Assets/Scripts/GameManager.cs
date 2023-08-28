using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelAprovechable;

    public TMP_Text txtApro;

    int counterItems = 0;
    public bool canRedem = false;
    public bool canPlant = false;
    public int CounterItems
    {
        get { return counterItems; }
        set {
            counterItems++;
            txtApro.text = $"Llevas {counterItems} residuos recogidos.";
            panelAprovechable.SetActive(true);
            Invoke("DesactivarPanel1", 1f);
        }
    }    
    private void DesactivarPanel1()
    {
        panelAprovechable.SetActive(false);
    }

    private void Update()
    {
        if (counterItems >= 8)
        {
            canRedem = true;
        }
    }
}
 