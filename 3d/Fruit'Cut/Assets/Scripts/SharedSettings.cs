using UnityEngine;
using System.Collections;

public class SharedSettings : MonoBehaviour {

    // 计时时间
    public static int ConfigTime = 60;// sec

    // 游戏难度
    public static int LoadLevel = 2;

    // 游戏难度名字
    public static string[] levelNames = new string[] { "EASY", "NIRMAL", "HARD", "EXTREME" };
}
