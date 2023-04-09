using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamInfo
{
    public eTeamColor teamColor;
    public int flagsCollected = 0;
    public int resourceCount = 0;
    public List<Player> players = new List<Player>();
}
