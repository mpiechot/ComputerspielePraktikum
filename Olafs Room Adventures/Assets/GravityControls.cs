// GENERATED AUTOMATICALLY FROM 'Assets/GravityControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GravityControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GravityControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GravityControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""827100b7-1795-44f5-b01d-b2206e3240ad"",
            ""actions"": [
                {
                    ""name"": ""Red"",
                    ""type"": ""Button"",
                    ""id"": ""7172be5f-6d31-4b84-9955-ad08fa150139"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Green"",
                    ""type"": ""Button"",
                    ""id"": ""7396a5a8-a8d3-4d84-b28d-3760c0398af3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Blue"",
                    ""type"": ""Button"",
                    ""id"": ""b4b5ad69-e8cf-4a4a-aae4-6fc7fa9022a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yellow"",
                    ""type"": ""Button"",
                    ""id"": ""d9147b00-41dd-4cbc-b256-0e6a314602b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turquoise"",
                    ""type"": ""Button"",
                    ""id"": ""92908a56-8970-4a28-8357-ff8774ecff36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pink"",
                    ""type"": ""Button"",
                    ""id"": ""7d2adfdc-c21f-4c51-ab2d-7834cd3f1475"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f4b04845-d54f-4518-949a-5a6c8090af12"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c903da4-2c8e-45f9-babb-2f82dfb5fb0b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turquoise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fd460c0-d406-4c97-b1e0-67acb6a00982"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pink"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a7bc836-d2f6-47fd-ab57-711b8b3ae48e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Green"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6a4d294-79c6-4955-9bc9-ea76f71fd968"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25a6b649-c6d4-4344-9173-c190d97ad46a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yellow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Red = m_Player.FindAction("Red", throwIfNotFound: true);
        m_Player_Green = m_Player.FindAction("Green", throwIfNotFound: true);
        m_Player_Blue = m_Player.FindAction("Blue", throwIfNotFound: true);
        m_Player_Yellow = m_Player.FindAction("Yellow", throwIfNotFound: true);
        m_Player_Turquoise = m_Player.FindAction("Turquoise", throwIfNotFound: true);
        m_Player_Pink = m_Player.FindAction("Pink", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Red;
    private readonly InputAction m_Player_Green;
    private readonly InputAction m_Player_Blue;
    private readonly InputAction m_Player_Yellow;
    private readonly InputAction m_Player_Turquoise;
    private readonly InputAction m_Player_Pink;
    public struct PlayerActions
    {
        private @GravityControls m_Wrapper;
        public PlayerActions(@GravityControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Red => m_Wrapper.m_Player_Red;
        public InputAction @Green => m_Wrapper.m_Player_Green;
        public InputAction @Blue => m_Wrapper.m_Player_Blue;
        public InputAction @Yellow => m_Wrapper.m_Player_Yellow;
        public InputAction @Turquoise => m_Wrapper.m_Player_Turquoise;
        public InputAction @Pink => m_Wrapper.m_Player_Pink;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Red.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRed;
                @Red.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRed;
                @Red.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRed;
                @Green.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGreen;
                @Green.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGreen;
                @Green.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGreen;
                @Blue.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlue;
                @Blue.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlue;
                @Blue.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlue;
                @Yellow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYellow;
                @Yellow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYellow;
                @Yellow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYellow;
                @Turquoise.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurquoise;
                @Turquoise.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurquoise;
                @Turquoise.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurquoise;
                @Pink.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPink;
                @Pink.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPink;
                @Pink.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPink;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Red.started += instance.OnRed;
                @Red.performed += instance.OnRed;
                @Red.canceled += instance.OnRed;
                @Green.started += instance.OnGreen;
                @Green.performed += instance.OnGreen;
                @Green.canceled += instance.OnGreen;
                @Blue.started += instance.OnBlue;
                @Blue.performed += instance.OnBlue;
                @Blue.canceled += instance.OnBlue;
                @Yellow.started += instance.OnYellow;
                @Yellow.performed += instance.OnYellow;
                @Yellow.canceled += instance.OnYellow;
                @Turquoise.started += instance.OnTurquoise;
                @Turquoise.performed += instance.OnTurquoise;
                @Turquoise.canceled += instance.OnTurquoise;
                @Pink.started += instance.OnPink;
                @Pink.performed += instance.OnPink;
                @Pink.canceled += instance.OnPink;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnRed(InputAction.CallbackContext context);
        void OnGreen(InputAction.CallbackContext context);
        void OnBlue(InputAction.CallbackContext context);
        void OnYellow(InputAction.CallbackContext context);
        void OnTurquoise(InputAction.CallbackContext context);
        void OnPink(InputAction.CallbackContext context);
    }
}
