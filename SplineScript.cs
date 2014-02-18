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

		MeshFilter mf = GetComponent(typeof(MeshFilter)) as MeshFilter;
		Mesh mesh = mf.sharedMesh;
		if (mesh == null)
		{
			mf.sharedMesh = new Mesh();
			mesh = mf.sharedMesh;
			mesh.name = "railway";
		}
		mesh.Clear();

		Vector3[] vertices = new Vector3[4];
		vertices[0] = new Vector3(0, 0, 0);
		vertices[1] = new Vector3(1, 0, 0);
		vertices[2] = new Vector3(0, 0, 1);
		vertices[3] = new Vector3(1, 0, 1);
		mesh.vertices = vertices;

		Vector2[] uv = new Vector2[4];
		uv[0] = new Vector2(0, 0);
		uv[1] = new Vector2(0, 1);
		uv[2] = new Vector2(1, 0);
		uv[3] = new Vector2(1, 1);
		mesh.uv = uv;

		int[] triangles = new int[6];
		triangles[0] = 0;
		triangles[1] = 2;
		triangles[2] = 1;
		triangles[3] = 1;
		triangles[4] = 2;
		triangles[5] = 3;
		mesh.triangles = triangles;

		mesh.RecalculateNormals();

	}

	Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		// P(t) = (1 - t)^3 * P0 + 3t(1-t)^2 * P1 + 3t^2 (1-t) * P2 + t^3 * P3

		float u   = (1 - t);
		float tt  = t*t;
		float uu  = u*u;
		float uuu = uu * u;
		float ttt = tt * t;
		
		Vector3 p = uuu * p0;
		p += 3 * t * uu * p1;
		p += 3 * tt * u * p2;
		p += ttt * p3;
		
		return p;
	}

	Vector3 CalculateBezierTangent(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		// dP(t) / dt =  -3(1-t)^2 * P0 + 3(1-t)^2 * P1 - 6t(1-t) * P1 - 3t^2 * P2 + 6t(1-t) * P2 + 3t^2 * P3

		float u  = (1 - t);
		float tt = t*t;
		float uu = u*u;

		Vector3 p = -3 * uu * p0;
		p +=  3 * uu * p1;
		p += -6 * t * u * p1;
		p += -3 * tt * p2;
		p +=  6 * t * u * p2;
		p +=  3 * tt * p3;
		p.Normalize();

		return p;
	}

}
