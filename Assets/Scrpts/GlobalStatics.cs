using UnityEngine;
using System.Collections;

public class GlobalStatics : MonoBehaviour {
	//Ints
	public const int bulletSpeed = 20;

	//Strings
	public const string bulletTag = "Bullet";
	public const string playerTag = "Player";

	public static int currentChar = 0;

	//Character select
	public enum Characters {
		enemyFast,
		enemyStronk
	}

	public static Characters chars = Characters.enemyFast;
}