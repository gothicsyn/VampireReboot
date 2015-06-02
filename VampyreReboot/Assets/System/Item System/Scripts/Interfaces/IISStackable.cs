using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {

	public interface IISStackable {
		int MaxStack { get; }					// Maximum Value of a Stack
		int Stack (int amount) ;				// Setup with a Default Value of 0
	}
}
