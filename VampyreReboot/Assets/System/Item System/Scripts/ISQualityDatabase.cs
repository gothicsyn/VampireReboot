/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 20.05.15
/// Rev. 0.2
/// 
/// ISQuality database to allow access, entry, removal and retrieval of data within the Quality Database.
/// </summary>

using UnityEditor;
using UnityEngine;
using System.Linq;								// Required to use ElementAt
using System.Collections;
using System.Collections.Generic;

namespace VampireRPG.ItemSystem {

	public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality> {	
	}
}