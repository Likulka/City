using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Branch1 : MonoBehaviour
{
    [SerializeField] private Text _nonAccepted;
    public int _nonAcceptedValue = 1000;
   
    [SerializeField] Load load1;
    public int _abstractVal = 0;
    public void Set(int nav)
    {
        this._nonAcceptedValue = nav;
        _nonAccepted.GetComponent<Text>().text = _nonAcceptedValue.ToString();
       

    }

    public void GarbageUnavailable()
    {
        _nonAcceptedValue = load1.GetHumans() - _abstractVal;
        if (_nonAcceptedValue < 0)
        {
            _nonAcceptedValue = 0;
        }
        _nonAccepted.text = _nonAcceptedValue.ToString();

    }

   

}
