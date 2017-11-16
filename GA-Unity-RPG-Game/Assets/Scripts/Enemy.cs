using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharactarStats))]
public class Enemy : Interactable {

    PlayerManager playerManager;
    CharactarStats myStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharactarStats>();
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }

    }

}