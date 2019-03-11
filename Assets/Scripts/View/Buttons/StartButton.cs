using UnityEngine;
using System.Collections;

public class StartButton : ShowMenuButton
{
    public override void ShowMenu()
    {
        Events.LevelStarted_Call();
        base.ShowMenu();
    }
}
