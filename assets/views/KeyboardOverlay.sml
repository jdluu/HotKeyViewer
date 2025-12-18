<lane vertical-content-alignment="Middle" horizontal-content-alignment="Middle" orientation="Vertical" layout="stretch">
    <!-- Darkened background for better contrast (FA101010) -->
    <frame layout="1920px 800px" background-tint="#FA101010" padding="20" background={@Mods/StardewUI/Sprites/MenuBackground} border={@Mods/StardewUI/Sprites/MenuBorder} border-thickness="36, 36, 40, 36">
        <lane orientation="Vertical">
            <label text="Keyboard Overlay" font="dialogue" horizontal-alignment="Middle" color="#FFFFFF" />
            
            <lane orientation="Horizontal" horizontal-content-alignment="Middle" margin="10, 20, 0, 0">
                
                <!-- MAIN BLOCK -->
                <lane orientation="Vertical" margin="0, 0, 20, 0">
                    <!-- Function Row -->
                    <lane margin="0,0,0,10">
                        <lane *repeat={:FunctionRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                    
                    <!-- Number Row -->
                    <lane>
                         <lane *repeat={:NumberRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>

                    <!-- Top Row -->
                    <lane>
                         <lane *repeat={:TopRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>

                     <!-- Home Row -->
                     <lane>
                         <lane *repeat={:HomeRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                    
                     <!-- Bottom Row -->
                     <lane>
                         <lane *repeat={:BottomRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>

                     <!-- Space Row -->
                     <lane>
                         <lane *repeat={:SpaceRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                </lane>

                <!-- NAVIGATION BLOCK -->
                <lane orientation="Vertical" margin="0, 0, 20, 0">
                     <!-- System Row (PrtScn) -->
                    <lane margin="0,0,0,10">
                        <lane *repeat={:SystemRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                    
                    <!-- Nav Block 1 (Ins) -->
                    <lane>
                        <lane *repeat={:NavRow1} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                     <!-- Nav Block 2 (Del) -->
                    <lane>
                        <lane *repeat={:NavRow2} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                    
                    <!-- Arrow Up -->
                    <lane margin="68, 20, 0, 0">
                        <lane *repeat={:ArrowUpRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                     <!-- Arrow Bottom -->
                    <lane>
                        <lane *repeat={:ArrowBottomRow} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                </lane>

                <!-- NUMPAD BLOCK -->
                <lane orientation="Horizontal">
                     <!-- Left Section (Rows) -->
                    <lane orientation="Vertical" margin="0, 0, 4, 0">
                         <!-- Numpad Row 1 -->
                        <lane>
                            <lane *repeat={:NumpadLeft1} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <label text={:Label} font="dialogue" color="#FFD700" />
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 2 -->
                        <lane>
                            <lane *repeat={:NumpadLeft2} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <label text={:Label} font="dialogue" color="#FFD700" />
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 3 -->
                        <lane>
                            <lane *repeat={:NumpadLeft3} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <label text={:Label} font="dialogue" color="#FFD700" />
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 4 -->
                        <lane>
                            <lane *repeat={:NumpadLeft4} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <label text={:Label} font="dialogue" color="#FFD700" />
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                            </lane>
                        </lane>
                         <!-- Numpad Row 5 -->
                        <lane>
                            <lane *repeat={:NumpadLeft5} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                                 <label text={:Label} font="dialogue" color="#FFD700" />
                                 <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                            </lane>
                        </lane>
                    </lane>

                    <!-- Right Section (Ops Column) -->
                    <lane orientation="Vertical">
                        <lane *repeat={:NumpadRight} orientation="Vertical" horizontal-content-alignment="Middle" margin="2">
                             <label text={:Label} font="dialogue" color="#FFD700" />
                             <frame layout={:LayoutSize} background={@Mods/StardewUI/Sprites/ControlBorder} background-tint={:Tint} padding="0" horizontal-content-alignment="Middle" vertical-content-alignment="Middle">
                                <label text={:FaceText} color="#222222" font="small" />
                             </frame>
                        </lane>
                    </lane>
                </lane>
            </lane>
        </lane>
    </frame>
</lane>
