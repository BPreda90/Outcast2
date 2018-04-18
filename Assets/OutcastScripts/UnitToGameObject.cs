using System.Collections.Generic;
using UnityEngine;


namespace Assets.OutcastScripts
{

    public class UnitToGameObject : MonoBehaviour
    {

        HashSet<Trait> unitTraits = new HashSet<Trait>();
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
                unitTraits.Remove(t);
            }
            else
            {
                Debug.LogError("This trait has never been applied to this hunter");
            }         
        }
        public void EquipItem()
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

            }
        }
}