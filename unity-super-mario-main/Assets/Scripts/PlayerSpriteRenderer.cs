using System.Transactions;
//using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteRenderer : MonoBehaviour
{
    private PlayerMovement movement;
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public Sprite death;
    public AnimatedSprite run;

    private enum PlayerState { Idle, Jump, Slide, Run ,Death}
    private PlayerState currentState;
    private PlayerState previousState;

    private void LateUpdate()
    {
        previousState = currentState;

        if (movement.jumping)
        {
            currentState = PlayerState.Jump;
            spriteRenderer.sprite = jump;
        }
        else if (movement.sliding)
        {
            currentState = PlayerState.Slide;
            spriteRenderer.sprite = slide;
        }
        else if (movement.running)
        {
            currentState = PlayerState.Run;
            run.enabled = true;
        }
        else if (movement.dying==true  )
        {
            currentState = PlayerState.Death;
            spriteRenderer.sprite = death;
            NotifyAudioManager(currentState);

            return;

        }
        else
        {
            currentState = PlayerState.Idle;
            spriteRenderer.sprite = idle;
        }



        if (currentState != previousState )
        {
            NotifyAudioManager(currentState);
        }
    }
    private void NotifyAudioManager(PlayerState state)
    {
        var audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        switch (state)
        {
            case PlayerState.Jump:
                audioManager.PlaySFX(audioManager.jump);
                break;
            case PlayerState.Death:
                // Add slide SFX if needed
                audioManager.PlaySFX(audioManager.death);
                break;
            case PlayerState.Idle:
                // Optionally play idle transition SFX
                break;
                // case PlayerState.Run:
                // Optionally play run SFX
                // break;
        }
    }
    private void Awake()
    {
        movement = GetComponentInParent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   /* private void LateUpdate()
    {
        run.enabled = movement.running;

        if (movement.jumping) {
            spriteRenderer.sprite = jump;
        } else if (movement.sliding) {
            spriteRenderer.sprite = slide;
        } else if (!movement.running) {
            spriteRenderer.sprite = idle;
        }
    }
   */
    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        run.enabled = false;
    }

}
