using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Threading;

public class Budjet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject _child;

    int[] _livingPrice = { 1000, 2000, 5000, 10000 };
    int[] _livingCount = { 0, 0, 0, 0 };
    int[] _livingProfit = { 300, 350, 500, 900 };
    int[] _livingProfitMoney = { 100, 200, 400, 800 };

    int[] _extractionPrice = { 20000, 30000, 35000, 50000, 70000, 60000 };
    int[] _extractionCount = { 0, 0, 0, 0, 0, 0 };
    int[] _extractionProfit = { 5000, 7000, 10000, 14000, 24000, 19000 };

    int[] _mealPrice = { 80000, 150000, 220000, 280000, 300000 };
    int[] _mealCount = { 0, 0, 0, 0, 0 };
    int[] _mealProfit = { 40000, 70000, 100000, 180000, 200000 };

    int[] _electronicPrice = { 380000, 600000, 800000, 1000000, 300000 };
    int[] _electronicCount = { 0, 0, 0, 0, 0 };
    int[] _electronicProfit = { 250000, 300000, 400000, 250000, 50000 };

    int[] _electricityPrice = { 5000, 15000, 20000, 40000, 100000 };
    int[] _electricityCount = { 0, 0, 0, 0, 0 };
    int[] _electricityProfit = { 500, 2000, 3000, 5000, 15000 };

    int[] _garbagePrice = { 5000, 20000, 8000, 40000 };
    int[] _garbageCount = { 0, 0, 0, 0 };
    int[] _garbageProfit = { 1000, 15000, 2000, 15000 };

    int[] _medicinePrice = { 100000, 350000 };
    int[] _medicineCount = { 0, 0 };
    int[] _medicineProfit = { 1000, 4000 };

    int[] _policePrice = { 100000, 300000, 500000 };
    int[] _policeCount = { 0, 0, 0 };
    int[] _policeProfit = { 1000, 4000, 10000 };

    int[] _transportPrice = { 50000, 80000, 180000 };
    int[] _transportCount = { 0, 0, 0 };
    int[] _transportProfit = { 500, 1000, 3000 };

    int[] _educationPrice = { 100000, 300000, 500000 };
    int[] _educationCount = { 0, 0, 0 };
    int[] _educationProfit = { 1000, 4000, 10000 };

    int[] _sciencePrice = { 100000, 100000, 100000, 100000, 100000, 100000 };
    int[] _scienceCount = { 0, 0, 0, 0, 0, 0, 0 };
 


    [SerializeField] public Load _budjet;
    [SerializeField] public Branch _medicine;
    [SerializeField] public Branch _police;
    [SerializeField] public Branch _transport;
    [SerializeField] public Branch _education;
    [SerializeField] public Branch1 _garbage;
    [SerializeField] public Branch2 _living;
    [SerializeField] public Branch2 _electricity;
    [SerializeField] public UpdateStats _updateStats;


    public void GetButton()
    {
        BudjetDecrease(EventSystem.current.currentSelectedGameObject);
    }

    public void IncreaseNumber(GameObject _act, int[] arr, int _tag)
    {
        _child = _act.transform.GetChild(1).gameObject;

        arr[_tag] += 1;
        _child.GetComponent<Text>().text = arr[_tag].ToString();

    }

    public bool BudgetSuffciencyCheck(int price, int[] arr)
    {
        if (_budjet.GetBudget() >= arr[price])
        {
            return true;
        }
        else {
            Message(_budjet.GetMessage(), "Не хватает денег");
            return false; }
    }

    public bool ResearchSufficiencyCheck(int tag, int i)
    {
        if(_scienceCount[i] >= tag) {
            return true;
        }
        else
        {
            Message(_budjet.GetMessage(), "Нужно провести научные исследования");
            return false;
        }
    }
    

    public void BudjetIncrease(int[] arr1, int[] arr2)
    {
        for (int i = 0; i < arr1.Length; i++)
        {
            _budjet.SetBudget(arr1[i], arr2[i]);
        }
    }

    public void NextMounth() {
        BudjetIncrease(_extractionCount, _extractionProfit);
        BudjetIncrease(_mealCount, _mealProfit);
        BudjetIncrease(_electronicCount, _electronicProfit);
        BudjetIncrease(_livingCount, _livingProfitMoney);

        _budjet.IncreaseHuman();
        _medicine.PeopleUnavailable();
        _education.PeopleUnavailable();
        _transport.PeopleUnavailable();
        _police.PeopleUnavailable();
        _garbage.GarbageUnavailable();
        _living.SourceUnavailable();
        _electricity.SourceUnavailable();

        _updateStats._happieness -= 0.01f;
        _updateStats.SetHappieness();
        _updateStats._trust -= 1;
        _updateStats.SetTrust();
    }
    //уменьшаем количество людей в ожидании,например  для медицины, увеличение количества коек
    public void PeoplePendingDecrease(int[] arr1, int[] arr2, Branch _branch)
    {
        _branch._abstractVal = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            _branch._abstractVal += arr1[i] * arr2[i];
        }
        _branch.PeopleUnavailable();
    }

    public void PeoplePendingDecrease(int[] arr1, int[] arr2, Branch1 _branch)
    {
        _branch._abstractVal = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            _branch._abstractVal += arr1[i] * arr2[i];
        }
        _branch.GarbageUnavailable();
    }

    public void PeoplePendingDecrease(int[] arr1, int[] arr2, Branch2 _branch)
    {
        _branch._abstractVal = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            _branch._abstractVal += arr1[i] * arr2[i];
        }
        _branch.SourceUnavailable();
    }

   public void Message(GameObject msg, string info){
        msg.GetComponent<Text>().text = info;
        msg.SetActive(true);
        StartCoroutine(DisactivateMessage(msg));
   }

    IEnumerator DisactivateMessage(GameObject msg)
    {
        yield return new WaitForSeconds(2.0f);
       msg.SetActive(false);
        
    }

    public void AfterAction(GameObject act, int tag, int[] arrCount, int[] arrPrice)
    {
        IncreaseNumber(act, arrCount, tag);
        _budjet.DecreaseBudget(arrPrice[tag]);
    }

  

    public void BudjetDecrease(GameObject _act) {
       int _tag = Int32.Parse(_act.tag);
        switch (_act.transform.parent.parent.name)
        {
            case "ExtractionCanvas":
                if (BudgetSuffciencyCheck(_tag, _extractionPrice))
                {
                    
                    IncreaseNumber(_act, _extractionCount, _tag);
                    _budjet.DecreaseBudget(_extractionPrice[_tag]);
                }

                break;
            case "MealCanvas":
                if (BudgetSuffciencyCheck(_tag, _mealPrice))
                {
                    if (_electronicCount[4] != 0) {
                        
                        IncreaseNumber(_act, _mealCount, _tag);
                        _budjet.DecreaseBudget(_mealPrice[_tag]);
                    }
                    else
                    {
                        Message(_budjet.GetMessage(), "Нужен завод промышленного оборудования");
                    }

                }
                break;
            case "ElectronicCanvas":
                if (BudgetSuffciencyCheck(_tag, _electronicPrice))
                {
                    switch (_tag)
                    {
                        case 0:
                            if (_extractionCount[3] == 0)
                            {
                                Message(_budjet.GetMessage(), "Нужен стекольный завод");
                            }

                            else
                            {
                                AfterAction(_act, _tag, _electronicCount, _electronicPrice);
                            }
                            break;
                         
                        case 1: 
                            if(_extractionCount[5] == 0)
                            {
                                Message(_budjet.GetMessage(), "Нужен завод производства пластика");

                            }
                            else if (_extractionCount[3] == 0)
                            {
                                Message(_budjet.GetMessage(), "Нужен стекольный завод");
                            }
                            else
                            {
                                AfterAction(_act, _tag, _electronicCount, _electronicPrice);
                            }
                            break;
                        case 2:
                            if (_electronicCount[1] == 0)
                            {
                                Message(_budjet.GetMessage(), "Нужен завод процессоров");

                            }
                            else
                            {
                                AfterAction(_act, _tag, _electronicCount, _electronicPrice);

                            }
                            break;
                        case 3:
                            if (_extractionCount[5] == 0)
                            {
                                Message(_budjet.GetMessage(), "Нужен завод производства пластика");

                            }
                            else if (_extractionCount[3] == 0)
                            {
                                Message(_budjet.GetMessage(), "Нужен стекольный завод");
                            }
                            else if (_extractionCount[4] == 0)
                            {
                                Message(_budjet.GetMessage(), "Нужен завод металлов");
                            }
                            else
                            {
                                AfterAction(_act, _tag, _electronicCount, _electronicPrice);
                            }
                            

                            break;
                        default:
                            _act.GetComponent<Button>().interactable = true;
                            IncreaseNumber(_act, _electronicCount, _tag);
                            _budjet.DecreaseBudget(_electronicPrice[_tag]);
                            break;
                    };
                    
                  
                    
                    
                }
                break;
            case "MedicineCanvas":
                
                if (BudgetSuffciencyCheck(_tag, _medicinePrice) && ResearchSufficiencyCheck(_tag, 2) )
                {
                    _act.GetComponent<Button>().interactable = true;
                    IncreaseNumber(_act, _medicineCount, _tag);
                    _budjet.DecreaseBudget(_medicinePrice[_tag]);
                    PeoplePendingDecrease(_medicineCount, _medicineProfit, _medicine);
                    _updateStats.SetHappieness();
                }
                break;
            case "PoliceCanvas":

                if (BudgetSuffciencyCheck(_tag, _policePrice) && ResearchSufficiencyCheck(_tag, 3))
                {
                    _act.GetComponent<Button>().interactable = true;
                    IncreaseNumber(_act, _policeCount, _tag);
                    _budjet.DecreaseBudget(_policePrice[_tag]);
                    PeoplePendingDecrease(_policeCount, _policeProfit, _police);
                    _updateStats.SetHappieness();
                }
                break;
            case "EducationCanvas":

                if (BudgetSuffciencyCheck(_tag, _educationPrice) && ResearchSufficiencyCheck(_tag, 4))
                {
                    _act.GetComponent<Button>().interactable = true;
                    IncreaseNumber(_act, _educationCount, _tag);
                    _budjet.DecreaseBudget(_educationPrice[_tag]);
                    PeoplePendingDecrease(_educationCount, _educationProfit, _education);
                    _updateStats.SetHappieness();
                }
                break;
            case "TransportCanvas":

                if (BudgetSuffciencyCheck(_tag, _transportPrice) && ResearchSufficiencyCheck(_tag, 5))
                {
                    _act.GetComponent<Button>().interactable = true;
                    IncreaseNumber(_act, _transportCount, _tag);
                    _budjet.DecreaseBudget(_transportPrice[_tag]);
                    PeoplePendingDecrease(_transportCount, _transportProfit, _transport);
                    _updateStats.SetHappieness();
                }
                break;
            case "GarbageCanvas":

                if (BudgetSuffciencyCheck(_tag, _garbagePrice) && ResearchSufficiencyCheck(_tag, 1))
                {
                    _act.GetComponent<Button>().interactable = true;
                    IncreaseNumber(_act, _garbageCount, _tag);
                    _budjet.DecreaseBudget(_garbagePrice[_tag]);
                    PeoplePendingDecrease(_garbageCount, _garbageProfit, _garbage);
                    _updateStats.SetHappieness();
                }
                break;
            case "LivingCanvas":

                if (BudgetSuffciencyCheck(_tag, _livingPrice))
                {
                    _act.GetComponent<Button>().interactable = true;
                    IncreaseNumber(_act, _livingCount, _tag);
                    _budjet.DecreaseBudget(_livingPrice[_tag]);
                    PeoplePendingDecrease(_livingCount, _livingProfit, _living);
                    _updateStats.SetTrust();
                    _updateStats.SetHappieness();
                }
                break;
            case "ElectricityCanvas":

                if (BudgetSuffciencyCheck(_tag, _electricityPrice) && ResearchSufficiencyCheck(_tag, 0))
                {
                    _act.GetComponent<Button>().interactable = true;
                    IncreaseNumber(_act, _electricityCount, _tag);
                    _budjet.DecreaseBudget(_electricityPrice[_tag]);
                    PeoplePendingDecrease(_electricityCount, _electricityProfit, _electricity);
                    _updateStats.SetHappieness();
                }
                break;
            case "ScienceCanvas":

                if (BudgetSuffciencyCheck(_tag, _sciencePrice))
                {
                    IncreaseNumber(_act, _scienceCount, _tag);
                    _budjet.DecreaseBudget(_sciencePrice[_tag]);
                  
                }
                break;
        }
        }

    }
