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

	public class ISQualityDatabaseEditor : EditorWindow {
		ISQualityDatabase qualityDatabase;
		ISQuality selectedItem;
		Texture2D selectedTexture;

		const int SPRITE_BUTTON_SIZE = 92;

		const string DATABASE_FILE_NAME = @"VampireQualityDatabase.asset";
		const string DATABASE_FOLDER_NAME = @"Database";
		const string DATABASE_FULL_PATH = @"Assets" + "/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

		[MenuItem("VampireRPG/Database/Quality Editor %#i")]

		// Initialises the Editor Window for creation of Item Quality details 
		public static void Init() {
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
			window.minSize = new Vector2 (400, 300);
			window.title = "Quality Database";
			window.Show();
		}

		void OnEnable () {
			// This checks if the Item Quality Database is present
			qualityDatabase = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

			// If not will create the database in the desired directory and then apply the asset as well
				if(qualityDatabase == null) {
					if(!AssetDatabase.IsValidFolder("Assets/" + DATABASE_FOLDER_NAME ))
					AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
				
				qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
				AssetDatabase.CreateAsset(qualityDatabase, DATABASE_FULL_PATH);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}

			selectedItem = new ISQuality();
		}


		void OnGUI () {
			AddQualityToDatabase ();
		}


		void AddQualityToDatabase () {
			// Name 
			selectedItem.Name = EditorGUILayout.TextField("Name: ", selectedItem.Name);
			// Sprite
			if(selectedItem.Icon)
				selectedTexture = selectedItem.Icon.texture;
			else
				selectedTexture = null; 

			if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE))) {
				int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
				EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
			}

			string commandName = Event.current.commandName;
			if(commandName == "ObjectSelectorUpdated") {
				selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
				Repaint();
			}

			if(GUILayout.Button("Save")) {
				if(selectedItem == null)
					return;

				qualityDatabase.Add(selectedItem);
				int x = qualityDatabase.Count;

				selectedItem = new ISQuality();
			}
		}
	}
}