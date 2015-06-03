using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	public partial class ISObjectEditor {

		ISWeapon weaponTemp = new ISWeapon();

		bool showWeaponDetails = false;

		void ObjectDetails () {
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			if(showWeaponDetails)
				DisplayNewWeapon();

			GUILayout.EndHorizontal();
			GUILayout.Space(25);

			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DisplayButtons();
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
		}

		void DisplayNewWeapon(){
				weaponTemp.OnGUI();
			}

		void DisplayButtons () {
			if(!showWeaponDetails) {
				if(GUILayout.Button ("Create Weapon")) {
					weaponTemp = new ISWeapon();
					showWeaponDetails = true;
					}
				}
				else {

			if(GUILayout.Button ("Save")) {
				showWeaponDetails = false;
				weaponTemp = null;
			}
			
			if(GUILayout.Button ("Cancel")) {
				showWeaponDetails = false;
				weaponTemp = null;
				}
			}
		}
	}
}
