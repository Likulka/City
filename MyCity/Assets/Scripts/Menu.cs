using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject menuPanel;

    public void SwitchMenu()
    {
       if (menuPanel.activeInHierarchy == true)
        {
            menuPanel.SetActive(false);
        }

       else { menuPanel.SetActive(true); }
    }


   
}
