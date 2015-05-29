using UnityEngine;
using System.Collections;
// IIS stands for Item Interfact System

namespace VampireRPG.ItemSystem {

	public interface IISQuality {
		string Name {get; set;}
		Sprite Icon {get; set;}
	}
}