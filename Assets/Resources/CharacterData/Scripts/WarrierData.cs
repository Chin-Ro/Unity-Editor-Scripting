using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "New Warrior Data", menuName = "Character Data/Warrior")]
public class WarrierData : CharacterData
{
    public WarriorClassType warriorClassType;
    public WarriorWeaponType warriorWeaponType;
}
