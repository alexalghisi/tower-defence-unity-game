using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset;
	private GameObject turret;

	private Renderer nodeRenderer;
	private Color startColor;
	private BuildManager buildManager;

	void Start () 
	{
		nodeRenderer = GetComponent<Renderer> ();
		startColor = nodeRenderer.material.color;
		buildManager = BuildManager.instance;
	}

	void OnMouseDown()
	{
		if (buildManager.GetTurretToBuild () == null)
		{
			return;
		}
		if (turret != null)
		{
			Debug.Log ("Can't build here!");
		}

		GameObject turretToBuild = buildManager.GetTurretToBuild();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	void OnMouseEnter()
	{
		if (buildManager.GetTurretToBuild () == null)
		{
			return;
		}
		nodeRenderer.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		nodeRenderer.material.color = startColor;
	}
}
