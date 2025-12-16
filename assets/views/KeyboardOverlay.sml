<lane vertical-content-alignment="Middle" horizontal-content-alignment="Middle" orientation="Vertical" layout="stretch">
    <frame layout="1000px 500px" background-tint="#AA000000" padding="20" background={@Mods/StardewUI/Sprites/MenuBackground} border={@Mods/StardewUI/Sprites/MenuBorder} border-thickness="36, 36, 40, 36">
        <lane orientation="Vertical">
            <label text="Keyboard Overlay" font="dialogue" horizontal-alignment="Middle" color="#FFFFFF" />
            
            <lane orientation="Horizontal" horizontal-content-alignment="Middle" margin="10, 20, 0, 0">
                
                <!-- MAIN BLOCK -->
                <lane orientation="Vertical" margin="0, 0, 20, 0">
                    <!-- Function Row -->
                    <lane margin="0,0,0,10">
                        <lane *repeat={:FunctionRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                    
                    <!-- Number Row -->
                    <lane>
                         <lane *repeat={:NumberRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>

                    <!-- Top Row -->
                    <lane>
                         <lane *repeat={:TopRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>

                     <!-- Home Row -->
                     <lane>
                         <lane *repeat={:HomeRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                    
                     <!-- Bottom Row -->
                     <lane>
                         <lane *repeat={:BottomRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>

                     <!-- Space Row -->
                     <lane>
                         <lane *repeat={:SpaceRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                </lane>

                <!-- NAVIGATION BLOCK -->
                <lane orientation="Vertical" margin="0, 0, 20, 0">
                     <!-- System Row (PrtScn) -->
                    <lane margin="0,0,0,10">
                        <lane *repeat={:SystemRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                    
                    <!-- Nav Block 1 (Ins) -->
                    <lane>
                        <lane *repeat={:NavRow1} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                     <!-- Nav Block 2 (Del) -->
                    <lane>
                        <lane *repeat={:NavRow2} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                    
                    <!-- Arrow Up -->
                    <lane margin="0, 20, 0, 0">
                        <lane *repeat={:ArrowUpRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                     <!-- Arrow Bottom -->
                    <lane>
                        <lane *repeat={:ArrowBottomRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                </lane>

                <!-- NUMPAD BLOCK -->
                <lane orientation="Vertical">
                     <!-- Numpad Row 1 -->
                    <lane>
                        <lane *repeat={:NumpadRow1} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                     <!-- Numpad Row 2 -->
                    <lane>
                        <lane *repeat={:NumpadRow2} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                     <!-- Numpad Row 3 -->
                    <lane>
                        <lane *repeat={:NumpadRow3} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                     <!-- Numpad Row 4 -->
                    <lane>
                        <lane *repeat={:NumpadRow4} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                     <!-- Numpad Row 5 -->
                    <lane>
                        <lane *repeat={:NumpadRow5} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={Label} font="small" color="#AAAAAA" />
                             <keybind keybind={Keybind} layout={LayoutSize} sprite-map={@Mods/StardewUI/SpriteMaps/Buttons:default-default-0.5} />
                        </lane>
                    </lane>
                </lane>
            </lane>
        </lane>
    </frame>
</lane>
