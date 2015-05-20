using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {

	public interface IISObject {
		// Name
		// Value - Gold Value
		// Icon - Sprite Representation of each object
		// Burden - Will probably be some variant of a weight value vs the players strength or carry limit
		// Quality - Common, Uncommon, Rare, Legendary

		string ISName { get; set; }
		int ISValue { get; set; }
		Sprite ISIcon {get; set;}
		int ISBurden {get; set;}
		ISQuality ISQuality {get; set;}


		// Below are listed other Item Interfaces that will eventually be set.
		// Equip 
		// Quest Item Flag - Will prevent quest items being damaged or destroyed
		// Durability
		// Take Damage
		// Prefab - such as weapon mesh or shield mesh objects
	}
}