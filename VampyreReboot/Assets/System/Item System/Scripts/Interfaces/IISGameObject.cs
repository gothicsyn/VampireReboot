/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 29.05.15
/// Rev. 0.1
/// 
/// Sets Prefabs that will useable inside the game environment.
/// </summary>
using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem.Editor {

	public interface IISGameObject {
		GameObject Prefab { get; set; }
	}
}
