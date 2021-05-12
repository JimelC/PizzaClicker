using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyUI : MonoBehaviour
{
    #region public methods

    #endregion

    #region public variables

    #endregion

    #region private methods
    private void Update()
    {
        double myCoins = CurrencyManager.Instance.CurrentCoins;

        coinValueText.text = ""+myCoins;
    }
    #endregion

    #region private varibalbes
    [SerializeField]
    private Text coinValueText;
    #endregion
}
