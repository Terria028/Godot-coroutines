using Godot;
using System.Collections;

public class Player : KinematicBody2D
{
    private Sprite sprite;
    private CoroutineHandler handler = new CoroutineHandler();
    public bool isDone;

    public override void _Ready()
    {
        sprite = GetNode<Sprite>("PlayerSprite");   
        AddChild(handler);
        handler.StartCoroutines(FreeSpriteCoroutines());
        handler.StartCoroutines(FloatTest());
    }

    private IEnumerator FloatTest()
    {
        yield return 5.5f;
        GD.Print("Works as usual!");
    }

    private IEnumerator FreeSpriteCoroutines() 
    {
        yield return new WaitForSeconds(10f);
        isDone = true;
        yield break;
    }
}
