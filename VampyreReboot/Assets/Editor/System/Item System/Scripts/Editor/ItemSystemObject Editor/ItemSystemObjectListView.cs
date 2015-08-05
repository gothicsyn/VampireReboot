using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BurgZergArcade.ItemSystem.Editor {

	public partial class ItemSystemObjectEditor {
		private Vector2 _scrollPosition = Vector2.zero;
		private int _listViewWidth = 200;
		private int _listViewButtonWidth = 100;
		private int _listViewButtonHeight = 25;
		private int _selectedIndex = -1;
		
		private void ListView () {

			if(state != DisplayState.NONE)
				return;
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth)); //width in pixels

			for(int cnt =0; cnt < database.Count; cnt++) {
				if(GUILayout.Button(database.Get(cnt).Name, "box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtonHeight))) {
					_selectedIndex = cnt;
					tempWeapon = new ItemSystemWeapon (database.Get(cnt));
//					tempWeapon = new ItemSystemWeapon();
//					tempWeapon.Clone(database.Get(cnt));
					showNewWeaponDetails = true;
					state = DisplayState.DETAILS;
				}
			}

			GUILayout.EndScrollView();
		}
	}
}
