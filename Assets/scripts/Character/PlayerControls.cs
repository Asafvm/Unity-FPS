// GENERATED AUTOMATICALLY FROM 'Assets/scripts/PlayerControls.inputactions'

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
            ""name"": ""FPS"",
            ""id"": ""4ab1812b-2a21-4cb2-8a45-8946b9354b23"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3c4d30af-72e4-4af5-bf0b-9c626e0200b4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""0781d254-90b8-4696-a2a5-44ca823c04b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMove"",
                    ""type"": ""Value"",
                    ""id"": ""15265100-9953-40b8-9551-19baf1ab2f66"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Value"",
                    ""id"": ""86e6a2cf-da65-40e4-91a2-3f8f43a31fce"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""76b39204-b3ca-44df-ae2a-ced7d6e3af5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""72f9965d-8043-48a5-b8ef-576bc7b10095"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""19288285-2b00-45ed-aba1-22a76a03e9dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6ffe92f5-d9c1-465d-97c0-62557f053a46"",
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
                    ""id"": ""6f984ac9-62d1-4d0d-8129-64bd9049b7c9"",
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
                    ""id"": ""89290d6c-3d62-4b16-aab0-38c73507ddc9"",
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
                    ""id"": ""78fe83b9-ee81-4d9b-9d18-a8a898ef2e0e"",
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
                    ""id"": ""0b66cb2d-89a7-45c8-b138-4fb3a354f821"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""363bed05-0e8b-4e70-9959-e80cbe55be10"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29b959ba-8faf-4f8b-b40f-9e9a1f5e0b98"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e53e45ce-9c1a-4b7f-8f3b-cf9efcf9b4ca"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ba8c4c0-6a1c-4455-a2eb-5949c0756d24"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""affb3f62-052d-4109-938f-14c4a50ab38f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1010e430-0cf8-4100-8225-22306117cf10"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FPS
        m_FPS = asset.FindActionMap("FPS", throwIfNotFound: true);
        m_FPS_Move = m_FPS.FindAction("Move", throwIfNotFound: true);
        m_FPS_Run = m_FPS.FindAction("Run", throwIfNotFound: true);
        m_FPS_CameraMove = m_FPS.FindAction("CameraMove", throwIfNotFound: true);
        m_FPS_CameraZoom = m_FPS.FindAction("CameraZoom", throwIfNotFound: true);
        m_FPS_Jump = m_FPS.FindAction("Jump", throwIfNotFound: true);
        m_FPS_Aim = m_FPS.FindAction("Aim", throwIfNotFound: true);
        m_FPS_Shoot = m_FPS.FindAction("Shoot", throwIfNotFound: true);
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

    // FPS
    private readonly InputActionMap m_FPS;
    private IFPSActions m_FPSActionsCallbackInterface;
    private readonly InputAction m_FPS_Move;
    private readonly InputAction m_FPS_Run;
    private readonly InputAction m_FPS_CameraMove;
    private readonly InputAction m_FPS_CameraZoom;
    private readonly InputAction m_FPS_Jump;
    private readonly InputAction m_FPS_Aim;
    private readonly InputAction m_FPS_Shoot;
    public struct FPSActions
    {
        private @PlayerControls m_Wrapper;
        public FPSActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_FPS_Move;
        public InputAction @Run => m_Wrapper.m_FPS_Run;
        public InputAction @CameraMove => m_Wrapper.m_FPS_CameraMove;
        public InputAction @CameraZoom => m_Wrapper.m_FPS_CameraZoom;
        public InputAction @Jump => m_Wrapper.m_FPS_Jump;
        public InputAction @Aim => m_Wrapper.m_FPS_Aim;
        public InputAction @Shoot => m_Wrapper.m_FPS_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_FPS; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSActions set) { return set.Get(); }
        public void SetCallbacks(IFPSActions instance)
        {
            if (m_Wrapper.m_FPSActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnRun;
                @CameraMove.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnCameraMove;
                @CameraMove.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnCameraMove;
                @CameraMove.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnCameraMove;
                @CameraZoom.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnCameraZoom;
                @Jump.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                @Aim.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_FPSActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @CameraMove.started += instance.OnCameraMove;
                @CameraMove.performed += instance.OnCameraMove;
                @CameraMove.canceled += instance.OnCameraMove;
                @CameraZoom.started += instance.OnCameraZoom;
                @CameraZoom.performed += instance.OnCameraZoom;
                @CameraZoom.canceled += instance.OnCameraZoom;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public FPSActions @FPS => new FPSActions(this);
    public interface IFPSActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
        void OnCameraZoom(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
