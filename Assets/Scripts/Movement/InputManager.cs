using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputManager : MonoBehaviour
{
    
    private static Controls _controls;
    
    
    public static void init(Player _player)
    {

        _controls = new Controls();

        _controls.Move.Walk.performed += ctx => {

            _player.SetMoveDirection(ctx.ReadValue<Vector2>());
            
        
        };

        _controls.Move.Reset.performed += ctx =>
        {

            print("hey");
            _player.Reset();

        };
        _controls.Move.CharSelect.performed += ctx =>
        {

            
            _player.chr = 1; 

        };
        _controls.Move.CharSelect2.performed += ctx =>
        {

            
            _player.chr = 2; 

        };
        
        //_controls.Permanent.Enable();

    }
    public static void moveMode()
    {

        _controls.Move.Enable();
        

    }
}
