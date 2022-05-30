using Player;
using UnityEngine;

public class StatsDebugger : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        print(playerStats.GetStat(Stat.PlayerArmor));
        print(playerStats.GetStat((Stat.PlayerSpeed)));
        print(playerStats.GetStat((Stat.PlayerReloadSpeed)));
        print(playerStats.GetStat((Stat.PlayerDamage)));
    }
}
