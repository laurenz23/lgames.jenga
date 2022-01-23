// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""ScreenInput"",
            ""id"": ""7693d093-3f04-4560-8cfb-06ad4a4b0b19"",
            ""actions"": [
                {
                    ""name"": ""MouseLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""a2b99d62-0a04-4e1c-a1e0-ba07f19609a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""db81dcad-6eea-436e-bde7-235643ecfb9a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0a9247b3-88aa-45ba-9cd3-638b4eaee781"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cad3c5c5-e93d-4b29-aec9-bfa5fc6eff9c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ScreenInput
        m_ScreenInput = asset.FindActionMap("ScreenInput", throwIfNotFound: true);
        m_ScreenInput_MouseLeftClick = m_ScreenInput.FindAction("MouseLeftClick", throwIfNotFound: true);
        m_ScreenInput_MousePosition = m_ScreenInput.FindAction("MousePosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ScreenInput
    private readonly InputActionMap m_ScreenInput;
    private IScreenInputActions m_ScreenInputActionsCallbackInterface;
    private readonly InputAction m_ScreenInput_MouseLeftClick;
    private readonly InputAction m_ScreenInput_MousePosition;
    public struct ScreenInputActions
    {
        private @InputMap m_Wrapper;
        public ScreenInputActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLeftClick => m_Wrapper.m_ScreenInput_MouseLeftClick;
        public InputAction @MousePosition => m_Wrapper.m_ScreenInput_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_ScreenInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ScreenInputActions set) { return set.Get(); }
        public void SetCallbacks(IScreenInputActions instance)
        {
            if (m_Wrapper.m_ScreenInputActionsCallbackInterface != null)
            {
                @MouseLeftClick.started -= m_Wrapper.m_ScreenInputActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.performed -= m_Wrapper.m_ScreenInputActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.canceled -= m_Wrapper.m_ScreenInputActionsCallbackInterface.OnMouseLeftClick;
                @MousePosition.started -= m_Wrapper.m_ScreenInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ScreenInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ScreenInputActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_ScreenInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLeftClick.started += instance.OnMouseLeftClick;
                @MouseLeftClick.performed += instance.OnMouseLeftClick;
                @MouseLeftClick.canceled += instance.OnMouseLeftClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public ScreenInputActions @ScreenInput => new ScreenInputActions(this);
    public interface IScreenInputActions
    {
        void OnMouseLeftClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
