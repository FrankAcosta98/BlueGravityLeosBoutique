using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName="ShopItem",menuName="Item/Create Shop Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public int coinValue;
    public Sprite shopIcon;
    public SpriteLibraryAsset AssetLib;
    public Type itemType;
    public bool bought;
    public enum Type{
        body,
        head,
        pants,
        shoes,
    }
}
