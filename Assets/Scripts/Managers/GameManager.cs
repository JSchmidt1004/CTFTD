using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => instance; }

    static GameManager instance;

    public List<TeamInfo> teams = new List<TeamInfo>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AddPlayersToTeams();
    }

    void AddPlayersToTeams()
    {
        Player[] players = FindObjectsOfType<Player>();

        foreach (Player player in players)
        {
            if (teams.Any(team => team.teamColor == player.teamColor))
            {
                //If matching team already exists, add player to team
                TeamInfo teamInfo = teams.Where(team => team.teamColor == player.teamColor).FirstOrDefault();
                teamInfo.players.Add(player);
            }
            else
            {
                //Else create new team with player and add to team list
                TeamInfo teamInfo = new TeamInfo();
                teamInfo.teamColor = player.teamColor;
                teamInfo.players.Add(player);

                teams.Add(teamInfo);
            }
        }
    }

}
