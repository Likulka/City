using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CategoriesChanger : MonoBehaviour
{
    [Header("Income")]
    [SerializeField] private GameObject livingCanvas;
   
    [SerializeField] private GameObject extractionCanvas;
   
    [SerializeField] private GameObject mealCanvas;

    [SerializeField] private GameObject electronicCanvas;
    [Header("Outcome")]
    [SerializeField] private GameObject electricityCanvas;
    [SerializeField] private GameObject garbageCanvas;
    [SerializeField] private GameObject medicineCanvas;
    [SerializeField] private GameObject policeCanvas;
    [SerializeField] private GameObject educationCanvas;
    [SerializeField] private GameObject transportCanvas;
 
    [SerializeField] private GameObject scienceCanvas;

    private List<GameObject> _canvasList;
  
    public void Init()
    {
        
        _canvasList = new List<GameObject>();
        
        _canvasList.Add(extractionCanvas);
        _canvasList.Add(mealCanvas);
        _canvasList.Add(electronicCanvas);

        _canvasList.Add(livingCanvas);
        _canvasList.Add(medicineCanvas);
        _canvasList.Add(policeCanvas);
        _canvasList.Add(educationCanvas);
        _canvasList.Add(transportCanvas);

        _canvasList.Add(scienceCanvas);
        _canvasList.Add(electricityCanvas);
        _canvasList.Add(garbageCanvas);
     


       // ShowExtractionCanvas();
    }



    public void ShowExtractionCanvas()
    {
        DisableAllCanvases();
        extractionCanvas.SetActive(true);
    }



    public void ShowMealCanvas()
    {
     
        DisableAllCanvases();
        mealCanvas.SetActive(true);
    }

    public void ShowElectronicCanvas()
    {
         DisableAllCanvases();
        electronicCanvas.SetActive(true);
    }



    public void ShowLivingCanvas()
    {
        DisableAllCanvases();
        livingCanvas.SetActive(true);
    }

    public void ShowElectricityCanvas()
    {
        DisableAllCanvases();
        electricityCanvas.SetActive(true);
    }

    public void ShowGarbageCanvas()
    {
        DisableAllCanvases();
        garbageCanvas.SetActive(true);
    }


    public void ShowMedicineCanvas()
    {
        DisableAllCanvases();
        medicineCanvas.SetActive(true);
    }

    public void ShowPoliceCanvas()
    {
        DisableAllCanvases();
        policeCanvas.SetActive(true);
    }



    public void ShowEducationCanvas()
    {
        DisableAllCanvases();
        educationCanvas.SetActive(true);
    }

    public void ShowTransportCanvas()
    {
        DisableAllCanvases();
        transportCanvas.SetActive(true);
    }

   

    public void ShowScienceCanvas()
    {
        DisableAllCanvases();
        scienceCanvas.SetActive(true);
    }

    public void DisableAllCanvases()
    {
        foreach (var list in _canvasList)
        {
            list.SetActive(false);
        }
    }

    // Update is called once per frame

}
