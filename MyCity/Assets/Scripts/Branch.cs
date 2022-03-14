using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Branch : MonoBehaviour
{
   
    [SerializeField] private Text _salary;
    private int _salaryValue;
    [SerializeField] private Text _nonAccepted;
    public int _nonAcceptedValue = 1000;
    [SerializeField] public UpdateStats _updateStats;

    [SerializeField] Load load1;
    public int _abstractVal = 0;
    public void Set(int sv, int nav)
    {
       
        this._salaryValue = sv;
        _salary.GetComponent<Text>().text = _salaryValue.ToString();
        this._nonAcceptedValue = nav;
        _nonAccepted.GetComponent<Text>().text = _nonAcceptedValue.ToString();
        

    }
    public void Message(GameObject msg)
    {
        Instantiate(msg);
    }
    public void PeopleUnavailable()
    {
        _nonAcceptedValue = load1.GetHumans() - _abstractVal;
        if (_nonAcceptedValue < 0)
        {
            _nonAcceptedValue = 0;
        }
        _nonAccepted.text = _nonAcceptedValue.ToString();
        _updateStats.SetHappieness();

    }

    public void IncreaseSalary()
    {
        _salaryValue += 1;
        _salary.GetComponent<Text>().text = _salaryValue.ToString();
       _updateStats.SetAverageSalary();
    }
    public void DecreaseSalary()
    {
        _salaryValue -= 1;
        _salary.GetComponent<Text>().text = _salaryValue.ToString();
        _updateStats.SetAverageSalary();
    }

   
}
