/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 29.05.15
/// Rev. 0.1
/// 
/// Sets the Base Equipability of items that will available in game.
/// </summary>
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {

	public interface IISEquip {
		ISEquipmentSlot EquipmentSlot { get; }
		// equipSlot
		bool Equip ();
	}
}
