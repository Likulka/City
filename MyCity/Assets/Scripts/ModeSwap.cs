using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModeSwap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject incomeMode;
    [SerializeField] private GameObject outcomeMode;
    [SerializeField] private Button outcomeButton;
    [SerializeField] private Button incomeButton;


  

    public void ShowIncomeMode()
    {
       
        outcomeMode.SetActive(false);
        incomeMode.SetActive(true);
        ColorBlock colorBlock = outcomeButton.GetComponent<Button>().colors;
        colorBlock.normalColor = new Color(255, 255, 255, 0.78431372549f);
        ColorBlock colorBlock2 = outcomeButton.GetComponent<Button>().colors;
        colorBlock2.normalColor = new Color(255, 255, 255, 0f);
        incomeButton.GetComponent<Button>().colors = colorBlock;
        outcomeButton.GetComponent<Button>().colors = colorBlock2;
        //outcomeButton.GetComponent<Button>();
    }


    public void ShowOutcomeMode()
    {
        incomeMode.SetActive(false);
        outcomeMode.SetActive(true);
        ColorBlock colorBlock = outcomeButton.GetComponent<Button>().colors;
        colorBlock.normalColor = new Color(255, 255, 255, 0.78431372549f);
        ColorBlock colorBlock2 = outcomeButton.GetComponent<Button>().colors;
        colorBlock2.normalColor = new Color(255, 255, 255, 0f);
        outcomeButton.GetComponent<Button>().colors = colorBlock;
        incomeButton.GetComponent<Button>().colors = colorBlock2;

    }
}
    // Update is called once per frame


