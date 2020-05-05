// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerControlsActionMap"",
            ""id"": ""dd7655ce-f0e7-4ffa-adfc-1aa452dd6794"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""e595be8b-53f0-4ead-a299-25903b9482be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""5f0a0043-86c7-46d3-86ec-a074b81b0a5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""4fc662e0-0250-472c-86ac-6193050388b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""183dab77-bf34-4b6d-b015-7d91beeac73a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a4a052a2-0384-44c4-887c-099d9edd0427"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""af012f8a-b64f-4d27-b30d-6cdd2afd6900"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aafb8165-3f2e-4ae5-86b9-4edd8859be2b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""19218949-8a6e-4005-b643-b40278e95a8d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ba5ee5c6-b7fd-4678-8d11-92679c57b9c0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2796daa0-6200-4ec2-9827-722405dfa115"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3a6727dc-cf38-4859-80e8-a40a27e743f7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b061793c-befe-417c-95e4-bc50812fc969"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d8c8b42c-544c-4b60-adb5-1e93263181a7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""93a5577c-72a9-4072-b5e1-834f474175e8"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c77e57f0-c201-4d2d-8c7c-fabfbc0c2360"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControlsActionMap
        m_PlayerControlsActionMap = asset.FindActionMap("PlayerControlsActionMap", throwIfNotFound: true);
        m_PlayerControlsActionMap_Move = m_PlayerControlsActionMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerControlsActionMap_Interaction = m_PlayerControlsActionMap.FindAction("Interaction", throwIfNotFound: true);
        m_PlayerControlsActionMap_Attack = m_PlayerControlsActionMap.FindAction("Attack", throwIfNotFound: true);
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

    // PlayerControlsActionMap
    private readonly InputActionMap m_PlayerControlsActionMap;
    private IPlayerControlsActionMapActions m_PlayerControlsActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerControlsActionMap_Move;
    private readonly InputAction m_PlayerControlsActionMap_Interaction;
    private readonly InputAction m_PlayerControlsActionMap_Attack;
    public struct PlayerControlsActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerControlsActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControlsActionMap_Move;
        public InputAction @Interaction => m_Wrapper.m_PlayerControlsActionMap_Interaction;
        public InputAction @Attack => m_Wrapper.m_PlayerControlsActionMap_Attack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControlsActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnMove;
                @Interaction.started -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnInteraction;
                @Attack.started -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerControlsActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerControlsActionMapActions @PlayerControlsActionMap => new PlayerControlsActionMapActions(this);
    public interface IPlayerControlsActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
