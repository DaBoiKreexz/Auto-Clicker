using AutoClicker;
using System.Runtime.InteropServices;

Renderer renderer = new Renderer();
renderer.Start().Wait();

[DllImport("user32.dll")]
static extern short GetAsyncKeyState(int vKey);

// HotKeys
const int enableClicker = 0x75;
const int disableClicker = 0x76;

while (true) 
{
    if ((GetAsyncKeyState(enableClicker) & 0x8000) != 0)
    {
        renderer.enableAutoClicker = true;
    }
    else if ((GetAsyncKeyState(disableClicker) & 0x8000) != 0)
    {
        renderer.enableAutoClicker = false;
    }

    if (renderer.enableAutoClicker)
    {
        // Left Click
        if(renderer._selectedIndex == 0) 
        {
            mouse_event(MouseConstants.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(10);
            mouse_event(MouseConstants.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(20);
        }
        // Right Click
        else if(renderer._selectedIndex == 1)
        {
            mouse_event(MouseConstants.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            Thread.Sleep(10);
            mouse_event(MouseConstants.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            Thread.Sleep(20);
        }
    }
}

[DllImport("user32.dll")]
static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

static class MouseConstants
{
    public const int MOUSEEVENTF_LEFTDOWN = 0x02;
    public const int MOUSEEVENTF_LEFTUP = 0x04;
    public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; 
    public const int MOUSEEVENTF_RIGHTUP = 0x0010; 
}