using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioPlay : MonoBehaviour
{
    public void PlayAttack()
    {
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.Attack);
    }

    public void PlayWalk()
    {
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.Walk);
    }

    public void PlayGround()
    {
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.Ground);
    }

    public void PlaySlide()
    {
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.Slide);
    }

    public void PlayJump()
    {
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.Jump);
    }

    public void PlayDefence()
    {
        AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.Defence);
    }
}
