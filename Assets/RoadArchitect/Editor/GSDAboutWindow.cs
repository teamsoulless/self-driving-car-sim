#region "Imports"
using UnityEngine;
using UnityEditor;
#endregion
public class GSDAboutWindow : EditorWindow{
	
	
	void OnGUI() {
		EditorStyles.label.wordWrap = true;
		EditorStyles.miniLabel.wordWrap = true;
		
		EditorGUILayout.LabelField("About Road Architect");
		
		GUILayout.Space(4f);
		EditorGUILayout.LabelField("Created by MicroGSD LLC, \u00a9 2014");
		GUILayout.Space(4f);
		EditorGUILayout.LabelField("Road Architect was created with over 2600 man hours of development. " +
			"It's primary purpose was to allow MicroGSD LLC to create massive AAA quality road sytems across very large terrains, exceeding 256km x 256km distances. " +
			"Another top goal was to allow the road system to be created very fast and quickly in order to be able to facilitate a realistic looking 256km x 256km area. ");
			GUILayout.Space(4f);
		EditorGUILayout.LabelField("At the time of its creation and release, no other addon offered fully fledged multi turn lane intersections, smart terrain history (allowing the terrain to be edited after road generation), " +
			"dynamic deck arch bridges, dynamic suspension bridges, road & shoulder mesh physical mats, multi-threaded generation, source code availability and more. We required all of these aspects and more for the project.");
		GUILayout.Space(4f);
		EditorGUILayout.LabelField("We've significantly exceeded our goals for Road Architect and hope you enjoy the value you receive for your purchase.");
		GUILayout.Space(4f);
		EditorGUILayout.LabelField("Please contact support@microgsd.com with any questions or comments.");
	}
	
	#region "Init"
	public void Initialize(){
		Rect fRect = new Rect(340,170,420,320);
		position = fRect;
        Show();
		title = "About";
    }
	#endregion
}