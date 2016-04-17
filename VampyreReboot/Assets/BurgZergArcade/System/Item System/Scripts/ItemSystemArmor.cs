#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ItemSystemArmor : ItemSystemObject, IItemSystemArmor, IItemSystemDestructable, IItemSystemGameObject {
		[SerializeField] int _curArmor;
		[SerializeField] int _maxArmor;
		[SerializeField] int _durability;
		[SerializeField] int _maxDurability;

		[SerializeField] GameObject _prefab;

		public EquipmentSlot equipmentSlot;

		public ItemSystemArmor (){
			_curArmor = 0;
			_maxArmor = 0;
			_durability = 1;
			_maxDurability = 1;
			equipmentSlot = EquipmentSlot.Torso;
		}

		public ItemSystemArmor (ItemSystemArmor armor) {
			Clone(armor);
		}

		public void Clone (ItemSystemArmor armor) {
			base.Clone(armor);

			_curArmor = armor._curArmor;
			_maxArmor = armor._maxArmor;
			_durability = armor.Durability;
			_maxDurability = armor.MaxDurability;
			equipmentSlot = armor.equipmentSlot;
			_prefab = armor.Prefab;
		}

		#region IItemSystemGameObject implementation

		public GameObject Prefab 
		{
			get {
				if (!_prefab)
					_prefab = new GameObject ();

				return _prefab;
			}
		}

		#endregion

		#region IItemSystemDestructable implementation

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
			get  { return _durability; }
		}

		public int MaxDurability 
		{ 
			get { return _maxDurability; }
		}

		#endregion


		#region IItemSystemArmor implementation
		public Vector2 Armor {
			get {
				return new Vector2 (_curArmor, _maxArmor);
			}

			set {
				if (value.x < 0) // Sets the minimum or _curArmor to 0 at all times to prevent negative values
					value.x = 0;
				if (value.y < 1) // Sets the value of Max Armor to 1 ensuring there are no negative values
					value.y = 1;
				if (value.x > value.y) // Ensure the value af curArmor is never lower than maxArmor
					value.x = value.y;

				_curArmor = (int)value.x;
				_maxArmor = (int)value.y;
				}
			}

		#endregion
 //inherits the class ItemSystemObject and many other interfaces {


//this code will go into a new script later

		#if UNITY_EDITOR
		public override void OnGUI ()// This OnGUI method overrides whatever OnGUI method we have in the base class
		{
			base.OnGUI();

			_curArmor = EditorGUILayout.IntField ("Armor", _curArmor);
			_maxArmor = EditorGUILayout.IntField ("Max Armor", _maxArmor);
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
