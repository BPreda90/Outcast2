using System.Collections.Generic;
using UnityEngine;


namespace Assets.OutcastScripts
{

    public class CreatureToGameObject : MonoBehaviour
    {

        HashSet<Trait> unitTraits = new HashSet<Trait>();
        HashSet<Item> unitItems = new HashSet<Item>();
        Hunter h;
        void AddTraitAndModifiers(Trait t, Hunter h)
        {
            unitTraits.Add(t);
            Debug.Log("Applying the modifiers for the " + t.Name + " trait to hunter" + h.Name + "\n");
            Debug.Log("Current Stats: " + "\n" +
                "Agility = " + h.Agility + "\n" +
                "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                "CurrentHealth = " + h.CurrentHealth + "\n" +
                "DamageReduction = " + h.CurrentHealth + "\n" +
                "Experience = " + h.Experience + "\n" +
                "Inteligence = " + h.Inteligence + "\n" +
                "MaxHealth = " + h.MaxHealth + "\n" +
                "MeleeDamage = " + h.MaxHealth + "\n" +
                "RangedDamage = " + h.RangedDamage + "\n" +
                "Reactivity = " + h.Reactivity + "\n" +
                "Sanity = " + h.Sanity + "\n" +
                "Strength = " + h.Strength + "\n" +
                "Tracking = " + h.Tracking + "\n");

            if (t.Applied == false)
            {
                h.ModifierAgility += t.ModifierAgility;
                h.ModifierArkaneNnowledge += t.ModifierArkaneNnowledge;
                h.ModifierCurrentHealth += t.ModifierCurrentHealth;
                h.ModifierDamageReduction += t.ModifierDamageReduction;
                h.ModifierExperience += t.ModifierExperience;
                h.ModifierInteligence += t.ModifierInteligence;
                h.ModifierMaxHealth += t.ModifierMaxHealth;
                h.ModifierMeleeDamage += t.ModifierMeleeDamage;
                h.ModifierRangedDamage += t.ModifierRangedDamage;
                h.ModifierReactivity += t.ModifierReactivity;
                h.ModifierSanity += t.ModifierSanity;
                h.ModifierStrength += t.ModifierStrength;
                h.ModifierTracking += t.ModifierTracking;

                t.Applied = true;

                h.UpdateStatsWithModifiers();
                Debug.Log("Updated Stats: " + "\n" +
                    "Agility = " + h.Agility + "\n" +
                    "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                    "CurrentHealth = " + h.CurrentHealth + "\n" +
                    "DamageReduction = " + h.CurrentHealth + "\n" +
                    "Experience = " + h.Experience + "\n" +
                    "Inteligence = " + h.Inteligence + "\n" +
                    "MaxHealth = " + h.MaxHealth + "\n" +
                    "MeleeDamage = " + h.MaxHealth + "\n" +
                    "RangedDamage = " + h.RangedDamage + "\n" +
                    "Reactivity = " + h.Reactivity + "\n" +
                    "Sanity = " + h.Sanity + "\n" +
                    "Strength = " + h.Strength + "\n" +
                    "Tracking = " + h.Tracking + "\n");

            }
            else
            {
                Debug.LogError("This trait has already been applied to this hunter");
            }
        }


        void RemoveTraitAndModifiers(Trait t, Hunter h)
        {
            if (t.Applied == true && unitTraits.Contains(t))
            {
                Debug.Log("Removing the modifiers for the " + t.Name + " trait to hunter" + h.Name + "\n");
                Debug.Log("Current Stats: " + "\n" +
                    "Agility = " + h.Agility + "\n" +
                    "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                    "CurrentHealth = " + h.CurrentHealth + "\n" +
                    "DamageReduction = " + h.CurrentHealth + "\n" +
                    "Experience = " + h.Experience + "\n" +
                    "Inteligence = " + h.Inteligence + "\n" +
                    "MaxHealth = " + h.MaxHealth + "\n" +
                    "MeleeDamage = " + h.MaxHealth + "\n" +
                    "RangedDamage = " + h.RangedDamage + "\n" +
                    "Reactivity = " + h.Reactivity + "\n" +
                    "Sanity = " + h.Sanity + "\n" +
                    "Strength = " + h.Strength + "\n" +
                    "Tracking = " + h.Tracking + "\n");

                h.ModifierAgility -= t.ModifierAgility;
                h.ModifierArkaneNnowledge -= t.ModifierArkaneNnowledge;
                h.ModifierCurrentHealth -= t.ModifierCurrentHealth;
                h.ModifierDamageReduction -= t.ModifierDamageReduction;
                h.ModifierExperience -= t.ModifierExperience;
                h.ModifierInteligence -= t.ModifierInteligence;
                h.ModifierMaxHealth -= t.ModifierMaxHealth;
                h.ModifierMeleeDamage -= t.ModifierMeleeDamage;
                h.ModifierRangedDamage -= t.ModifierRangedDamage;
                h.ModifierReactivity -= t.ModifierReactivity;
                h.ModifierSanity -= t.ModifierSanity;
                h.ModifierStrength -= t.ModifierStrength;
                h.ModifierTracking -= t.ModifierTracking;

                t.Applied = false;

                h.UpdateStatsWithModifiers();

                Debug.Log("Removing the modifiers for the " + t.Name + " trait from hunter" + h.Name + "\n");
                Debug.Log("Current Stats: " + "\n" +
                    "Agility = " + h.Agility + "\n" +
                    "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                    "CurrentHealth = " + h.CurrentHealth + "\n" +
                    "DamageReduction = " + h.CurrentHealth + "\n" +
                    "Experience = " + h.Experience + "\n" +
                    "Inteligence = " + h.Inteligence + "\n" +
                    "MaxHealth = " + h.MaxHealth + "\n" +
                    "MeleeDamage = " + h.MaxHealth + "\n" +
                    "RangedDamage = " + h.RangedDamage + "\n" +
                    "Reactivity = " + h.Reactivity + "\n" +
                    "Sanity = " + h.Sanity + "\n" +
                    "Strength = " + h.Strength + "\n" +
                    "Tracking = " + h.Tracking + "\n");

                unitTraits.Remove(t);
            }
            else
            {
                Debug.LogError("This trait has never been applied to this hunter");
            }
        }


        void EquipItem(Item i, Hunter h)
        {

            unitItems.Add(i);
            Debug.Log("Applying the modifiers for the " + i.Name + " item to hunter" + h.Name + "\n");
            Debug.Log("Current Stats: " + "\n" +
                "Agility = " + h.Agility + "\n" +
                "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                "CurrentHealth = " + h.CurrentHealth + "\n" +
                "DamageReduction = " + h.CurrentHealth + "\n" +
                "Experience = " + h.Experience + "\n" +
                "Inteligence = " + h.Inteligence + "\n" +
                "MaxHealth = " + h.MaxHealth + "\n" +
                "MeleeDamage = " + h.MaxHealth + "\n" +
                "RangedDamage = " + h.RangedDamage + "\n" +
                "Reactivity = " + h.Reactivity + "\n" +
                "Sanity = " + h.Sanity + "\n" +
                "Strength = " + h.Strength + "\n" +
                "Tracking = " + h.Tracking + "\n");

            if (i.Equipped == false)
            {
                h.ModifierAgility += i.ModifierAgility;
                h.ModifierArkaneNnowledge += i.ModifierArkaneNnowledge;
                h.ModifierCurrentHealth += i.ModifierCurrentHealth;
                h.ModifierDamageReduction += i.ModifierDamageReduction;
                h.ModifierExperience += i.ModifierExperience;
                h.ModifierInteligence += i.ModifierInteligence;
                h.ModifierMaxHealth += i.ModifierMaxHealth;
                h.ModifierMeleeDamage += i.ModifierMeleeDamage;
                h.ModifierRangedDamage += i.ModifierRangedDamage;
                h.ModifierReactivity += i.ModifierReactivity;
                h.ModifierSanity += i.ModifierSanity;
                h.ModifierStrength += i.ModifierStrength;
                h.ModifierTracking += i.ModifierTracking;

                i.Equipped = true;

                h.UpdateStatsWithModifiers();
                Debug.Log("Updated Stats: " + "\n" +
                    "Agility = " + h.Agility + "\n" +
                    "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                    "CurrentHealth = " + h.CurrentHealth + "\n" +
                    "DamageReduction = " + h.CurrentHealth + "\n" +
                    "Experience = " + h.Experience + "\n" +
                    "Inteligence = " + h.Inteligence + "\n" +
                    "MaxHealth = " + h.MaxHealth + "\n" +
                    "MeleeDamage = " + h.MaxHealth + "\n" +
                    "RangedDamage = " + h.RangedDamage + "\n" +
                    "Reactivity = " + h.Reactivity + "\n" +
                    "Sanity = " + h.Sanity + "\n" +
                    "Strength = " + h.Strength + "\n" +
                    "Tracking = " + h.Tracking + "\n");
            }
        }


        void RemoveItem(Item i, Hunter h)
        {
            if (i.Equipped == true && unitItems.Contains(i))
            {
                Debug.Log("Removing the modifiers for the " + i.Name + " item from hunter" + h.Name + "\n");
                Debug.Log("Current Stats: " + "\n" +
                    "Agility = " + h.Agility + "\n" +
                    "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                    "CurrentHealth = " + h.CurrentHealth + "\n" +
                    "DamageReduction = " + h.CurrentHealth + "\n" +
                    "Experience = " + h.Experience + "\n" +
                    "Inteligence = " + h.Inteligence + "\n" +
                    "MaxHealth = " + h.MaxHealth + "\n" +
                    "MeleeDamage = " + h.MaxHealth + "\n" +
                    "RangedDamage = " + h.RangedDamage + "\n" +
                    "Reactivity = " + h.Reactivity + "\n" +
                    "Sanity = " + h.Sanity + "\n" +
                    "Strength = " + h.Strength + "\n" +
                    "Tracking = " + h.Tracking + "\n");

                h.ModifierAgility -= i.ModifierAgility;
                h.ModifierArkaneNnowledge -= i.ModifierArkaneNnowledge;
                h.ModifierCurrentHealth -= i.ModifierCurrentHealth;
                h.ModifierDamageReduction -= i.ModifierDamageReduction;
                h.ModifierExperience -= i.ModifierExperience;
                h.ModifierInteligence -= i.ModifierInteligence;
                h.ModifierMaxHealth -= i.ModifierMaxHealth;
                h.ModifierMeleeDamage -= i.ModifierMeleeDamage;
                h.ModifierRangedDamage -= i.ModifierRangedDamage;
                h.ModifierReactivity -= i.ModifierReactivity;
                h.ModifierSanity -= i.ModifierSanity;
                h.ModifierStrength -= i.ModifierStrength;
                h.ModifierTracking -= i.ModifierTracking;

                i.Equipped = false;

                h.UpdateStatsWithModifiers();

                Debug.Log("Removing the modifiers for the " + i.Name + " itemm to hunter" + h.Name + "\n");
                Debug.Log("Current Stats: " + "\n" +
                    "Agility = " + h.Agility + "\n" +
                    "ArkaneKnowledge = " + h.ArkaneNnowledge + "\n" +
                    "CurrentHealth = " + h.CurrentHealth + "\n" +
                    "DamageReduction = " + h.CurrentHealth + "\n" +
                    "Experience = " + h.Experience + "\n" +
                    "Inteligence = " + h.Inteligence + "\n" +
                    "MaxHealth = " + h.MaxHealth + "\n" +
                    "MeleeDamage = " + h.MaxHealth + "\n" +
                    "RangedDamage = " + h.RangedDamage + "\n" +
                    "Reactivity = " + h.Reactivity + "\n" +
                    "Sanity = " + h.Sanity + "\n" +
                    "Strength = " + h.Strength + "\n" +
                    "Tracking = " + h.Tracking + "\n");

                unitItems.Remove(i);
            }
        }
    }
}







