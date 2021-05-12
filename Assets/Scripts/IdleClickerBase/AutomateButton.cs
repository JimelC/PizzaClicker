using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomateButton : MonoBehaviour
{
    #region public methods
    public void OnClickBuy()
    {
        myCoinGenerator.OnClickAutomate();
    }
    #endregion

    #region public variables
    public CoinGenerator myCoinGenerator;
    #endregion

    #region private methods
    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        double automationPrize = myCoinGenerator.myGeneratorData.automatizationPrice;

        priceText.text = "" + automationPrize;

        if (CurrencyManager.Instance.CurrentCoins >= automationPrize &&
            myCoinGenerator.IsAutomated == false)
        {
            buyButton.interactable = true;
        } else
        {
            buyButton.interactable = false;
        }
    }
    #endregion

    #region private variables
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Button buyButton;
    #endregion
}
