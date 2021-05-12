using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IdleClicker/CoinGeneratorData")]
public class CoinGeneratorData : ScriptableObject
{
    //Nombre del generador
    public string generatorName;
    //Si ya se compro o no desde el principio
    public bool boughtByDefault;
    //Precio para comprar el generador
    public long generatorPrice;
    //Precio para comprar el automatizador del generador
    public long automatizationPrice;

    //tiempo que se tarda el generador en dar dinero
    public float generationTimeBase;

    //precio base de los upgrades
    public float upgradePriceBase;
    //multiplicador de los upgrades
    public float upgradeMultiplier;

    //produccion base del generador
    public float productionBase;
    //multiplicador de produccion del generador
    public float productionMultiplier;
}
