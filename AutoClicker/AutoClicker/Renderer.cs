using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickableTransparentOverlay;
using ImGuiNET;


namespace AutoClicker
{
    internal class Renderer : Overlay
    {

        public bool enableAutoClicker;
        public string[] _items = { "Mouse 1", "Mouse 2" };
        public int _selectedIndex = 0;
        
        protected override void Render()
        {
            ImGui.Begin("Auto Clicker (By Kreexz)");

            string currentPreviewValue = _items[_selectedIndex];
            if (ImGui.BeginCombo("Select Options", currentPreviewValue))
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    bool isSelected = (_selectedIndex == i);

                    if (ImGui.Selectable(_items[i], isSelected))
                    {
                        _selectedIndex = i; 
                    }

                    if (isSelected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndCombo();
            }

            ImGui.Checkbox("Auto Clicker", ref enableAutoClicker);

            ImGui.End();
        }
    }
}
