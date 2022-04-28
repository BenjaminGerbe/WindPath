// GENERATED AUTOMATICALLY FROM 'Assets/BoatInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BoatInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BoatInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BoatInput"",
    ""maps"": [
        {
            ""name"": ""Bateau"",
            ""id"": ""72d587d6-e2aa-4790-b3f4-a9169bbe13f3"",
            ""actions"": [
                {
                    ""name"": ""Mouvement"",
                    ""type"": ""Button"",
                    ""id"": ""8541b91c-238a-459e-988d-3eeeb334383e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ArrowKey"",
                    ""id"": ""256561a5-b0dc-42cf-905d-2fbfe1ce33fb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""25ff1aac-bdbf-48ae-ba59-31ac2d5f5397"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""16b71529-5101-44d9-8d11-507356880706"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4d25f201-e006-4a51-a2ff-b7b49251c4c9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2d600bd4-ff45-4def-afa9-2749a96caee6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""c20e0197-09d9-4685-9496-28fc13754ca3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e23c25d0-1849-4655-9684-81b77e961a59"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ManetteXbox"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""32d9d946-0e7f-4b60-9971-863020ded743"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ManetteXbox"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8c044bec-8f78-47ec-b49e-1ae70dc89eee"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ManetteXbox"",
                    ""action"": ""Mouvement"",
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
        },
        {
            ""name"": ""ManetteXbox"",
            ""bindingGroup"": ""ManetteXbox"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Bateau
        m_Bateau = asset.FindActionMap("Bateau", throwIfNotFound: true);
        m_Bateau_Mouvement = m_Bateau.FindAction("Mouvement", throwIfNotFound: true);
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

    // Bateau
    private readonly InputActionMap m_Bateau;
    private IBateauActions m_BateauActionsCallbackInterface;
    private readonly InputAction m_Bateau_Mouvement;
    public struct BateauActions
    {
        private @BoatInput m_Wrapper;
        public BateauActions(@BoatInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouvement => m_Wrapper.m_Bateau_Mouvement;
        public InputActionMap Get() { return m_Wrapper.m_Bateau; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BateauActions set) { return set.Get(); }
        public void SetCallbacks(IBateauActions instance)
        {
            if (m_Wrapper.m_BateauActionsCallbackInterface != null)
            {
                @Mouvement.started -= m_Wrapper.m_BateauActionsCallbackInterface.OnMouvement;
                @Mouvement.performed -= m_Wrapper.m_BateauActionsCallbackInterface.OnMouvement;
                @Mouvement.canceled -= m_Wrapper.m_BateauActionsCallbackInterface.OnMouvement;
            }
            m_Wrapper.m_BateauActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouvement.started += instance.OnMouvement;
                @Mouvement.performed += instance.OnMouvement;
                @Mouvement.canceled += instance.OnMouvement;
            }
        }
    }
    public BateauActions @Bateau => new BateauActions(this);
    private int m_KeyBoardSchemeIndex = -1;
    public InputControlScheme KeyBoardScheme
    {
        get
        {
            if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
            return asset.controlSchemes[m_KeyBoardSchemeIndex];
        }
    }
    private int m_ManetteXboxSchemeIndex = -1;
    public InputControlScheme ManetteXboxScheme
    {
        get
        {
            if (m_ManetteXboxSchemeIndex == -1) m_ManetteXboxSchemeIndex = asset.FindControlSchemeIndex("ManetteXbox");
            return asset.controlSchemes[m_ManetteXboxSchemeIndex];
        }
    }
    public interface IBateauActions
    {
        void OnMouvement(InputAction.CallbackContext context);
    }
}
