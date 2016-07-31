using UnityEngine;
using System.Collections;

public class PowerUpFlower : Collectable {

	public int itemID = 1;
	public GameObject projectilePrefab;

	override protected void OnCollect(GameObject target){

		var equipBehavior = target.GetComponent<Equip> ();
		if (equipBehavior != null) {
			equipBehavior.currentItem = itemID;
		}

		var shootBehavior = target.GetComponent <FireProjectile> ();
		if (shootBehavior != null) {
			shootBehavior.projectilePrefab = projectilePrefab;

		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
