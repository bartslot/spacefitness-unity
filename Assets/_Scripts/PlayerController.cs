using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	private AudioSource audioSource ;
	public float speed;
	public float tilt;
	public Boundary boundary;
	private Rigidbody rb;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public float loopingTime;
	private float nextFire;

	public bool animationDone = false;
	void Start()
	{
		audioSource = GetComponent<AudioSource >();
		rb = GetComponent<Rigidbody>();
		Invoke("SetAnimationDone", loopingTime);
	}
	void Update()
	{
		if(!animationDone) return;
		bool fire = Input.GetKeyDown(KeyCode.Space);
		if (fire && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Object.Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play();
		}

	}
	void FixedUpdate()
	{
		if(!animationDone) return;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
	
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3
		(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

	public void SetAnimationDone(){
		animationDone = true;
	}
}