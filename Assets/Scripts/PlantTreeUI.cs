using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlantTreeUI : MonoBehaviour
{
    public static PlantTreeUI Instace { get; private set;}
    private TextMeshProUGUI textMeshPro;
    private Button yesBtn;
    private Button noBtn;

    PlayerInput playerInput;
    bool action;


    private void Awake()
    {
        Instace = this;
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();   
        yesBtn = transform.Find("YesBtn").GetComponent<Button>();
        noBtn = transform.Find("NoBtn").GetComponent<Button>();
        Hide();
    }

    public void ShowQuestion(string questionText, Action yesAction, Action noAction)
    {
        gameObject.SetActive(true);    
        textMeshPro.text = questionText;
        yesBtn.onClick.AddListener(() =>
        {
            Hide();
            yesAction();
        });
        noBtn.onClick.AddListener(() =>
        {
            Hide();
            noAction();
        }) ;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
