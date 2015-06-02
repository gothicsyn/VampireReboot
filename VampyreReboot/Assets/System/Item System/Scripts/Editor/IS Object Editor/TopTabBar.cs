using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	public partial class ISObjectEditor {

		void TopTabBar () {
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			GUILayout.Button("Weapons");
			GUILayout.Button("Armour");
			GUILayout.Button("Potions");
			GUILayout.Button("About");
			GUILayout.EndHorizontal();
		}
	}
}
