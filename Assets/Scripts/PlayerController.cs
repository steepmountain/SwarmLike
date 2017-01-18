using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed = 1f;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.position = Vector2.Lerp(transform.position, mousePos, 100 / speed);
    }
}
