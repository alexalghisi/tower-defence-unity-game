using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
	public static BuildManager instance;

	public GameObject firstTurretPrefab;
	private GameObject turretToBuild;

	void Awake()
	{
		if (instance != null) 
		{
			return;
		}
		instance = this;
	}

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

	public void SetTurretToBuild(GameObject turret)
	{
		GameObject go = Instantiate (turret, transform.position, transform.rotation, turret.transform.parent);
		go.transform.localScale -= new Vector3(0.5f,0.5f,0.5f);
		turretToBuild = go;
	}
}
