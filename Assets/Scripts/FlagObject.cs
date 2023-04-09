using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagObject : MonoBehaviour
{
    public eTeamColor teamColor;
    public Sprite sprite;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Display pickup to player in range
        if (collision.gameObject.TryGetComponent<Player>(out Player nearbyPlayer))
        {
            if (nearbyPlayer.teamColor != teamColor && !nearbyPlayer.hasFlag)
            {
                UIManager.Instance.SetActionText("Steal Loot (E)");
                nearbyPlayer.flagObject = this;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Reset text to empty
        if (collision.gameObject.TryGetComponent<Player>(out Player nearbyPlayer))
        {
            if (nearbyPlayer.teamColor != teamColor && !nearbyPlayer.hasFlag)
            {
                UIManager.Instance.SetActionText("");
                nearbyPlayer.flagObject = null;
            }
        }
    }
}
