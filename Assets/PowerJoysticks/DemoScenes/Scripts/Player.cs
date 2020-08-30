using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using TLGFPowerJoysticks;


public class Player : MonoBehaviour {

	public float speed = 10;
	public float jumpPower = 50;
	public Transform bulletContainer;
	public Text ammoInfoText;
	public PowerButton pbA;
	private Transform tr;
	private Rigidbody rb;
	private Bullet[] bullets;
	private int ammo = 50;
	private Renderer rend;


	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
		bullets = bulletContainer.GetComponentsInChildren<Bullet> (true);
		rend = GetComponent<Renderer> ();
	}

	void OnEnable () {
		PowerButton.OnPowerUp += ChangeColor;
		PowerButton.OnRefreshed += ChangeColorTwo;
		PowerButton.OnHoldAndRelease += ChangeColorThree;
	}

	void OnDisable () {
		PowerButton.OnPowerUp -= ChangeColor;
		PowerButton.OnRefreshed -= ChangeColorTwo;
		PowerButton.OnHoldAndRelease -= ChangeColorThree;
	}

	void ChangeColor(GameObject sender) {
		if(sender == pbA.gameObject) {
			StartCoroutine (ChangeColorAnim());
		}
	}

	IEnumerator ChangeColorAnim () {
		rend.material.color = Color.yellow;
		yield return new WaitForSecondsRealtime (2);
		rend.material.color = Color.red;
	}

	void ChangeColorTwo(GameObject sender) {
			StartCoroutine (ChangeColorTwoAnim());
	}
		
	IEnumerator ChangeColorTwoAnim () {
		rend.material.color = Color.green;
		yield return new WaitForSecondsRealtime (1);
		rend.material.color = Color.red;
	}

	void ChangeColorThree(GameObject sender) {
		StartCoroutine (ChangeColorThreeAnim());
	}

	IEnumerator ChangeColorThreeAnim () {
		rend.material.color = Color.blue;
		yield return new WaitForSecondsRealtime (1);
		rend.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		#if MOBILE_INPUT
		float hInput = CrossPlatformInputManager.GetAxis ("Horizontal");
		float vInput = CrossPlatformInputManager.GetAxis ("Vertical");

		Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
		Vector3 move = vInput * cameraForward + hInput * Camera.main.transform.right;

		rb.AddForce (move * speed);

		if(hInput != 0 && vInput != 0) {
			rb.rotation = Quaternion.Lerp (rb.rotation, Quaternion.Euler (0, GetRotationAngle(hInput,vInput), 0), Time.deltaTime * 5);
		}

		if(CrossPlatformInputManager.GetButtonDown("Fire1")) {
			Fire();
		}

		bool grounded = Physics.Raycast (tr.position, Vector3.down, 1.2f);

		if(grounded && CrossPlatformInputManager.GetButtonDown("Jump")) {
			Jump();
		}

		if(grounded && CrossPlatformInputManager.GetButtonUp("PowerJump")) {
			PowerJump();
		}

		if(CrossPlatformInputManager.GetButtonDown("AutoFire")) {
			ToggleAutoFire();
		}

		if(CrossPlatformInputManager.GetButtonUp("Restart")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
		#endif
	}

	public void Fire() {
		if (ammo > 0) {
			foreach (Bullet b in bullets) {
				if (!b.gameObject.activeSelf) {
					b.gameObject.SetActive (true);
					ammo--;
					ammoInfoText.text = "Ammo: " + ammo.ToString ("00");
					break;
				}
			}
		}
	}

	public void FireBurst() {
		StopCoroutine ("Burst");
		StartCoroutine ("Burst");
	}

	IEnumerator Burst () {
		for (int i = 0; i < 10; i++) {
			if (ammo > 0) {
				foreach (Bullet b in bullets) {
					if (!b.gameObject.activeSelf) {
						b.gameObject.SetActive (true);
						ammo--;
						ammoInfoText.text = "Ammo: " + ammo.ToString ("00");
						break;
					}
				}
			}
			yield return new WaitForSeconds (0.05f);
		}
	}

	public void Reload () {
		ammo = 50;
		ammoInfoText.text = "Ammo: " + ammo.ToString ("00");
	}

	public void Jump() {
		rb.AddForce (0, jumpPower, 0, ForceMode.Impulse);
	}

	public void PowerJump() {
		rb.AddForce (0, jumpPower * 3, 0, ForceMode.Impulse);
	}

	public void ToggleAutoFire() {
		pbA.SetButtonEnableAutoFire (!pbA.autoFire, 0.5f);
	}

	private float GetRotationAngle (float x, float y) {
		float angle = Mathf.Atan2 (x, y) * Mathf.Rad2Deg;
		if(angle < 0) {
			angle += 360;
		}
		return angle;
	}

}
