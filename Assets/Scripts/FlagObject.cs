using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagObject : MonoBehaviour
{
    [SerializeField]
    private eTeamColor teamColor;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private bool pickupAvailable;

    private bool isCastle;

    void Start()
    {
        isCastle = gameObject.TryGetComponent<Castle>(out Castle castle);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickupAvailable)
        {
            //Display pickup to player in range
            if (collision.gameObject.TryGetComponent<Player>(out Player nearbyPlayer))
            {
                if (nearbyPlayer.teamColor != teamColor && !nearbyPlayer.hasFlag)
                {
                    UIManager.Instance.SetActionItem("Steal Loot (E)");
                    nearbyPlayer.flagObject = this;
                }
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
                UIManager.Instance.SetActionItem("");
                nearbyPlayer.flagObject = null;
            }
        }
    }

    public Sprite Pickup()
    {
        if (pickupAvailable)
        {
            if (!isCastle) gameObject.SetActive(false);

            UIManager.Instance.SetActionItem("Drop Loot (E)");
            return sprite;
        }

        return null;
    }
}
