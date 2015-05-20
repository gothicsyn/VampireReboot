using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {

	public class ISQuality : IISQuality {
		[SerializeField] string _name;
		[SerializeField] Sprite _icon;


		ISQuality () {
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