using UnityEngine;
using System;

public class CloseShopPanel : MonoBehaviour
{
    public event Action CloseMenu;

    public void CloseShop()
    {
        CloseMenu.Invoke();
    }
}
