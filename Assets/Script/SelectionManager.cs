using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance {  get; set; }
    public bool onTarget;
    public bool rayhit;
    public GameObject interaction_info_UI;
    Text interaction_text;
    // Start is called before the first frame update
    void Start()
    {
        rayhit = false;
        onTarget = false;
        interaction_text = interaction_info_UI.GetComponent<Text>();
        //把interaction text定義爲GameObject interaction_info_UI裏面的text
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
        //從中間蛇一個綫
        RaycastHit hit;  //射綫hit到東西的狀態
        if (Physics.Raycast(ray, out hit)) 
            //這是一個bool,檢測射綫有沒有射到東西,這裏是IF有hit到東西
        {
            rayhit=true;
            var selectionTransform = hit.transform;  
            //把hit的transform(位置)名爲selectiontransform,就是我們選擇的物件位置

            if (selectionTransform.GetComponent<InteractableObject>()&&selectionTransform.GetComponent<InteractableObject>().playerinRange)
            {
                onTarget= true;
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_info_UI.SetActive(true);
            }
            else
            {
                onTarget= false;
                interaction_info_UI.SetActive(false);
            }

        }
        else
        {
            rayhit = false;
            onTarget = false;
            interaction_info_UI.SetActive(false);
        }

    }
}
