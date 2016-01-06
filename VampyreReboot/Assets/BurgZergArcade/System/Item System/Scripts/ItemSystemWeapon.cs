#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ItemSystemWeapon : ItemSystemObject, IItemSystemWeapon, IItemSystemDestructable, IItemSystemGameObject //inherits the class ItemSystemObject and many other interfaces
	{
		[SerializeField] private int _minDamage;
		[SerializeField] private int _durability;
		[SerializeField] private int _maxDurability;
		[SerializeField] private GameObject _prefab;
		
		public EquipmentSlot equipmentSlot;

		public ItemSystemWeapon () {
			_minDamage = 0;
			_durability = 1;
			_maxDurability = 1;
			equipmentSlot = EquipmentSlot.Torso;
		}			// Constructor
		
		public ItemSystemWeapon (ItemSystemWeapon weapon) {
			Clone(weapon);
		}

		public void Clone (ItemSystemWeapon weapon) {
			base.Clone(weapon);

			_minDamage = weapon.minDamage;
			_durability = weapon.Durability;
			_maxDurability = weapon.MaxDurability;
			equipmentSlot = weapon.equipmentSlot;
			_prefab = weapon.Prefab;
		}
		
		//IItemSystemWeapon Implementation
		public int minDamage {
			get {
				return _minDamage;
			}
			set {
				_minDamage = value;
			}
		}
		
		public int Attack () {
			throw new System.NotImplementedException ();
		}

		//IItemSystemDestructable
		public void TakeDamage (int amount) { //this is when the item takes damage 
			_durability -= amount;
			
			if(_durability < 0) {
				_durability = 0;
			}
		}

		public void Repair () {
			_maxDurability--;
			
			if(_maxDurability > 0) {
				_durability = _maxDurability;
			}
		}

		//set the durability to zero.
		public void Break ()
		{
			_durability = 0;
		}

		public int Durability 
		{
			get 
			{
				return _durability;
			}
		}

		public int MaxDurability 
		{
			get 
			{
				return _maxDurability;
			}
		}

		public GameObject Prefab 
		{
			get {
				if (!_prefab)
					_prefab = new GameObject ();
				
				return _prefab;
			}
		}

		//this code will go into a new script later


		#if UNITY_EDITOR
		public override void OnGUI ()// This OnGUI method overrides whatever OnGUI method we have in the base class
		{
			base.OnGUI();

			_minDamage = EditorGUILayout.IntField ("Damage", _minDamage);
			_durability = EditorGUILayout.IntField ("Durability", _durability);
			_maxDurability = EditorGUILayout.IntField ("Max Durability", _maxDurability);

			DisplayEquipmentSlot();
			DisplayPrefab();
		}
		
		public void DisplayEquipmentSlot ()
		{
			equipmentSlot = (EquipmentSlot) EditorGUILayout.EnumPopup("Equipment Slot", equipmentSlot);
		}
		
		public void DisplayPrefab ()
		{
			_prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
		}
		#endif

	}
}