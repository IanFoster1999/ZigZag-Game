using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour {

    public Transform skinPanel;

    public Text skinBuySetText;
    public Text coinText;

    private int[] skinCost = new int[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45 };
    private int selectedSkinIndex;
    private int activeSkinIndex;

    private void Start()
    {
        //Display coins
        UpdateCoinText();

        //Add button on-click events to buttons
        InitializeShop();

        //Set the player preferences
        OnSkinSelect(SaveManager.Instance.state.activeSkin);
        SetSkin(SaveManager.Instance.state.activeSkin);

        //Mack button bigger for selected item
        skinPanel.GetChild(SaveManager.Instance.state.activeSkin).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;
    }

    private void InitializeShop()
    {
        if (skinPanel == null)
            return;

        //Add on-click to all the children under skin panel
        int i = 0;
        foreach (Transform t in skinPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnSkinSelect(currentIndex));

            //Set the color of the image based if owned or not
            Image img = t.GetComponent<Image>();
            img.color = SaveManager.Instance.IsSkinOwned(i) ? Color.white : new Color(0.7f, 0.7f, 0.7f);

            i++;
        }
    }

    private void SetSkin(int index)
    {
        //Set the active index
        activeSkinIndex = index;
        SaveManager.Instance.state.activeSkin = index;

        //Change he skin in the player model

        //Change buy/set button text
        skinBuySetText.text = "Current";

        //Save preferences
        SaveManager.Instance.Save();
    }

    private void UpdateCoinText()
    {
        coinText.text = SaveManager.Instance.state.coins.ToString();
    }

    //Buttons
    private void OnSkinSelect(int currentIndex)
    {
        Debug.Log("Selecting skin button : " + currentIndex);

        if (selectedSkinIndex == currentIndex)
            return;

        //make button bigger
        skinPanel.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;
        //Put previous one back to normal scale
        skinPanel.GetChild(selectedSkinIndex).GetComponent<RectTransform>().localScale = Vector3.one;

        //Set the selected skin
        selectedSkinIndex = currentIndex;

        //Change the content of buy/set button
        if(SaveManager.Instance.IsSkinOwned(currentIndex))
        {
            //skin is owned
            if(activeSkinIndex == currentIndex)
                skinBuySetText.text = "Current";
            else
                skinBuySetText.text = "Select";
        }
        else
        {
            //skin is not owned
            skinBuySetText.text = "Buy: " + skinCost[currentIndex].ToString();
        }
    }

    public void OnSkinBuySet()
    {
        Debug.Log("Buy/Set skin");

        if(SaveManager.Instance.IsSkinOwned(selectedSkinIndex))
        {
            SetSkin(selectedSkinIndex);
        }
        else
        {
            //Attemp to buy skin
            if(SaveManager.Instance.BuySkin(selectedSkinIndex, skinCost[selectedSkinIndex]))
            {
                SetSkin(selectedSkinIndex);

                skinPanel.GetChild(selectedSkinIndex).GetComponent<Image>().color = Color.white;

                UpdateCoinText();
            }
            else
            {
                Debug.Log("Not enough coins");
            }
        }
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnCoinCheatClick()
    {
        SaveManager.Instance.state.coins += 10;
        UpdateCoinText();
    }
}
