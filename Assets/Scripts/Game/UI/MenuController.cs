
public class MenuController : IMenuController
{
    private ShopPanel _shopPanel;
    private OpenShopPanel _openShopPanel;
    private ShowMeshBtn _showMeshBtn;
    private CloseShopPanel _closeShopPanel;

    public MenuController(ShopPanel shopPanel, OpenShopPanel openShopPanel,
        ShowMeshBtn showMeshBtn, CloseShopPanel closeShopPanel)
    {
        _shopPanel = shopPanel;
        _openShopPanel = openShopPanel;
        _showMeshBtn = showMeshBtn;
        _closeShopPanel = closeShopPanel;
        _openShopPanel.OpenMenu += OpenMenu;
        _closeShopPanel.CloseMenu += CloseMenu;
    }

    public void OpenMenu()
    {
        _openShopPanel.gameObject.SetActive(false);
        _showMeshBtn.gameObject.SetActive(false);

        _shopPanel.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        _shopPanel.gameObject.SetActive(false);

        _openShopPanel.gameObject.SetActive(true);
        _showMeshBtn.gameObject.SetActive(true);
    }
}
