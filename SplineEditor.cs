using UnityEngine;
using UnityEditor;

public class LanderSplineEditor : EditorWindow
{
	[MenuItem ("Lander Tools/Lander Splines")]
	private static void showEditor ()
	{
		EditorWindow.GetWindow<LanderSplineEditor>(false, "Lander Splines");
	}

	void OnGUI ()
	{
		if (GUILayout.Button("My editor button"))
		{
			Debug.Log("Having fun");
			//GameObject clone = (GameObject)Instantiate(Resources.Load("Spline"));
		}
	}
}
