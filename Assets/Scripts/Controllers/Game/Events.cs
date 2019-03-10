using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public static event Action<MenuType> ShowMenu;
    public static void ShowMenu_Call(MenuType menuType) { ShowMenu?.Invoke(menuType); }

    public static event Action<float> Swipe;
    public static void Swipe_Call(float swipeDistance) { Swipe?.Invoke(swipeDistance); }

    public static event Action LevelStarted;
    public static void LevelStarted_Call() { LevelStarted?.Invoke(); }
}
