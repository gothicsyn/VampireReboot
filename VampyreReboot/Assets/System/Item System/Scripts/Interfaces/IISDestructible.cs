/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 29.05.15
/// Rev. 0.1
/// 
/// Sets the Destructability of items that will available in game.
/// </summary>
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem.Editor {
	public interface IISDestructible {

			int Durability { get; }
			int MaxDurability { get; }

			// Durability Stats

			void TakeDamage ( int amount); 
			void Repair ();
			void Break ();

	}
}
