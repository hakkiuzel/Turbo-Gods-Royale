using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabPreview : MonoBehaviour {

	public Transform prefabContainer;
	public Text currentPrefabName;
	private Transform[] prefabs;
	private Transform activePrefab;
	private int prefabIndex = 0;


	// Use this for initialization
	void Start () {
		prefabs = new Transform[prefabContainer.childCount];
		prefabs = GetComponentsInDirectChildren<Transform> (prefabContainer);
		activePrefab = prefabs [prefabIndex];
		activePrefab.gameObject.SetActive (true);
		currentPrefabName.text = activePrefab.name;
	}

	public void NextPrefab () {
		activePrefab.gameObject.SetActive (false);
		prefabIndex++;
		if (prefabIndex > prefabs.Length - 1) {
			prefabIndex = 0;
		}
		activePrefab = prefabs [prefabIndex];
		activePrefab.gameObject.SetActive (true);
		currentPrefabName.text = activePrefab.name;
	}

	public void PrevPrefab () {
		activePrefab.gameObject.SetActive (false);
		prefabIndex--;
		if (prefabIndex < 0) {
			prefabIndex =  prefabs.Length - 1;
		}
		activePrefab = prefabs [prefabIndex];
		activePrefab.gameObject.SetActive (true);
		currentPrefabName.text = activePrefab.name;
	}

	// Get content pages / returns only 1st level components
	private static T[] GetComponentsInDirectChildren<T>(Transform t) {
		int index = 0;
		foreach (Transform t2 in t) {
			if (t2.GetComponent<T>() != null) {
				index++;
			}
		}
		T[] returnArray = new T[index];
		index = 0;
		foreach (Transform t2 in t) {
			if (t2.GetComponent<T>() != null) {
				returnArray[index++] = t2.GetComponent<T>();
			}
		}
		return returnArray;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			NextPrefab ();
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			PrevPrefab ();
		}
	}
}
