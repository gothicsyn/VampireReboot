using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	public partial class ISObjectEditor {

		void BottomStatusBar () {
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

			GUILayout.Label("Status");

			GUILayout.EndHorizontal();
		}
	}
}
