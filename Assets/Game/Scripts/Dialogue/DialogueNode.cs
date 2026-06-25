using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Game.Scripts.Dialogue
{
    public class DialogueNode: ScriptableObject
    {
        [SerializeField] bool isPlayerSpeaking = false;
        [SerializeField] string text;
        [SerializeField] AudioSource audioSource;
        [SerializeField] Animation animation;
        [SerializeField] List<string> children = new List<string>();
        [SerializeField] Rect rect = new Rect(0, 0, DialogueConstants.DefaultNodeWidth, DialogueConstants.DefaultNodeHeight);
        [SerializeField] string onEnterAction;
        [SerializeField] string onExitAction;

        public Rect GetRect() => rect;
        public string GetText() => text;
        public AudioSource GetAudioSource() => audioSource;
        public Animation GetAnimation() => animation;
        public List<string> GetChildren() => children;
        public bool IsPlayerSpeaking() => isPlayerSpeaking;
        public string GetOnEnterAction() => onEnterAction;
        public string GetOnExitAction() => onExitAction;


#if UNITY_EDITOR
        public void SetPosition(Vector2 newPosition)
        {
            Undo.RecordObject(this, "Move dialoge node.");
            rect.position = newPosition;
            EditorUtility.SetDirty(this);
        }

        public void SetText(string newText)
        {
            if(newText != text)
            {
                Undo.RecordObject(this, "Update dialogue text.");
                text = newText;
                EditorUtility.SetDirty(this);
            }
        }

        public void SetAudioSource(AudioSource newAudioSource)
        {
            if(newAudioSource != audioSource)
            {
                Undo.RecordObject(this, "Update dialogue audio.");
                audioSource = newAudioSource;
                EditorUtility.SetDirty(this);
            }
        }

        public void SetAnimation(Animation newAnimation)
        {
            if (newAnimation != animation)
            {
                Undo.RecordObject(this, "Update dialogue animation.");
                animation = newAnimation;
                EditorUtility.SetDirty(this);
            }
        }

        public void RemoveChild(string childId)
        {
            Undo.RecordObject(this, "Remove dialogue link.");
            children.Remove(childId);
            EditorUtility.SetDirty(this);
        }

        public void AddChild(string childId)
        {
            Undo.RecordObject(this, "Add dialogue link.");
            children.Add(childId);
            EditorUtility.SetDirty(this);
        }

        public void SetPlayerSpeaking(bool newIsPlayerSpeaking)
        {
            Undo.RecordObject(this, "Change speaker.");
            isPlayerSpeaking = newIsPlayerSpeaking;
            EditorUtility.SetDirty(this);
        }

#endif
    }
}