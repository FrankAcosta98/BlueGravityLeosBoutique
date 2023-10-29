using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ItemIcon : MonoBehaviour
{
    public TextMeshProUGUI iconName;
    public TextMeshProUGUI iconValue;
    public SelectedItem brain;
    public ShopItem item;
    // Start is called before the first frame update
    void Start()
    {
        switch (item.itemType)
        {
            case ShopItem.Type.body:
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).GetComponent<Image>().sprite = item.shopIcon;
                break;
            case ShopItem.Type.head:
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).GetComponent<Image>().sprite = item.shopIcon;
                break;
            case ShopItem.Type.pants:
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(2).GetComponent<Image>().sprite = item.shopIcon;
                break;
            case ShopItem.Type.shoes:
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(3).GetComponent<Image>().sprite = item.shopIcon;
                break;
            default:
                break;
        }
        iconValue.text = item.coinValue.ToString();
        iconName.text = item.itemName;
    }
    public void click(){
        brain.Select(item);
    }
}
