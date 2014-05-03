using UnityEngine;
using System.Collections;

public enum GameState {
	STARTMENU,
	LEVELONE
}

public class StateHandler : MonoBehaviour {

	public static StateHandler current;

	public const string START_MENU = "StartMenu";
	public const string LEVEL_ONE = "Level01";

	static GameState _state;
	public static GameState state {
		get {
			return _state;
		}
		set {
			switch(value) {
				case GameState.STARTMENU:
					//if(Application.loadedLevelName != START_MENU)
						Application.LoadLevel(START_MENU);
					break;
				case GameState.LEVELONE:
					//if(Application.loadedLevelName != LEVEL_ONE)
						Application.LoadLevel(LEVEL_ONE);
					break;
			}
		}
	}

	void Awake () {
		DontDestroyOnLoad(gameObject);

		current = this;

		// Start menu
		state = GameState.STARTMENU;
	}
}