using UnityEngine;
using System;

public class OpenShopPanel : MonoBehaviour
{
    public event Action OpenMenu;

    public void ShowShop()
    {
        OpenMenu.Invoke();
    }
}
