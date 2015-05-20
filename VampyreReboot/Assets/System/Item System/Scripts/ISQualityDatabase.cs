using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VampireRPG.ItemSystem {

	public class ISQualityDatabase : ScriptableObject {
//		[SerializeField]
		public List<ISQuality> database = new List<ISQuality>();
	}
}