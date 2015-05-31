/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 21.05.15
/// Rev. 0.1
/// 
/// Will handle the formatting and information display of the Editor Window
/// </summary>

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace VampireRPG.ItemSystem.Editor {

	public partial class ISQualityDatabaseEditor {

		// List all the stored quality in the database
		void ListView () {
			_scrollpos = EditorGUILayout.BeginScrollView(_scrollpos, GUILayout.ExpandHeight(true));

			DisplayQualities();

			EditorGUILayout.EndScrollView();
		}

		void DisplayQualities () {
			for(int cnt = 0; cnt < qualityDatabase.Count; cnt++) {
			// Styling Controls
				GUILayout.BeginHorizontal("Box");
			// Display sprite of stored field
				if (qualityDatabase.Get(cnt).Icon)
					selectedTexture = qualityDatabase.Get(cnt).Icon.texture;
				else
					selectedTexture = null;

				if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE))) {
					int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
					EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
					selectedIndex = cnt;
				}
				
				string commandName = Event.current.commandName;
				if(commandName == "ObjectSelectorUpdated") {
					if(selectedIndex != -1) {
						qualityDatabase.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
						selectedIndex = -1;
						Repaint();
					}
				}
			
				GUILayout.BeginVertical();
			// Display name of stored field
				qualityDatabase.Get(cnt).Name = GUILayout.TextField(qualityDatabase.Get(cnt).Name);
			
			// Delete Button protion of Display
				if(GUILayout.Button("x", GUILayout.Width(32), GUILayout.Height(32))){
					if(EditorUtility.DisplayDialog("Delete Quality",
					                               // Text in the Dialogue box
					                               "Are you sure you wish to delete this item" + qualityDatabase.Get(cnt).Name, 
					                               // Yes and No Button Names
					                               "OK", "Cancel"))
						qualityDatabase.Remove(cnt);
				}

				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}
		}
	}
}
