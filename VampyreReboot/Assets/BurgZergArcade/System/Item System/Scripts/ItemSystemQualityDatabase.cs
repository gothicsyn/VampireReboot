using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq; //needed for ElementAt

namespace BurgZergArcade.ItemSystem
{
	public class ItemSystemQualityDatabase : ScriptableObjectDatabase<ItemSystemQuality>
	{
		public int GetIndex(string name) 
		{
			return database.FindIndex (a => a.Name == name);
		}
	}
}