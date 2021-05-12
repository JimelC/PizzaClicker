using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    #region public methods
    #endregion

    #region public vars
    public static CurrencyManager Instance;
    
    public double CurrentCoins
    {
        get
        {
            return _currentCoins;
        }
        set
        {
            _currentCoins = value;
        }
    }
    #endregion

    #region private methods
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region private vars
    private double _currentCoins = 0;
    #endregion
}
