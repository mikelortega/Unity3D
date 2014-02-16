using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SplineScript : MonoBehaviour {

	public Transform P1;
	public Transform P2;
	public Transform P3;
	public Transform P4;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.DrawLine(P1.position, P2.position, Color.gray);
		Debug.DrawLine(P3.position, P4.position, Color.gray);

		Vector3 tp0 = P1.position;
		for (float t=0.1f; t < 1.01f; t=t+0.1f)
		{
			Vector3 tp1 = CalculateBezierPoint(t, P1.position, P2.position, P3.position, P4.position);
			Debug.DrawLine(tp0, tp1);
			tp0 = tp1;
		}
	}

	Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		float u = 1 - t;
		float tt = t*t;
		float uu = u*u;
		float uuu = uu * u;
		float ttt = tt * t;
		
		Vector3 p = uuu * p0; //first term
		p += 3 * uu * t * p1; //second term
		p += 3 * u * tt * p2; //third term
		p += ttt * p3;        //fourth term
		
		return p;
	}

}
