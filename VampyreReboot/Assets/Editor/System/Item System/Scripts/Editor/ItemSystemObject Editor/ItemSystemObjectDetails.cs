using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemSystemObjectEditor
	{
		enum DisplayState 
		{
			NONE,
			DETAILS
		}

		private ItemSystemWeapon tempWeapon = new ItemSystemWeapon();
		private bool showNewWeaponDetails = false;

		DisplayState state = DisplayState.NONE;
		
		private void ItemDetails ()
		{
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			EditorGUILayout.LabelField("State" + state);

			switch (state)
			{
			case DisplayState.DETAILS:
				if(showNewWeaponDetails)
					DisplayNewWeapon();
				break;
			default:
				break;
			}
			
			GUILayout.EndVertical();
			
			GUILayout.Space(50);
			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DisplayButtons();
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
		}
		
		private void DisplayNewWeapon ()
		{
			tempWeapon.OnGUI();
		}
		
		private void DisplayButtons ()
		{
			if(!showNewWeaponDetails)
			{
				if(GUILayout.Button("Create Weapon"))
				{
					tempWeapon = new ItemSystemWeapon();
					showNewWeaponDetails = true;
					state = DisplayState.DETAILS;
				}
			}
			else
			{
				if(GUILayout.Button("Save"))
				{
					if(_selectedIndex == -1)
						database.Add(tempWeapon);
					else
						database.Replace(_selectedIndex, tempWeapon);

					showNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
				}

				if(_selectedIndex != -1) {

					if(GUILayout.Button("Delete")) {

							database.Remove(_selectedIndex);
						
						showNewWeaponDetails = false;
						tempWeapon = null;
						_selectedIndex = -1;
						state = DisplayState.NONE;
						}
					}

				if(GUILayout.Button("Cancel"))
				{
					showNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
				}
			}
		}
	}
}