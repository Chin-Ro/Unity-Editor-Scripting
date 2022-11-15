using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "New Mage Data", menuName = "Character Data/Mage")]
public class MageData : CharacterData
{
    public MageDamageType mageDamageType;
    public MageWeaponType mageWeaponType;
}
