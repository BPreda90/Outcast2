using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.OutcastScripts
{
   public abstract class UnitModifier
    {

        protected string negativeStatError = "A character with a negative stat is impossible.";
        // Primary Stats
        public int ModifierStrength
        {
            get
            {
                return _modifierStrength;
            }
            set
            {
                _modifierStrength = value;
            }
        }
        [SerializeField]
        protected int _modifierStrength;

        public int ModifierInteligence
        {
            get
            {
                return _modifierInteligence;
            }
            set
            {
                _modifierInteligence = value;
            }
        }
        [SerializeField]
        protected int _modifierInteligence;

        public int ModifierAgility
        {
            get
            {
                return _modifierAgility;
            }
            set
            {
                _modifierAgility = value;
            }
        }
        [SerializeField]
        protected int _modifierAgility;

        public int ModifierCurrentHealth
        {
            get
            {
                return _modifierCurrentHealth;
            }
            set
            {
                _modifierCurrentHealth = value;
            }
        }
        [SerializeField]
        protected int _modifierCurrentHealth;

        public int ModifierMaxHealth
        {
            get
            {
                return _modifierMaxHealth;
            }
            set
            {
                _modifierMaxHealth = value;
            }
        }
        [SerializeField]
        protected int _modifierMaxHealth;

        public int ModifierSanity
        {
            get
            {
                return _modifierSanity;
            }
            set
            {
                _modifierSanity = value;
            }
        }
        [SerializeField]
        protected int _modifierSanity;

        public int ModifierTracking
        {
            get
            {
                return _modifierTracking;
            }
            set
            {
                _modifierTracking = value;
            }
        }
        [SerializeField]
        protected int _modifierTracking;

        public int ModifierArkaneNnowledge
        {
            get
            {
                return _modifierArkaneKnowledge;
            }
            set
            {
                _modifierArkaneKnowledge = value;
            }
        }
        [SerializeField]
        protected int _modifierArkaneKnowledge;

        public int ModifierExperience
        {
            get
            {
                return _modifierExperience;
            }
            set
            {
                _modifierExperience = value;
            }
        }
        [SerializeField]
        protected int _modifierExperience;

        public int ModifierRangedDamage
        {
            get
            {
                return _modifierRangedDamage;
            }
            set
            {
                _modifierRangedDamage = value;
            }
        }
        [SerializeField]
        protected int _modifierRangedDamage;

        public int ModifierMeleeDamage
        {
            get
            {
                return _modifierMeleeDamage;
            }
            set
            {
                _modifierMeleeDamage = value;
            }
        }
        [SerializeField]
        protected int _modifierMeleeDamage;

        public int ModifierReactivity
        {
            get
            {
                return _modifierReactivity;
            }
            set
            {
                _modifierReactivity = value;
            }
        }
        [SerializeField]
        protected int _modifierReactivity;

        public int ModifierDamageReduction
        {
            get
            {
                return _modifierDamageReduction;
            }
            set
            {
                _modifierDamageReduction = value;
            }
        }
        [SerializeField]
        protected int _modifierDamageReduction;

        public UnitModifier(int modifierAgility, int modifierArkaneNnowledge, int modifierCurrentHealth, int modifierDamageReduction,
            int modifierExperience, int modifierInteligence, int modifierMaxHealth, int modifierMeleeDamage, int modifierRangedDamage,
            int modifierReactivity, int modifierSanity, int modifierStrength, int modifierTracking)
        {

        }

    }

    public class Trait : UnitModifier
    {

        public bool Applied
        {
            get
            {
                return _applied;
            }
            set
            {
                _applied = value;
            }
        }
        [SerializeField]
        protected bool _applied;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new Exception(negativeStatError);
                }

                _name = value;
            }
        }
        [SerializeField]
        protected string _name;

        public Trait (string name, int modifierAgility, int modifierArkaneNnowledge, int modifierCurrentHealth, int modifierDamageReduction,
            int modifierExperience, int modifierInteligence, int modifierMaxHealth, int modifierMeleeDamage, int modifierRangedDamage,
            int modifierReactivity, int modifierSanity, int modifierStrength, int modifierTracking)  
            
            : base( modifierAgility, modifierArkaneNnowledge, modifierCurrentHealth, modifierDamageReduction,
            modifierExperience, modifierInteligence, modifierMaxHealth, modifierMeleeDamage, modifierRangedDamage,
            modifierReactivity, modifierSanity, modifierStrength, modifierTracking)

        {
            Name = name;
            ModifierAgility = modifierAgility;
            ModifierArkaneNnowledge = modifierArkaneNnowledge;
            ModifierCurrentHealth = modifierCurrentHealth;
            ModifierDamageReduction = modifierDamageReduction;
            ModifierExperience = modifierExperience;
            ModifierInteligence = modifierInteligence;
            ModifierMaxHealth = modifierMaxHealth;
            ModifierMeleeDamage = modifierMeleeDamage;
            ModifierRangedDamage = modifierRangedDamage;
            ModifierReactivity = modifierReactivity;
            ModifierSanity = modifierSanity;
            ModifierStrength = modifierStrength;
            ModifierTracking = modifierTracking;
            Applied = false;
        }
    }


    public class Item : UnitModifier
    {
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new Exception(negativeStatError);
                }

                _name = value;
            }
        }
        [SerializeField]
        protected string _name;

        public bool Equipped
        {
            get
            {
                return _equipped;
            }
            set
            {
                _equipped = value;
            }
        }
        [SerializeField]
        protected bool _equipped;


        public enum Type { Cursed, Normal, MasterCrafted, Relic }

        public Type ItemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
            }
        }
        [SerializeField]
        protected Type _itemType;


        public enum Slot { Head, Body, LeftHand, RightHand, Leggs, LeftFoot, RightFoot }

        public Slot ItemSlot 
        {
            get
            {
                return _itemSlot;
            }
            set
            {
                _itemSlot= value;
            }
        }
        [SerializeField]
        protected Slot _itemSlot;



        public Item(bool equipped, string name, Type itemType, Slot itemSlot, int modifierAgility, int modifierArkaneNnowledge, 
              int modifierCurrentHealth, int modifierDamageReduction, int modifierExperience, 
              int modifierInteligence, int modifierMaxHealth,int modifierMeleeDamage, int modifierRangedDamage, 
              int modifierReactivity, int modifierSanity, int modifierStrength, int modifierTracking)

              : base(modifierAgility, modifierArkaneNnowledge, modifierCurrentHealth, modifierDamageReduction,
              modifierExperience, modifierInteligence, modifierMaxHealth, modifierMeleeDamage, modifierRangedDamage,
              modifierReactivity, modifierSanity, modifierStrength, modifierTracking)
        {
            Equipped = equipped;
            if (Equipped != false)
            {
                Debug.LogError("This item has been created with the equipped variable true," +
                    " please only initialize items in an equipped ");
                return;
            }
            Name = name;
            ItemType = itemType;
            ItemSlot = itemSlot;
            ModifierAgility = modifierAgility;
            ModifierArkaneNnowledge = modifierArkaneNnowledge;
            ModifierCurrentHealth = modifierCurrentHealth;
            ModifierDamageReduction = modifierDamageReduction;
            ModifierExperience = modifierExperience;
            ModifierInteligence = modifierInteligence;
            ModifierMaxHealth = modifierMaxHealth;
            ModifierMeleeDamage = modifierMeleeDamage;
            ModifierRangedDamage = modifierRangedDamage;
            ModifierReactivity = modifierReactivity;
            ModifierSanity = modifierSanity;
            ModifierStrength = modifierStrength;
            ModifierTracking = modifierTracking;
        }
    }

    public class ItemUnitTest
    {
        Item TestItem = new Item(false, "UnitTestItem", Item.Type.Cursed, Item.Slot.Head, 10, 10,10,10,10,10,10,10,10,10,10,10,10);
        void Test (Item i)
        {
            if(TestItem.ItemSlot != Item.Slot.Head)
            {
                Debug.LogError("Item Slot unit test failed!" +
                    "Item.Slot is not propperly implemented!");
                Debug.Log(TestItem.ItemSlot);
            }

            else
            {
                Debug.Log(TestItem.ItemSlot);
                Debug.Log("Item Slot unit test passed");
            }

            if (TestItem.ItemType != Item.Type.Cursed)
            {
                Debug.LogError("Item Type  unit test failed!" +
                    "Item Type is not propperly implemented!");
                Debug.Log(TestItem.ItemType);
            }

            else
            {
                Debug.Log(TestItem.ItemType);
                Debug.Log("Item Type unit test passed");
            }


        }
    }

}


