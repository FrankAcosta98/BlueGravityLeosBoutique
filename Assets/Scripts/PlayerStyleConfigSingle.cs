using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.Experimental.Animations;
using UnityEngine.UI;
using TMPro;
public class PlayerStyleConfigSingle : MonoBehaviour
{
    public static PlayerStyleConfigSingle instance;
    private GameObject player;
    public GameObject gui;
    public Color playerSkin;
    public SpriteLibraryAsset asset;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        gui = GameObject.FindGameObjectWithTag("Gui");
        PlayerPrefs.SetInt("money", 500);
        gui.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("money").ToString();

    }
    public void SetSkinColor(Color skintone)
    {
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = skintone;
    }
    public void SetBody(SpriteLibraryAsset body)
    {
        player.transform.GetChild(1).GetComponent<SpriteLibrary>().spriteLibraryAsset = body;
    }
    public void SetHead(SpriteLibraryAsset head)
    {
        player.transform.GetChild(2).GetComponent<SpriteLibrary>().spriteLibraryAsset = head;
    }
    public void SetPants(SpriteLibraryAsset head)
    {
        player.transform.GetChild(3).GetComponent<SpriteLibrary>().spriteLibraryAsset = head;
    }
    public void SetShoes(SpriteLibraryAsset head)
    {
        player.transform.GetChild(4).GetComponent<SpriteLibrary>().spriteLibraryAsset = head;
    }
    public Color GetSkinColor()
    {
        return player.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
    }
    public SpriteLibraryAsset GetBody()
    {
        return player.transform.GetChild(1).GetComponent<SpriteLibrary>().spriteLibraryAsset;
    }
    public SpriteLibraryAsset GetHead()
    {
        return player.transform.GetChild(2).GetComponent<SpriteLibrary>().spriteLibraryAsset;
    }
    public SpriteLibraryAsset GetPants()
    {
        return player.transform.GetChild(3).GetComponent<SpriteLibrary>().spriteLibraryAsset;
    }
    public SpriteLibraryAsset GetShoes()
    {
        return player.transform.GetChild(4).GetComponent<SpriteLibrary>().spriteLibraryAsset;
    }
}
