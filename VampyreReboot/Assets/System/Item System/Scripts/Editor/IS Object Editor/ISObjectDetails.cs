using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	public partial class ISObjectEditor {

		void ObjectDetails () {
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			GUILayout.Label("Details View");

			GUILayout.EndHorizontal();
		}
	}
}
