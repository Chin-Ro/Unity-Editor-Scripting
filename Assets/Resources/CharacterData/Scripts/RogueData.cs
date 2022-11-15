using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "New Rouge Data", menuName = "Character Data/Rouge")]
public class RogueData : CharacterData
{
    public RogueStrategyType rogueStrategyType;
    public RogueWeaponType rogueWeaponType;
}
