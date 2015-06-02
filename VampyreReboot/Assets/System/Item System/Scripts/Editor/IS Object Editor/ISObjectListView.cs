/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 02.06.15
/// Rev. 0.1
/// 
/// ISObject database to allow access, entry, removal and retrieval of data within the Object Management Database.
/// This part of the Partial is designed to handle the base List View Aspect of the Editor.
/// </summary>
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	public partial class ISObjectEditor {
		Vector2 _scrollpos = Vector2.zero;
		int _listViewWidth = 200;

		void ListView() {
			_scrollpos = GUILayout.BeginScrollView(_scrollpos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

			GUILayout.Label("List View");

			GUILayout.EndScrollView();
		}
	}
}
