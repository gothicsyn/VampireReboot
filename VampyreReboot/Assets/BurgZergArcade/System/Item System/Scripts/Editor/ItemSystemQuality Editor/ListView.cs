﻿using UnityEngine;
using System.Collections;
using UnityEditor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemSystemQualityDatabaseEditor
	{	
		//list all of the stored qualities in the database
		private void ListView ()
		{
			GUILayout.Label("Displayed");
			_scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, GUILayout.ExpandHeight(true));
			DisplayQualities();
			EditorGUILayout.EndScrollView();
		}
		
		private void DisplayQualities ()
		{
			for(int cnt = 0; cnt < qualityDatabase.Count; cnt++)
			{
				GUILayout.BeginHorizontal("Box");
				//sprite
				if(qualityDatabase.Get(cnt).Icon)
				{
					selectedTexture = qualityDatabase.Get(cnt).Icon.texture;
				}
				else
				{
					selectedTexture = null;
				}
				
				if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
				{
					int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
					EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlerID);
					selectedIndex = cnt;
				}
				
				string commandName = Event.current.commandName;
				if(commandName == "ObjectSelectorUpdated")
				{
					if(selectedIndex == -1)
					{
						qualityDatabase.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
						selectedIndex = -1;
					}
					
					Repaint();
				}
				
				GUILayout.BeginVertical();
				//name
				qualityDatabase.Get(cnt).Name = GUILayout.TextField(qualityDatabase.Get(cnt).Name); //display qualityDatabase.Get(cnt).Name in a text field, but also assign the value of that text field back to the variable Name
				
				//delete button
				if(GUILayout.Button("x", GUILayout.Width(30), GUILayout.Height(25)))
				{
					if(EditorUtility.DisplayDialog("Delete Quality", 
													"Are you sure you want to delete " + qualityDatabase.Get(cnt).Name + " from the database?", 
													"Delete", 
													"Cancel"))
					{
						qualityDatabase.Remove(cnt);
					}
				}
				
				GUILayout.EndVertical();
				
				GUILayout.EndHorizontal();
			}
		}
	}
}
