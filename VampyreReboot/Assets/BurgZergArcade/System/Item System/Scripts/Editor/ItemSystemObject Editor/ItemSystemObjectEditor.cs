using UnityEngine;
using System.Collections;
using UnityEditor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemSystemObjectEditor : EditorWindow 
	{
		ItemSystemWeaponDatabase database;
		ItemSystemObjectCategory armorDatabase = new ItemSystemObjectCategory();

		private const string DATABASE_NAME = @"bzaWeaponDatabase.asset";
		private const string DATABASE_PATH = @"Database";
		private const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME; //originally @"Assets/Database/bzaQualityDatabase.asset";
		
		[MenuItem("BZA/Database/Item System Editor %#i")] //makes the hotkey ctrl+shift+i. Look up unity menuitem for more hotkey combinations.
		//this function is called when the key combination is pressed
		public static void Init () //must be static for whatever reason
		{
			ItemSystemObjectEditor window = EditorWindow.GetWindow<ItemSystemObjectEditor>();
			window.minSize = new Vector2(800f, 600f);
			window.titleContent = new GUIContent("Item System"); //this line and the two examples above give the same results
			window.Show();
		}
		
		private void OnEnable ()
		{
			if(database == null)
			{
				database = ItemSystemWeaponDatabase.GetDatabase<ItemSystemWeaponDatabase>(DATABASE_PATH, DATABASE_NAME);
			}

			armorDatabase.OnEnable();

			tabState = TabState.ABOUT;
		}
		
		private void OnGUI ()
		{
			TopTabBar();

			GUILayout.BeginHorizontal();

			switch (tabState) {
			case TabState.WEAPON: 
				ListView();
				ItemDetails();
				break;
			case TabState.ARMOR: 
				armorDatabase.ListView (buttonSize, _listViewWidth);
				break;
			case TabState.POTION:
				GUILayout.Label ("State: " + tabState);
				break;
			default:
				GUILayout.Label ("Default State: " + tabState);
				break;
			}



			GUILayout.EndHorizontal();
			
			BottomStatusBar();
		}
	}
}