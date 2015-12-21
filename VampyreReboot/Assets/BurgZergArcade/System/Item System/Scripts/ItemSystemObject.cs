﻿using UnityEngine;
using System.Collections;
using UnityEditor;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ItemSystemObject : IItemSystemObject {
	
		[SerializeField]private string _name;
		[SerializeField]private Sprite _icon;
		[SerializeField]private int _value;
		[SerializeField]private int _burden;
		[SerializeField]private ItemSystemQuality _quality;

		public ItemSystemObject (ItemSystemObject item) {
			Clone(item);
		}

		public void Clone(ItemSystemObject item) {
			_name = item.Name;
			_icon = item.Icon;
			_value = item.Value;
			_burden = item.Burden;
			_quality = item.Quality;
		}
	
		public string Name {
			get {
				return _name;
			}
			set  {
				_name = value;
			}
		}
	
		public int Value  {
			get {
				return _value;
			}
			set  {
				_value = value; //if the names were the same like value = value, you can get around any problems by using this.value = value
			}
		}
	
		public Sprite Icon  {
			get {
				return _icon;
			}
			set {
				_icon = value;
			}
		}
	
		public int Burden 
		{
			get 
			{
				return _burden;
			}
			set 
			{
				_burden = value;
			}
		}
	
		public ItemSystemQuality Quality 
		{
			get 
			{
				return _quality;
			}
			set 
			{
				_quality = value;
			}
		}
		
		//this code will be placed in a new class later on.
		private ItemSystemQualityDatabase qdb;
		private int qualitySelectedIndex = 0;
		private string[] options;// = new string[] {"com", "unc", "rar"};
		
		public virtual void OnGUI ()
		{
			GUILayout.BeginVertical();
			_name = EditorGUILayout.TextField("Name", _name);
			_value = EditorGUILayout.IntField ("Value", _value);
			_burden = EditorGUILayout.IntField ("Burden", _burden);

			DisplayIcon();
			DisplayQuality();
			GUILayout.EndVertical();
		}
		
		// To be moved to a seperate Editor Version of this class at a later date in development
		
		public void DisplayIcon ()
		{
			_icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(Sprite), false) as Sprite;
		}

		// Rest of script

		public int SelectedQualityID
		{
			get {return qualitySelectedIndex;}
		}
		
		public ItemSystemObject ()
		{
			string DATABASE_NAME = @"bzaQualityDatabase.asset";
			string DATABASE_PATH = @"Database";
			qdb = ItemSystemQualityDatabase.GetDatabase<ItemSystemQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
		
			options = new string[qdb.Count];
			for(int cnt = 0; cnt < qdb.Count; cnt++)
			{
				options[cnt] = qdb.Get(cnt).Name;
			}
		}
		
		public void DisplayQuality ()
		{
			int itemIndex = 0;

				if(_quality != null)
				itemIndex = qdb.GetIndex (_quality.Name);

			if(itemIndex == -1)
				itemIndex = 0;

			qualitySelectedIndex = EditorGUILayout.Popup("Quality", itemIndex, options);
			_quality = qdb.Get(SelectedQualityID);
		}
	}
}