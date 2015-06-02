using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	public interface IISWeapon {

		int MinDamage { get; set; }
		int Attack();

	}
}
