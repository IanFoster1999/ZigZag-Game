using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
        Debug.Log(Helper.Serialize<SaveState>(state));
    }

    //Save the state of this saveState script to the player pref
    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    //Load the previous saved state from the player prefs
    public void Load()
    {
        //Do we already have a save?
        if(PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
        }
    }

    //Check if skin is owned
    public bool IsSkinOwned(int index)
    {
        return (state.skinOwned & (1 << index)) != 0;
    }

    //Attemp buying a skin
    public bool BuySkin(int index, int cost)
    {
        if(state.coins >= cost)
        {
            state.coins -= cost;
            UnlockSkin(index);
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }

    //Unlock a skin in the "skinOwned" int
    public void UnlockSkin(int index)
    {
        state.skinOwned |= 1 << index;
    }

    //Reset the save
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}
