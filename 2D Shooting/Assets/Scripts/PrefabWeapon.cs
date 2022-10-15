using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") || Input.touches.Any(t => t.position.x > Screen.width/2))
		{
			Shoot();
		}
	}

	void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
