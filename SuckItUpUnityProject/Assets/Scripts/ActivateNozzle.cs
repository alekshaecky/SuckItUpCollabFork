using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNozzle : MonoBehaviour
{

	public GameObject Nozzle1Prefab;
	public GameObject Nozzle2Prefab;
	public GameObject Nozzle3Prefab;
	public GameObject Nozzle4Prefab;
	public GameObject Nozzle5Prefab;

	private GameObject n1;
	private GameObject n2;
	private GameObject n3;
	private GameObject n4;
	private GameObject n5;


	private Vector3 position;
	private Quaternion rotation;
	private Transform parent;


	void Awake()
	{

		// public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);

		parent = GameObject.Find("NozzleParent").transform;

		n1 = Instantiate(Nozzle1Prefab, parent);
		n2 = Instantiate(Nozzle2Prefab, parent);
		n3 = Instantiate(Nozzle3Prefab, parent);
		n4 = Instantiate(Nozzle4Prefab, parent);
		n5 = Instantiate(Nozzle5Prefab, parent);
		deactivateNozzles();

		switch (PlayerPrefs.GetInt("PrefsCurrentVacuumPower"))
		{
			case 1:
				n1.SetActive(true);
				break;
			case 2:
				n2.SetActive(true);
				break;
			case 3:
				n3.SetActive(true);
				break;
			case 4:
				n4.SetActive(true);
				break;
			case 5:
				n5.SetActive(true);
				break;
			default:
				n1.SetActive(true);
				break;
		}
	}

	private void deactivateNozzles()
	{
		n1.SetActive(false);
		n2.SetActive(false);
		n3.SetActive(false);
		n4.SetActive(false);
		n5.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
