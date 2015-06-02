/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 20.05.15
/// Rev. 0.1
/// 
/// Visual side of the Quality database entry system.
/// </summary>

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem.Editor {

	public partial class ISQualityDatabaseEditor : EditorWindow {

		ISQualityDatabase qualityDatabase;
		Texture2D selectedTexture;
		int selectedIndex = -1;					// Used to temporarily store an index for alteration in the database
		Vector2 _scrollpos;						// This is a variable for the Scroll Position call for in ListView.cs part of the partial script.
		
		const int SPRITE_BUTTON_SIZE = 64;

		// Sets the root path for storage and creation of the database
		const string DATABASE_NAME = @"VampireQualityDatabase.asset";
		const string DATABASE_PATH = @"Database";
		const string DATABASE_FULL_PATH = @"Assets" + "/" + DATABASE_PATH + "/" + DATABASE_NAME;

		[MenuItem("VampireRPG/Database/Quality Editor %#w")]

		// Initialises the Editor Window for creation of Item Quality details 
		public static void Init() {
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
			window.minSize = new Vector2 (400, 300);
			window.title = "Quality Database";
			window.Show();
		}

		void OnEnable () {
			qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
			qualityDatabase = qualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
		}


		void OnGUI () {
			ListView();
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			BottomBar();
			GUILayout.EndHorizontal();
		}

		void BottomBar () {
			// Will display count of current items in Database and an add button to add more to the database
			GUILayout.Label("Current Items: " + qualityDatabase.Count);
			if(GUILayout.Button("Add New")){
				qualityDatabase.Add(new ISQuality());
			}
		}
	}
}