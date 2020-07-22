using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string physicsSceneName;
    public float physicsSceneTimeScale = 1;
    private PhysicsScene physicsScene;

    private void Start()
    {
        LoadSceneParameters param = new LoadSceneParameters(LoadSceneMode.Additive,
            LocalPhysicsMode.Physics2D);
        Scene scene = SceneManager.LoadScene(physicsSceneName, param);

        physicsScene = scene.GetPhysicsScene();
    }

    private void FixedUpdate()
    {
        if (physicsScene != null)
        {
            physicsScene.Simulate(Time.fixedDeltaTime *
                physicsSceneTimeScale);
        }
    }
}
