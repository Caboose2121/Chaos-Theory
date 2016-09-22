using UnityEngine;
using System.Collections;

public class Enums : MonoBehaviour
{
	public enum enumVars { Menu, Play, Pause, Options, Save, Load, Text, Cutscene, Dead, Loader, Credits };
	public static enumVars currEnum;
	public static enumVars preEnum;
}