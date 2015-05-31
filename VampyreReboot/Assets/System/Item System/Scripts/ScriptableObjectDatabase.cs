using UnityEditor;
using UnityEngine;
using System.Linq;							// Require for ElementAt variable
using System.Collections;
using System.Collections.Generic;

namespace VampireRPG {
	public class ScriptableObjectDatabase<T> : ScriptableObject where T: class {

		[SerializeField] List<T> database = new List<T>();

		public void Add (T item) {
			database.Add(item);
			EditorUtility.SetDirty(this);
		}
		
		public void Insert (int index, T item) {
			database.Insert(index, item);
			EditorUtility.SetDirty(this);
		}
		
		public void Remove (T item) {
			database.Remove(item);
			EditorUtility.SetDirty(this);
		}
		
		public void Remove (int index) {
			database.RemoveAt(index);
			EditorUtility.SetDirty(this);
		}
		
		public int Count { 
			get { return database.Count; }
		}
		
		public T Get (int index) {
			return database.ElementAt(index);
		}
		
		public void Replace (int index, T item) {
			database[index] = item;
			EditorUtility.SetDirty(this);
		}

		public U GetDatabase<U>(string dbPath, string dbName) where U: ScriptableObject {
			string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

		// This checks if the Item Quality Database is present
		U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;
		
		// If not will create the database in the desired directory and then apply the asset as well
		if(db == null) {
			//Checks to see if the folder is valid
			if(!AssetDatabase.IsValidFolder(@"Assets/" + dbPath ))
			// If the folder does NOT exist will go ahead and create it at the desired default level
				AssetDatabase.CreateFolder(@"Assets", dbPath);
			
			// Refresh the Asset Database
			db = ScriptableObject.CreateInstance<U>() as U;
			AssetDatabase.CreateAsset(db, dbFullPath);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			}

			return db;
		}
	}
}
