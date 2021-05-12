using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinGenerator : MonoBehaviour
{
    #region public methods
    //Click para comprar
    public void OnClickBuy()
    {
        //Preguntar si tengo monedas suficientes, y restarlas antes de comprar
        if (CurrencyManager.Instance.CurrentCoins >= myGeneratorData.generatorPrice)
        {
            CurrencyManager.Instance.CurrentCoins = CurrencyManager.Instance.CurrentCoins - myGeneratorData.generatorPrice;
            BuyGenerator();
        }
    }

    //Click para generar
    public void OnClickGenerate()
    {
        if (IsGenerating)
        {
            return;
        }

        GenerateCoins();
    }

    //Click para upgradear
    public void OnClickUpgrade()
    {
        if (CurrencyManager.Instance.CurrentCoins >= GeneratorUpgradePrice)
        {
            //Restar monedas
            CurrencyManager.Instance.CurrentCoins = CurrencyManager.Instance.CurrentCoins - GeneratorUpgradePrice;
            //Sumarle uno al tier
            GeneratorTier++;
        }

    }

    public void OnClickAutomate()
    {
        //Preguntar si tengo monedas suficientes, y restarlas antes de automatizar
        if (CurrencyManager.Instance.CurrentCoins >= myGeneratorData.automatizationPrice)
        {
            CurrencyManager.Instance.CurrentCoins = CurrencyManager.Instance.CurrentCoins - myGeneratorData.automatizationPrice;
            //Automatizar este generador
            IsAutomated = true;
        }
    }
    #endregion

    #region public vars
    public float GenerationPercent
    {
        get
        {
            return _generationPercent;
        }
        set
        {
            _generationPercent = value;
            OnUpdateGenerationPercent?.Invoke();
        }
    }

    public float GeneratorUpgradePrice
    {
        get
        {
            //Price = PrecioBase * Multiplicador°tier
            return myGeneratorData.upgradePriceBase * Mathf.Pow(myGeneratorData.upgradeMultiplier, GeneratorTier);
        }
    }

    public float ProductionBySecond
    {
        get
        {
            //Produccion = ProduccionBase * Tier * Multiplicador
            return myGeneratorData.productionBase * GeneratorTier * myGeneratorData.productionMultiplier;
        }
    }

    public bool IsBought
    {
        get
        {
            return _isBought;
        }
        private set
        {
            _isBought = value;
        }
    }

    public bool IsAutomated
    {
        get
        {
            return _isAutomated;
        }
        private set
        {
            _isAutomated = value;
        }
    }

    public bool IsGenerating
    {
        get
        {
            return _isGenerating;
        }
        private set
        {
            _isGenerating = value;
        }
    }

    public int GeneratorTier
    {
        get
        {
            return _generatorTier;
        }
        private set
        {
            _generatorTier = value;
            OnUpgradeGenerationTier?.Invoke();
        }
    }

    public CoinGeneratorData myGeneratorData;

    public System.Action OnUpdateGenerationPercent;
    public System.Action OnUpgradeGenerationTier;
    public System.Action OnUpdatePurchaseStatus;
    #endregion

    #region private methods
    //Comprar el generador
    private void BuyGenerator()
    {
        IsBought = true;
        //Enviar evento de actualizacion de status
        OnUpdatePurchaseStatus?.Invoke();
    }

    private void GenerateCoins()
    {
        float finalValue = 1f;

        DOTween.To(() => GenerationPercent, x => GenerationPercent = x, finalValue, myGeneratorData.generationTimeBase).OnComplete(OnCompleteGeneration);
        IsGenerating = true;
    }

    private void OnCompleteGeneration()
    {
        double production =  ProductionBySecond * myGeneratorData.generationTimeBase;
        
        CurrencyManager.Instance.CurrentCoins += production;

        GenerationPercent = 0;
        IsGenerating = false;
    }

    private void Start()
    {
        if (myGeneratorData.boughtByDefault)
        {
            //Comprar generador sin cobrar el costo del generador
            BuyGenerator();
        }
    }

    private void Update()
    {
        if (IsAutomated)
        {
            //Si no esta generando dinero
            if (IsGenerating == false)
            {
                GenerateCoins();
            }
        }
    }
    
    #endregion

    #region private vars
    private float _generationPercent = 0f;

    [SerializeField]
    private bool _isBought = false;

    [SerializeField]
    private bool _isAutomated = false;

    [SerializeField]
    private bool _isGenerating = false;

    [SerializeField]
    private int _generatorTier = 1;
    #endregion
    
}
