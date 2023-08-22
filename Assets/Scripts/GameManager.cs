using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelAprovechable;
    public GameObject panelNoAprovechable;

    public TMP_Text txtApro;
    public TMP_Text txtNoApro;

    int contadorApro;
    int contadorNoApro;

    public int ContadorApro
    {
        get { return contadorApro; }
        set { 
            contadorApro = value;
            txtApro.text = $"Llevas {contadorApro} elementos aprovechables.";
            panelAprovechable.SetActive(true);
            Invoke("DesactivarPanel1", 1f);
        }
    }
    public int ContadorNoApro
    {
        get { return contadorNoApro; }
        set { contadorNoApro = value;
              txtNoApro.text = $"Llevas {contadorNoApro} elementos no aprovechables.";
              panelNoAprovechable.SetActive(true);
              Invoke("DesactivarPanel2", 1f);
        }
    }

    void Start()
    {
        
    }

    private void DesactivarPanel1()
    {
        panelAprovechable.SetActive(false);
    }

    private void DesactivarPanel2()
    {
        panelNoAprovechable.SetActive(false);
    }


}
 