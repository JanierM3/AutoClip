using System;
using System.Runtime.InteropServices;

namespace AutoClips.Core;

public class HotkeyListener
{
    /*
        - GetAsyncKeyState: Función de Windows que verifica si una tecla está presionada
        - Retorna un valor negativo (< 0) si la tecla está pulsada actualmente
    */
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);

    private const int HOTKEY = 0x77; // - 0x77 es el código hexadecimal de la tecla F8

    public void Listen()
    {
        Console.WriteLine("HotkeyListener iniciado (F8)");

        while (true)
        {
            if (GetAsyncKeyState(HOTKEY) < 0)
            {
                Console.WriteLine("F8 presionada - Clip solicitado");
                System.Threading.Thread.Sleep(1000);
            }

            System.Threading.Thread.Sleep(50);
        }
    }
}