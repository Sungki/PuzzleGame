public class SceneFactory
{
    public static SceneObject Create(SceneState _scene)
    {
        SceneObject scene = null;
        switch (_scene)
        {
            case SceneState.StartScreen:
                scene = new StartScreen();
                break;
            case SceneState.Level1:
                scene = new Level1();
                break;
            case SceneState.Level2:
                scene = new Level2();
                break;
            case SceneState.Level3:
                scene = new Level3();
                break;
            case SceneState.Level4:
                scene = new Level4();
                break;
            case SceneState.SummaryScreen:
                scene = new SummaryScreen();
                break;
            default:
                return null;
        }
        return scene;
    }
}
