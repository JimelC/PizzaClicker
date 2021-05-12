using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGeneratorUI : MonoBehaviour
{
    #region public methods
    //Metodo cuando se quiera comprar el generador
    public void OnClickBuy()
    {
        myCoinGenerator.OnClickBuy();
    }

    //Metodo cuando se quiera empezar a generar dinero
    public void OnClickGenerate()
    {
        myCoinGenerator.OnClickGenerate();
    }

    //Metodo cuando se quiera upgradear el generador
    public void OnClickUpgrade()
    {
        myCoinGenerator.OnClickUpgrade();
    }
    #endregion

    #region public vars
    public CoinGenerator myCoinGenerator;
    #endregion

    #region private methods
    private void Start()
    {
        myCoinGenerator.OnUpdateGenerationPercent += OnUpdateGeneratorValue;
        myCoinGenerator.OnUpgradeGenerationTier += OnUpgradeGenerationTier;
        myCoinGenerator.OnUpdatePurchaseStatus += OnUpdatePurchaseStatus;

        UpdateUI();
    }

    private void OnUpdateGeneratorValue()
    {
        UpdateUI();
    }

    private void OnUpgradeGenerationTier()
    {
        UpdateUI();
    }

    private void OnUpdatePurchaseStatus()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        sliderImage.fillAmount = myCoinGenerator.GenerationPercent;

        tierText.text = "" + myCoinGenerator.GeneratorTier;
        upgradePriceText.text = "" + myCoinGenerator.GeneratorUpgradePrice.ToString("F2");
        productionByClickText.text = "" + (myCoinGenerator.ProductionBySecond * myCoinGenerator.myGeneratorData.generationTimeBase).ToString("F1");

        if (myCoinGenerator.IsBought)
        {
            OnSaleGo.SetActive(false);
            NormalGo.SetActive(true);
        }
        else
        {
            generatorNameText.text = myCoinGenerator.myGeneratorData.generatorName;
            generatorPriceBaseText.text = "$"+myCoinGenerator.myGeneratorData.generatorPrice;

            OnSaleGo.SetActive(true);
            NormalGo.SetActive(false);
        }
    }
    #endregion

    #region private vars

    //Generador de dinero, en venta
    [SerializeField]
    private Text generatorNameText;
    [SerializeField]
    private Text generatorPriceBaseText;

    //Generador de dinero normal
    [SerializeField]
    private Image sliderImage;
    [SerializeField]
    private Text tierText;
    [SerializeField]
    private Text upgradePriceText;
    [SerializeField]
    private Text productionByClickText;

    //Variables de referencia a los objetos del prefab, activar/desactivar dependiendo si el generado ha sido comprado
    [SerializeField]
    private GameObject OnSaleGo;
    [SerializeField]
    private GameObject NormalGo;
    #endregion
}
