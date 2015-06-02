using UnityEngine;
using System.Collections;

namespace VampireRPG.ItemSystem {
	[System.Serializable]
	public class ISWeapon : ISObject, IISWeapon, IISDestructible, IISEquip, IISGameObject {

		[SerializeField] int _minDamage;
		[SerializeField] int _durability;
		[SerializeField] int _maxDurability;
		[SerializeField] ISEquipmentSlot _equipmentSlot;
		[SerializeField] GameObject _prefab;

		//Sets these paramters to new
		public ISWeapon () {
			_equipmentSlot = new ISEquipmentSlot();
			_prefab = new GameObject();
		}
		                 
		// These values are created once the item is created a single instance only.
		public ISWeapon (int durability, int maxDurability, ISEquipmentSlot equipmentSlot, GameObject prefab) {
			_durability = durability;
			_maxDurability = maxDurability;
			_equipmentSlot = equipmentSlot;
			_prefab = prefab;
		}

		#region IISWeapon implementation
		// Inherited from IISWeapon Interface

		public int Attack ()
		{ throw new System.NotImplementedException (); }

		// Calls the minimum damage a weapon can do
		public int MinDamage {
			get { return _minDamage; }
			set { _minDamage = value; }
		}

		#endregion

		#region IISDestructible implementation
		// Inherited from IISDestructible Interface

		public int Durability {
			get { return _durability; }
		}

		public int MaxDurability {
			get { return _maxDurability; }
		}

		// Will set the amount of damage an item takes against its overall durability
		public void TakeDamage (int amount) { 
			_durability -= amount; 
			
			// If the durability value drops below 0, it will call the break routine.
			if(_durability < 0)
				Break();
		}
		
		public void Repair () {
			// Lower the item durability by 1 
			_maxDurability--;
			
			// Set the item durability back to MaxDur unless it's now 0
			if (_maxDurability > 0)
				_durability = _maxDurability;
		}
		
		// Reduce and hold the Durability to a 0 value rendering the item unuseable.
		public void Break ()
		{
			_durability = 0;
		}

		#endregion

		#region IISEquip implementation
		// Inherited from Equipment Slow

		public bool Equip ()
		{ throw new System.NotImplementedException (); }

		public ISEquipmentSlot EquipmentSlot {
			get { return _equipmentSlot; }
		}

		#endregion

		#region IISGameObject implementation

		public GameObject Prefab {
			get { return _prefab; }
		}

		#endregion
	}
}
