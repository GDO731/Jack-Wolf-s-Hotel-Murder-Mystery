using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;

namespace Assets.Game.Scripts.Core
{
    public class InputReader : MonoBehaviour, Controls.IPlayerActions
    {
        Controls controls;

        public event Action JumpEvent;
        public event Action CrouchEvent;
        public event Action InteractEvent;
        public event Action InventoryEvent;

        public Vector2 MoveValue { get; private set; }
        public Vector2 LookValue { get; private set; }
        public bool IsSprinting { get; private set; }
        public bool JumpInput { get; set; }

        void OnEnable()
        {
            if (controls == null)
            {
                controls = new Controls();
                controls.Player.SetCallbacks(this);
            }
            controls.Player.Enable();
        }

        void OnDisable() => controls.Player.Disable();

        public void OnMove(InputAction.CallbackContext ctx) => MoveValue = ctx.ReadValue<Vector2>();
        public void OnLook(InputAction.CallbackContext ctx) => LookValue = ctx.ReadValue<Vector2>();
        public void OnSprint(InputAction.CallbackContext ctx) => IsSprinting = ctx.ReadValueAsButton();

        public void OnJump(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                JumpInput = true;
                JumpEvent?.Invoke();
            }
        }

        public void OnCrouch(InputAction.CallbackContext ctx)
        {
            if (ctx.performed) CrouchEvent?.Invoke();
        }

        public void OnInteract(InputAction.CallbackContext ctx)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (ctx.performed) InteractEvent?.Invoke();
        }

        public void OnInventory(InputAction.CallbackContext ctx)
        {
            if (ctx.performed) InventoryEvent?.Invoke();
        }
    }
}