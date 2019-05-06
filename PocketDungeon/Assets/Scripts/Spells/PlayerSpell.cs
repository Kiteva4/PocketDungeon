using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpell : MonoBehaviour
{
	[SerializeField]
	protected Spell spell;
	public UnityEvent CastSpell;
}
