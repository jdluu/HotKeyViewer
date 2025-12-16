<lane vertical-content-alignment="Middle" horizontal-content-alignment="Middle" orientation="Vertical">
    <frame layout="1000px 500px" background-tint="#AA000000" padding="20" background={@Mods/StardewUI/Sprites/MenuBackground} border={@Mods/StardewUI/Sprites/MenuBorder} border-thickness="36, 36, 40, 36">
        <lane orientation="Vertical">
            <label text="Keyboard Overlay" font="dialogue" horizontal-alignment="Middle" color="#FFFFFF" />
            
            <lane orientation="Vertical" horizontal-content-alignment="Middle" margin="10, 20, 0, 0">
                <!-- Number Row -->
                <lane>
                    <keybind *repeat={Row1} keybind={this} button-height="64" sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} margin="2" />
                </lane>
                <!-- QWERTY Row -->
                <lane>
                    <keybind *repeat={Row2} keybind={this} button-height="64" sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} margin="2" />
                </lane>
                 <!-- ASDF Row -->
                 <lane>
                    <keybind *repeat={Row3} keybind={this} button-height="64" sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} margin="2" />
                </lane>
            </lane>
        </lane>
    </frame>
</lane>
