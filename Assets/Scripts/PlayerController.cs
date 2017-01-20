using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2d;
	public GameObject laserPrefab;
	public Vector3 bulletOffset = new Vector3(0,0,0);
	public float delay = 0.25f;
	public float cooldown = 0;
    public float speed = 1f;
	public float force = 3f;
	public Vector3 velocity = Vector3.zero;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {

		cooldown -= Time.deltaTime;

		if (Input.GetMouseButtonDown(0)) {
			cooldown = delay;
			Vector3 offset = transform.rotation * bulletOffset;
			GameObject liveLaser = (GameObject)Instantiate (laserPrefab, (Vector3)transform.position + offset, transform.rotation);
			liveLaser.layer = 10;
		}

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.position = Vector2.Lerp(transform.position, mousePos, 100 / speed);

	}
}
