using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Game/Spell")]
public class Spell : ScriptableObject
{
	[Tooltip("Стихия, к которой относится заклинание")]
	public Element spellElement;
	public string spellName;
	[Tooltip("Уровень, на котором данное заклинание становится доступно")]
	public int openOnLevel;
	[Tooltip("Время Перезарядки заклинани в секундах")]
	public float cooldownTime;
}