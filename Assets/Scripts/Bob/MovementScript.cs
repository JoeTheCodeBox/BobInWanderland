using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public bool canMove = true;
	public bool resetScale = false;
    public float bobSpeed = 10.0f;
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 position = transform.position;
		if (canMove) {
			if (Input.GetKey(KeyCode.D)) {
				position += Vector3.right * bobSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.A)) {
				position += Vector3.left* bobSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.S)) {
				position += Vector3.forward * bobSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.X)) {
				position += Vector3.back* bobSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.W)) {
				position += Vector3.up * bobSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.E)) {
				position += Vector3.down * bobSpeed * Time.deltaTime;
			}
		}

		if (Input.GetKeyDown(KeyCode.M)) {
			ScaleUp();
		}
		if (Input.GetKeyDown(KeyCode.N)) {
			ScaleDown();
		}
		if (Input.GetKeyDown(KeyCode.U)) {
			bobSpeed = Mathf.Clamp(bobSpeed + 10.0f, 10.0f, 50.0f);
		}
		if (Input.GetKeyDown(KeyCode.I)) {
			bobSpeed = Mathf.Clamp(bobSpeed - 10.0f, 10.0f, 50.0f);
		}
		if(resetScale) ResetScale();
		transform.position = new Vector3(
			Mathf.Clamp(position.x, -40, 40),
			Mathf.Clamp(position.y, 0, float.MaxValue),
			Mathf.Clamp(position.z, -40, 40)
		);
    }
	public void ScaleUp() {
		if (!canMove) return;
		Vector3 scale = transform.localScale;
		scale += new Vector3(.33f,.33f,.33f);
		scale.x = Mathf.Clamp(scale.x, .05f, 2.5f);
		scale.y = Mathf.Clamp(scale.y, .05f, 2.5f);
		scale.z = Mathf.Clamp(scale.z, .05f, 2.5f);
		transform.localScale = scale;
		AudioSource pop = this.gameObject.GetComponent<AudioSource>();

		pop.Play();
		if (transform.localScale.x > 2.0f) {
			Animator anim = this.gameObject.GetComponent<Animator>();
			canMove = false;
			//death anim
			anim.SetTrigger("Bob_too_large");
		}
	}

	public void ScaleDown() {
		if (!canMove) return;
		Vector3 scale = transform.localScale;
		scale -= new Vector3(.33f,.33f,.33f);
		scale.x = Mathf.Clamp(scale.x, .05f, 5.0f);
		scale.y = Mathf.Clamp(scale.y, .05f, 5.0f);
		scale.z = Mathf.Clamp(scale.z, .05f, 5.0f);
		transform.localScale = scale;
		AudioSource pop = this.gameObject.GetComponent<AudioSource>();

		pop.Play();

		if (transform.localScale.x < .1f) {
			Animator anim = this.gameObject.GetComponent<Animator>();
			canMove = false;
			anim.SetTrigger("Bob_too_small");
		}
	}

	public void ResetScale() {
		resetScale = false;
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
}
