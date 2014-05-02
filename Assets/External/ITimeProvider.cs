using System.Collections;

public interface ITimeProvider {
	float time { get; set; }
	float deltaTime { get; set; }

	void Update();
}