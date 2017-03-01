using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using GSD.Roads;

public class GSDRoadSystemEditorMenu : ScriptableObject{
	private const bool bRoadTestCubes = false;
	
	[MenuItem( "Window/Road Architect/Create road system" )]
	public static void CreateRoadSystem(){
		Object[] tObj = GameObject.FindObjectsOfType(typeof(GSDRoadSystem));
		int i = (tObj.Length + 1);
		tObj = null;
		
		GameObject tRoadSystemObj = new GameObject("RoadArchitectSystem" + i.ToString());
		GSDRoadSystem tRoadSystem = tRoadSystemObj.AddComponent<GSDRoadSystem>(); 	//Add road system component.
		tRoadSystem.AddRoad(true);//Add road for new road system.
		
		GameObject IntersectionsMasterObject = new GameObject("Intersections");
		IntersectionsMasterObject.transform.parent = tRoadSystemObj.transform;
	}

    //[MenuItem("Window/Road Architect/Test")]
    public static void TestProgram() {
        GSD.Roads.GSDUnitTests.RoadArchitectUnitTests();
    }
                

	[MenuItem( "Window/Road Architect/Add road" )]
	public static void AddRoad(){
		Object[] tObjs = GameObject.FindObjectsOfType(typeof(GSDRoadSystem));
		if(tObjs != null && tObjs.Length == 0){
			CreateRoadSystem();
			return;
		}else{
			GSDRoadSystem GSDRS = (GSDRoadSystem)tObjs[0];
	   	 	Selection.activeGameObject = GSDRS.AddRoad();
		}
	}
	
	[MenuItem( "Window/Road Architect/Update All Roads" )]
	public static void UpdateAllRoads(){
		GSDRoad[] tRoadObjs = (GSDRoad[])GameObject.FindObjectsOfType(typeof(GSDRoad));
		
		int RoadCount = tRoadObjs.Length;
		
		GSDRoad tRoad = null;
		GSDSplineC[] tPiggys = null;
		if(RoadCount > 1){
			tPiggys = new GSDSplineC[RoadCount-1];
		}
		
		for(int h=0;h<RoadCount;h++){
			tRoad=tRoadObjs[h];
			if(h > 0){
				tPiggys[h-1] = tRoad.GSDSpline;
			}
		}

		tRoad=tRoadObjs[0];
		if(tPiggys != null && tPiggys.Length > 0){
			tRoad.PiggyBacks = tPiggys;	
		}
		tRoad.UpdateRoad();
	}
	
	[MenuItem( "Window/Road Architect/Help" )]
	public static void GSDRoadsHelp(){
		GSDHelpWindow tHelp = EditorWindow.GetWindow<GSDHelpWindow>();
		tHelp.Initialize();
	}
	
	[MenuItem( "Window/Road Architect/About" )]
	public static void GSDRoadsAbout(){
		GSDAboutWindow tAbout = EditorWindow.GetWindow<GSDAboutWindow>();
		tAbout.Initialize();
	}
}