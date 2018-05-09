using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Xml.Linq;

public class Graph : MonoBehaviour {

	public  Transform pointPrefab;
	private Transform[] points;

	[Range(10, 100)]
	public int resolution = 10;

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {

		//Transform point = Instantiate (pointPrefab);

		/*
		point.localPosition = Vector3.right;

		point = Instantiate (pointPrefab);
		point.localPosition = Vector3.right * 2f;
		*/

		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;

		Vector3 position;
		position.z = 0f;
		position.y = 0f;
		points = new Transform[resolution];
		for (int i = 0; i < resolution; i++) {
			Transform point = Instantiate (pointPrefab);
			point.localScale = scale;
			points [i] = point;
			position.x = (i + 0.5f) * step - 1f;
			point.localPosition = position;
			point.SetParent(transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < points.Length; i++) {
			Transform point  = points [i];
			Vector3 position = point.localPosition;
			//position.y = position.x * position.x * position.x;
			position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
			point.localPosition = position;
		}
	}
}
