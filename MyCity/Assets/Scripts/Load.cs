using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    [SerializeField] private int _budgetCount = 50000;
    [SerializeField] private int _humans = 1000;
    [SerializeField] private Text _humansText;
    [SerializeField] CategoriesChanger _categoriesChanger;


    [SerializeField] private Text _budgetCountText;
    [SerializeField] private Text _budgetCountTextStats;
    [SerializeField] private Text _budgetCountTextMenu;
    [SerializeField] ModeSwap _modeSwap;
    [SerializeField] public Branch _police;
    [SerializeField] public Branch _education;
    [SerializeField] public Branch _transport;
    [SerializeField] public Branch _medicine;
    [SerializeField] public Branch1 _garbage;
    [SerializeField] public Branch2 _electricity;
    [SerializeField] public Branch2 _living;
    [SerializeField] GameObject _message;
    [SerializeField] public GameObject _medicineSalary;
    [SerializeField] public GameObject _educationSalary;
    [SerializeField] public GameObject _policeSalary;
    [SerializeField] public GameObject _transportSalary;
    [SerializeField] public GameObject _financeValue;
    [SerializeField] UpdateStats _updateStats;

    [SerializeField] public Text _cheapHouseCount;
    [SerializeField] public Text _comfortHouseCount;
    [SerializeField] public Text _businessHouseCount;
    [SerializeField] public Text _premiumHouseCount;
    [SerializeField] public Text _trustValue;
    [SerializeField] public Image _trustValueBar;

    [SerializeField] public Text _happienessValue;
    [SerializeField] public Image _happienessValueBar;




    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(0);
        _budgetCountText.text = _budgetCount.ToString();
        _humansText.text = _humans.ToString();
        _budgetCountTextStats.text = _budgetCount.ToString();
       


        _categoriesChanger.Init();
        _modeSwap.ShowIncomeMode();
        _medicine.Set(7, _humans);
        _police.Set(7, _humans);
        _education.Set(7, _humans);
        _transport.Set(7, _humans);

        _updateStats.SetAllStats(0.2f, 20);
        _updateStats.SetAverageSalary();
        _updateStats.SetTrust();
        _updateStats.SetHappieness();

       

        _garbage.Set(_humans);
        _electricity.Set(_humans);
        _living.Set(_humans);

        _message.SetActive(false);
            
    }

   
    public int GetBudget() {
        return _budgetCount;
    }

    public int GetHumans()
    {
        return _humans;
    }


   public GameObject GetMessage()
    {
        return _message;
    }
    public void SetBudget(int a, int b)
    {
        _budgetCount += a * b;
        _budgetCountText.text = _budgetCount.ToString();
        _budgetCountTextStats.text = _budgetCount.ToString();
    }

    public void IncreaseHuman()
    {
        
        System.Random rnd = new System.Random();
        _humans += rnd.Next(100, 1000);
        _humansText.text = _humans.ToString();
    }
    public void DecreaseBudget(int val)
    {
        _budgetCount -= val;
        _budgetCountText.text = _budgetCount.ToString();
        _budgetCountTextStats.text = _budgetCount.ToString();
    }
 
   
}
