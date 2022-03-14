using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpdateStats : MonoBehaviour
{
    public int _trust;
    public float _happieness;
    int _averageSalary;
    [SerializeField] Load _load;
  

    public void SetTrust()
    {
        int a = Int32.Parse(_load._cheapHouseCount.text);
        int b = Int32.Parse(_load._comfortHouseCount.text);
        int c = Int32.Parse(_load._businessHouseCount.text);
        int d = Int32.Parse(_load._premiumHouseCount.text);

        _trust = _trust - a * 2 + b + c * 2 + d * 3;
        _load._trustValue.text = _trust.ToString() + "%";
        _load._trustValueBar.fillAmount = _trust * 0.01f;
    }

    public void SetHappieness()
    {
        float a = _load._medicine._nonAcceptedValue;
        float b = _load._police._nonAcceptedValue;
        float c = _load._education._nonAcceptedValue;
        float d = _load._transport._nonAcceptedValue;
        float e = _load._electricity._nonAcceptedValue;
        float f = _load._garbage._nonAcceptedValue;
        float g = _load._living._nonAcceptedValue;
        float ch = a + b + c + d + e + f + g;
        _happieness = _happieness + 1 / ch;
        
        float _happPercent = _happieness * 100;
        _load._happienessValue.GetComponent<Text>().text = _happPercent.ToString() + "%";
        _load._happienessValueBar.fillAmount = _happieness;



        //_load._happienessValueBar.fillAmount = _happieness * 0.01;
    }
    public void SetAllStats(float happieness, int trust)
    {
        this._happieness = happieness;
        this._trust = trust;
    }
    public void SetAverageSalary()
    {
        int a = Int32.Parse(_load._medicineSalary.GetComponent<Text>().text);
        int b = Int32.Parse(_load._policeSalary.GetComponent<Text>().text);
        int c = Int32.Parse(_load._transportSalary.GetComponent<Text>().text);
        int d = Int32.Parse(_load._educationSalary.GetComponent<Text>().text);
       
        _averageSalary = (a + b + c + d) / 4;
        _load._financeValue.GetComponent<Text>().text = _averageSalary.ToString();


    }

}
