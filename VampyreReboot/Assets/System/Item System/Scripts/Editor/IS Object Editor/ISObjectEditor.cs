/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 02.06.15
/// Rev. 0.1
/// 
/// ISObject database to allow access, entry, removal and retrieval of data within the Object Management Database.
/// This part of the Partial is designed to handle the base Unity Functions, making it easier to edit later.
/// </summary>
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {

	public partial class ISObjectEditor : EditorWindow {
		[MenuItem("VampireRPG/Database/Object Editor %#i")]
		
		// Initialises the Editor Window for creation of Item Quality details 
		public static void Init() {
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
			window.minSize = new Vector2 (800, 600);
			window.title = "Object Editor";
			window.Show();
		}
	
		void OnEnable () {
		}

		void OnGUI (){
			TopTabBar();

			GUILayout.BeginHorizontal();

			ListView ();
			ObjectDetails();

			GUILayout.EndHorizontal();

			BottomStatusBar();
		}
	}
}
