using UnityEditor;
using UnityEngine;

public class ScenePhysicsTool : EditorWindow
{
	private void OnGUI()
	{
		if (GUILayout.Button("Run Physics"))
			StepPhysics();

		if (GUILayout.Button("Run Physics (10 Steps)"))
		{
			for (int i = 0; i < 10; ++i)
				StepPhysics();
		}
	}

	private void StepPhysics()
	{
		Physics.autoSimulation = false;
		Physics.Simulate(Time.fixedDeltaTime);
		Physics.autoSimulation = true;
	}

	[MenuItem("Tools/Scene Physics")]
	private static void OpenWindow()
	{
		GetWindow<ScenePhysicsTool>(false, "Physics", true);
	}
}