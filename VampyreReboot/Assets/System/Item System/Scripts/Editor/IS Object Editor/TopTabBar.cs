/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 02.06.15
/// Rev. 0.1
/// 
/// ISObject database to allow access, entry, removal and retrieval of data within the Object Management Database.
/// This part of the Partial is designed to handle the accessible data from the Top Tabs of the Editor.
/// </summary>
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	public partial class ISObjectEditor {

		void TopTabBar () {
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			WeaponTab();
			ArmourTab();
			Consumables();
			About();

			GUILayout.EndHorizontal();
		}

		void WeaponTab () {
			GUILayout.Button("Weapons");
		}

		void ArmourTab () {
			GUILayout.Button("Armour");
		}

		void About () {
			GUILayout.Button("About");
		}

		void Consumables () {
			GUILayout.Button("Consumables");
		}
	}
}
