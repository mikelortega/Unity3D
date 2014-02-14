using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SplineScript : MonoBehaviour {

	private LineRenderer lineRenderer;

	public Transform P1;
	public Transform P2;
	public Transform P3;
	public Transform P4;

	// Use this for initialization
	void Start () {
	
		lineRenderer = GetComponent<LineRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		lineRenderer.SetPosition (0, P1.position);
		lineRenderer.SetPosition (1, P2.position);
		lineRenderer.SetPosition (2, P3.position);
		lineRenderer.SetPosition (3, P4.position);

		Debug.DrawLine(P1.position, P2.position);
		Debug.DrawLine(P2.position, P3.position);
		Debug.DrawLine(P3.position, P4.position);

		lineRenderer.material.SetColor("TransparentSpline", new Color(1, 1, 1, 0.0f));

	}
}
