using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAdudio : MonoBehaviour
{
    [SerializeField] Slider MBG_sl, SFX_sl;
    [SerializeField] GameObject paren;


    private void Awake()
    {
        MBG_sl.value = AudioManager.instance.MBG_temp.volume;
        SFX_sl.value = AudioManager.instance.SFX_temp.volume;
    }
    public void ControlMBG()
    {
        AudioManager.instance.MBG_temp.volume = MBG_sl.value;
    }
    public void ControlSFX()
    {
        AudioManager.instance.SFX_temp.volume = SFX_sl.value;
    }
    public void close()
    {
        paren.SetActive(false);
    }
}
