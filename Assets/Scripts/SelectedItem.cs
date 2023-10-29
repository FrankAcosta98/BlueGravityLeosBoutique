using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class SelectedItem : MonoBehaviour
{
    public GameObject guiPlayer;
    public TextMeshProUGUI itemName;
    public ShopItem selectedItem;
    public Button equipButton;
    public Button buyButton;

    void OnEnable()
    {
        guiPlayer.SetActive(true);
        guiPlayer.transform.GetChild(1).GetComponent<SpriteLibrary>().spriteLibraryAsset = PlayerStyleConfigSingle.instance.GetBody();
        guiPlayer.transform.GetChild(2).GetComponent<SpriteLibrary>().spriteLibraryAsset = PlayerStyleConfigSingle.instance.GetHead();
        guiPlayer.transform.GetChild(3).GetComponent<SpriteLibrary>().spriteLibraryAsset = PlayerStyleConfigSingle.instance.GetPants();
        guiPlayer.transform.GetChild(4).GetComponent<SpriteLibrary>().spriteLibraryAsset = PlayerStyleConfigSingle.instance.GetShoes();
        buyButton.interactable = false;
        equipButton.interactable = false;
    }
    public void Select(ShopItem item)
    {
        selectedItem = item;
        itemName.text = item.itemName;
        if (selectedItem.bought)
        {
            buyButton.interactable = false;
            equipButton.interactable = true;
        }
        else
        {
            buyButton.interactable = true;
            equipButton.interactable = false;
        }
        switch (item.itemType)
        {
            case ShopItem.Type.body:
                guiPlayer.transform.GetChild(1).GetComponent<SpriteLibrary>().spriteLibraryAsset = selectedItem.AssetLib;
                break;
            case ShopItem.Type.head:
                guiPlayer.transform.GetChild(2).GetComponent<SpriteLibrary>().spriteLibraryAsset = selectedItem.AssetLib;
                break;
            case ShopItem.Type.pants:
                guiPlayer.transform.GetChild(3).GetComponent<SpriteLibrary>().spriteLibraryAsset = selectedItem.AssetLib;
                break;
            case ShopItem.Type.shoes:
                guiPlayer.transform.GetChild(4).GetComponent<SpriteLibrary>().spriteLibraryAsset = selectedItem.AssetLib;
                break;
            default:
                break;
        }
    }
    public void Equip()
    {
        switch (selectedItem.itemType)
        {
            case ShopItem.Type.body:
                PlayerStyleConfigSingle.instance.SetBody(selectedItem.AssetLib);
                break;
            case ShopItem.Type.head:
                PlayerStyleConfigSingle.instance.SetHead(selectedItem.AssetLib);
                break;
            case ShopItem.Type.pants:
                PlayerStyleConfigSingle.instance.SetPants(selectedItem.AssetLib);
                break;
            case ShopItem.Type.shoes:
                PlayerStyleConfigSingle.instance.SetShoes(selectedItem.AssetLib);
                break;
            default:
                break;
        }

    }
    public void buy()
    {
        if (!selectedItem.bought && selectedItem.coinValue <= PlayerPrefs.GetInt("money"))
        {
            buyButton.interactable = false;
            selectedItem.bought = true;
            equipButton.interactable = true;
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - selectedItem.coinValue);
            PlayerStyleConfigSingle.instance.gui.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("money").ToString();
        }
    }
}
