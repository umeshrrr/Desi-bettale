using UnityEngine;

namespace DesiShadow.Data
{
    public enum WeaponRarity { Common, Rare, Epic, Legendary }

    [CreateAssetMenu(fileName = "NewWeapon", menuName = "DesiShadow/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [Header("Identity")]
        public string weaponID;
        public string displayName;
        
        [Header("Stats")]
        public float damage;
        public float fireRate;
        public int magazineSize;
        public float reloadTime;

        [Header("Visuals")]
        public WeaponRarity rarity;
        public GameObject weaponPrefab;
        public Sprite icon;
        public AudioClip fireSound;
    }
}
