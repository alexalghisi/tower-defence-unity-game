using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	BuildManager buildManager;
	public GameObject firstTurretType;
	public GameObject secondTurretType;
	public int avaliableAmount = 1500;
	public int type1TurretPrice = 250;
	public Text availableAmountText;

	public void PurchaseType1Turret()
	{
		if (avaliableAmount < type1TurretPrice) 
		{
			buildManager.SetTurretToBuild (null);
			return;
		}
		avaliableAmount -= type1TurretPrice;
		buildManager.SetTurretToBuild (firstTurretType);
		availableAmountText.text = avaliableAmount + "$";
	}

	void Start()
	{
		buildManager = BuildManager.instance;
	}
}
