/// <summary>
/// The Vampire Legends
/// Copyright M A Games 2015
/// 20.05.15
/// Rev. 0.2
/// 
/// Sets the Quality of items that will available in game.
/// </summary>

using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {

	[System.Serializable]
	public class ISQuality : IISQuality {
		[SerializeField] string _name;
		[SerializeField] Sprite _icon;


		public ISQuality () {
			_icon = new Sprite();
			_name = "Common";
		}

		#region IISQuality implementation

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		public Sprite Icon {
			get {
				return _icon;
			}
			set {
				_icon = value;
			}
		}

		#endregion


	}
}