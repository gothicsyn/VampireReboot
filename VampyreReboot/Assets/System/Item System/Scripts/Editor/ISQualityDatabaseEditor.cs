using UnityEditor;
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem.Editor {

	public class ISQualityDatabaseEditor : EditorWindow {
		ISQualityDatabase db;

		const string DATABASE_FILE_NAME = @"VampireQualityDatabase.asset";
		const string DATABASE_FOLDER_NAME = @"Database";
		const string DATABASE_FULL_PATH = @"Assets" + "/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

		[MenuItem("VampireRPG/Database/Quality Editor %#i")]

		public static void Init() {
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
			window.minSize = new Vector2 (400, 300);
			window.title = "Quality Database";
			window.Show();
		}

		void OnEnable () {
			db = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

				if(db == null) {
					if(!AssetDatabase.IsValidFolder("Assets/" + DATABASE_FOLDER_NAME ))
					AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
				
				db = ScriptableObject.CreateInstance<ISQualityDatabase>();
				AssetDatabase.CreateAsset(db, DATABASE_FULL_PATH);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}
		}
	}
}