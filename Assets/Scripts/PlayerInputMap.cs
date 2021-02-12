// GENERATED AUTOMATICALLY FROM 'Assets/InputMaps/PlayerInputMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""012d7c8d-c778-4c6c-9c24-bd19011db8fb"",
            ""actions"": [
                {
                    ""name"": ""MoveHorizontally"",
                    ""type"": ""Button"",
                    ""id"": ""b875c54e-85fe-45e3-a571-c2df7e3835d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""SlowTap(duration=0.01,pressPoint=0.5)""
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""84b6415c-b67a-43bd-b456-220349198fd8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BoostFalling"",
                    ""type"": ""Button"",
                    ""id"": ""4ddf5900-f7e8-4ca4-8aa8-f821558b5add"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""SlowTap(duration=0.01,pressPoint=0.01)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""6072c810-2315-4e2e-9b8a-20506283954a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontally"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""86798d02-fc3e-45f2-a069-b6808bb6aee1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""MoveHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""080fe1e4-7441-472e-86ec-75d1ad9f8b38"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""MoveHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8e372ac2-2c78-4690-a30c-9b8bdc8e493c"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd551d8e-3d10-458b-a11a-a8da02c453ba"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BoostFalling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard"",
            ""bindingGroup"": ""KeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveHorizontally = m_Player.FindAction("MoveHorizontally", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_BoostFalling = m_Player.FindAction("BoostFalling", throwIfNotFound: true);
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
    private readonly InputAction m_Player_MoveHorizontally;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_BoostFalling;
    public struct PlayerActions
    {
        private @PlayerInputMap m_Wrapper;
        public PlayerActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveHorizontally => m_Wrapper.m_Player_MoveHorizontally;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @BoostFalling => m_Wrapper.m_Player_BoostFalling;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveHorizontally.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveHorizontally;
                @MoveHorizontally.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveHorizontally;
                @MoveHorizontally.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveHorizontally;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @BoostFalling.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostFalling;
                @BoostFalling.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostFalling;
                @BoostFalling.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBoostFalling;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveHorizontally.started += instance.OnMoveHorizontally;
                @MoveHorizontally.performed += instance.OnMoveHorizontally;
                @MoveHorizontally.canceled += instance.OnMoveHorizontally;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @BoostFalling.started += instance.OnBoostFalling;
                @BoostFalling.performed += instance.OnBoostFalling;
                @BoostFalling.canceled += instance.OnBoostFalling;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyBoardSchemeIndex = -1;
    public InputControlScheme KeyBoardScheme
    {
        get
        {
            if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
            return asset.controlSchemes[m_KeyBoardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveHorizontally(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnBoostFalling(InputAction.CallbackContext context);
    }
}
