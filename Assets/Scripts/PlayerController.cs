using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private AudioSource gameAudio;
	public float Speed;
	public float Tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		gameAudio = GetComponent<AudioSource> ();
	}

	void Update() {

		if ( (Input.GetButton ("Fire1") || Input.GetButton ("Fire4") ) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			gameAudio.Play ();
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3(moveHorizontal * Speed, 0.0f, moveVertical * Speed);

		rb.velocity = movement;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -Tilt);

	}

}
