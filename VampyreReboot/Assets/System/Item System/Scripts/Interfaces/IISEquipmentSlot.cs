using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {

	public interface IISEquipmentSlot {
		string Name { get; set; }
		Sprite Icon { get; set; }
	}
}
