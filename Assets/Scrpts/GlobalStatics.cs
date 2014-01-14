using UnityEngine;
using System.Collections;

public class GlobalStatics : MonoBehaviour {
	//Ints
	public const int bulletSpeed = 20;
	public static int currentChar = 0;

	//Strings
	public const string bulletTag = "Bullet";
	public const string playerTag = "Player";
	public const string fanTag = "Tag";
	public const string dirtTag = "Dirt";
	public const string diggingTag = "Digging";

	//Character select
	public enum Characters {
		enemyFast,
		enemyStronk
	}

	public static Characters chars = Characters.enemyFast;
}