using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject statsPanel;

    public void SwitchStats()
    {
        if (statsPanel.activeInHierarchy == true)
        {
            statsPanel.SetActive(false);
        }

        else { statsPanel.SetActive(true); }
    }

 
}
