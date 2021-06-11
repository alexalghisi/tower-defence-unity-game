using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	public int life = 5;

	private Transform target;
	private Transform gameMaster;
	private int waveportIndex = 0;

	public void UpdateGameMaster(Transform _gameMaster)
	{
		gameMaster = _gameMaster;	
	}

	void Start () 
	{
		target = Wavepoints.points[0];
	}

	void Update ()
	{
		if (gameMaster.gameObject.GetComponent<TurretSpawner> ().IsGameEnded () ||
			gameMaster.gameObject.GetComponent<TurretSpawner> ().IsGamePaused ())
		{
			return;
		}
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
	
		if (Vector3.Distance (transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint ();
		}
			
		if (life <= 0) {
			gameMaster.gameObject.GetComponent<TurretSpawner> ().DecrementNumberOfEnemies ();
			Destroy (gameObject);
		}
	}

	void GetNextWaypoint()
	{
		if (waveportIndex >= Wavepoints.points.Length - 1)
		{
			gameMaster.gameObject.GetComponent<TurretSpawner> ().DecrementNumberOfEnemies ();
			gameMaster.gameObject.GetComponent<TurretSpawner> ().DecrementNumberOfLifes ();
			Destroy (gameObject);
			return;
		}
		waveportIndex++;
		target = Wavepoints.points [waveportIndex];
	}
}